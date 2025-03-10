// WebForm1.aspx.cs
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace lecturer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private LecturerClass lecturerClass = new LecturerClass();
        string vidnm, ext, path;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDownLists();
                LoadGrid();
            }
        }

        void vidupload()
        {
            string[] validExtensions = { ".mp4" };
            vidnm = fileUploadVideo.FileName;
            ext = Path.GetExtension(vidnm);

            if (!validExtensions.Contains(ext.ToLower()))
                throw new Exception("Invalid video format.");

            path = "Videos/" + vidnm;
            fileUploadVideo.SaveAs(Server.MapPath(path));
        }

        private void LoadDropDownLists()
        {
            ddlPlaylist.DataSource = lecturerClass.GetAllPlaylists();
            ddlPlaylist.DataTextField = "Name";
            ddlPlaylist.DataValueField = "Id";
            ddlPlaylist.DataBind();

            ddlStaff.DataSource = lecturerClass.GetAllStaff();
            ddlStaff.DataTextField = "Name";
            ddlStaff.DataValueField = "Id";
            ddlStaff.DataBind();
        }

        private void LoadGrid()
        {
            GridView1.DataSource = lecturerClass.GetAllLecturers();
            GridView1.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int playlistId = Convert.ToInt32(ddlPlaylist.SelectedValue);
                int staffId = Convert.ToInt32(ddlStaff.SelectedValue);

                if (btnSave.Text == "Save")
                {
                    vidupload();
                    lecturerClass.Insert(txtName.Text, path, playlistId, staffId);
                }
                else
                {
                    if (fileUploadVideo.HasFile)
                    {
                        vidupload();
                        lecturerClass.Update(Convert.ToInt16(ViewState["EditId"]), txtName.Text, playlistId, staffId, path);
                    }
                    else
                    {
                        lecturerClass.Update(Convert.ToInt16(ViewState["EditId"]), txtName.Text, playlistId, staffId);
                    }
                    btnSave.Text = "Save";
                }

                ClearForm();
                LoadGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "error", $"alert('Error: {ex.Message}');", true);
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id;
            switch (e.CommandName)
            {
                case "cmd_edit":
                    id = Convert.ToInt32(e.CommandArgument);
                    EditLecturer(id);
                    break;

                case "cmd_delete":
                    id = Convert.ToInt32(e.CommandArgument);
                    DeleteLecturer(id);
                    break;
            }
        }

        private void EditLecturer(int id)
        {
            try
            {
                DataRow dr = lecturerClass.GetLecturerById(id);
                if (dr != null)
                {
                    txtName.Text = dr["Name"].ToString();
                    ddlPlaylist.SelectedValue = dr["Playlist_id"].ToString();
                    ddlStaff.SelectedValue = dr["Staff_id"].ToString();
                    ViewState["EditId"] = id;
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "error", $"alert('Error loading lecturer: {ex.Message}');", true);
            }
        }

        private void DeleteLecturer(int id)
        {
            try
            {
                lecturerClass.Delete(id);
                LoadGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "error", $"alert('Error deleting lecturer: {ex.Message}');", true);
            }
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            ddlPlaylist.SelectedIndex = 0;
            ddlStaff.SelectedIndex = 0;
            ViewState["EditId"] = null;
            btnSave.Text = "Save";
        }
    }
}