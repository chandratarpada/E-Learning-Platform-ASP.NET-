using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using staff;

namespace Admin_learning
{
    public partial class WebForm2 : Page
    {
        staff.staff cs;
        string picturePath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cs = new staff.staff();
                Fillgrid();
            }
        }

        // Method to upload the picture
        void UploadPicture()
        {
            if (fileUploadPicture.HasFile)
            {
                string[] validExtensions = { ".jpg", ".jpeg", ".png" };
                string ext = Path.GetExtension(fileUploadPicture.FileName).ToLower();

                if (!Array.Exists(validExtensions, x => x == ext))
                    throw new Exception("Invalid image format. Please use .jpg, .jpeg, or .png");

                picturePath = "images/" + Guid.NewGuid().ToString() + ext;
                fileUploadPicture.SaveAs(Server.MapPath(picturePath));
            }
        }

        // Save or update the staff details when button is clicked
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cs = new staff.staff();
                if (Button1.Text == "Save")
                {
                    UploadPicture();
                    cs.insert(txtName.Text, txtEmail.Text, txtContact.Text,
                            txtQualification.Text, txtExperience.Text, picturePath);
                }
                else
                {
                    if (fileUploadPicture.HasFile)
                    {
                        UploadPicture();
                        cs.updateWithPicture(Convert.ToInt32(ViewState["id"]), txtName.Text,
                            txtEmail.Text, txtContact.Text, txtQualification.Text,
                            txtExperience.Text, picturePath);
                    }
                    else
                    {
                        cs.update(Convert.ToInt32(ViewState["id"]), txtName.Text,
                            txtEmail.Text, txtContact.Text, txtQualification.Text,
                            txtExperience.Text);
                    }
                    Button1.Text = "Save";
                }
                Clear();
                Fillgrid();
            }
            catch (Exception ex)
            {
                Response.Write($"Error: {ex.Message}");
            }
        }

        // Handle GridView row commands like Edit or Delete
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            cs = new staff.staff();
            if (e.CommandName == "cmd_edt")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["id"] = id;
                DataSet ds = cs.selectid(id);
                DataRow row = ds.Tables[0].Rows[0];

                txtName.Text = row["Name"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtContact.Text = row["Contact"].ToString();
                txtQualification.Text = row["Qualification"].ToString();
                txtExperience.Text = row["Experience"].ToString();

                Button1.Text = "Update";
            }
            else if (e.CommandName == "cmd_dlt")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                cs.delete(id);
                Fillgrid();
            }
        }

        // Fill the GridView with data from the database
        void Fillgrid()
        {
            GridView1.DataSource = cs.select();
            GridView1.DataBind();
        }

        // Clear all input fields
        void Clear()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtQualification.Text = "";
            txtExperience.Text = "";
        }
    }
}
