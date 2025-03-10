using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Xml.Linq;

namespace MyWebApp
{
    public partial class EditUser : System.Web.UI.Page
    {
        string connectionString = "db";
        protected int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userId"] != null)
            {
                userId = int.Parse(Request.QueryString["userId"]);
                if (!IsPostBack)
                {
                    LoadUserData();
                }
            }
        }

        private void LoadUserData()
        {
            string query = "SELECT Name, Email, ProfilePicture FROM Users WHERE UserId = @UserId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            HttpPostedFile profileImage = Request.Files["profileImage"];
            byte[] profileImageBytes = null;

            if (profileImage != null && profileImage.ContentLength > 0)
            {
                using (BinaryReader reader = new BinaryReader(profileImage.InputStream))
                {
                    profileImageBytes = reader.ReadBytes(profileImage.ContentLength);
                }
            }

            string query = "UPDATE Users SET Name = @Name, Email = @Email, ProfilePicture = @ProfilePicture WHERE UserId = @UserId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@ProfilePicture", profileImageBytes ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("view_users.aspx");
                }
            }
        }
    }
}
