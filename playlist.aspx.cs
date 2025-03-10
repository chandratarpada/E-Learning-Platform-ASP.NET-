using System;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Admin_learning
{
    public partial class Playlist : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Playlist";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string imagePath = "";  // Variable to store image path

            // Check if a file is uploaded
            if (fileUploadPimg.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadPimg.FileName);
                string folderPath = Server.MapPath("~/Uploads/"); // Folder to store images
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath); // Create folder if it doesn't exist
                }

                imagePath = "~/Uploads/" + fileName;
                fileUploadPimg.SaveAs(folderPath + fileName);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Playlist (Name, Description, Pimg) VALUES (@Name, @Description, @Pimg)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Pimg", imagePath);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LoadGrid(); // Refresh grid after inserting data
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int playlistId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "cmd_delete")
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Playlist WHERE Playlist_id = @Playlist_id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Playlist_id", playlistId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadGrid(); // Refresh GridView after deletion
            }
        }
    }
}
