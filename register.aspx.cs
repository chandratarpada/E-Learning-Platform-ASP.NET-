using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace my_project
{
    public partial class register : Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Hide buttons initially
                btnRead.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                // Show buttons dynamically based on user role (Example: If admin logs in)
                if (Session["UserRole"] != null && Session["UserRole"].ToString() == "Admin")
                {
                    btnRead.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                }
            }
        }

        // Register user button click event
        protected void RegisterUser_Click(object sender, EventArgs e)
        {
            string nm = name.Text;
            string eml = email.Text;
            string password = pass.Text;
            string confirmPassword = c_pass.Text;
            string profileImagePath = "";

            // Check if password and confirm password match
            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Passwords do not match!');</script>");
                return;
            }

            // Check if email already exists in the database
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string emailCheckQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(emailCheckQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", eml);

                        conn.Open();
                        int emailCount = (int)cmd.ExecuteScalar();

                        if (emailCount > 0)
                        {
                            Response.Write("<script>alert('Email already registered!');</script>");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error checking email: " + ex.Message + "');</script>");
                return;
            }

            // Handle profile image upload
            if (profileImage.HasFile)
            {
                profileImagePath = "~/ProfileImages/" + profileImage.FileName;
                string path = Server.MapPath(profileImagePath);

                try
                {
                    profileImage.SaveAs(path);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error saving image: " + ex.Message + "');</script>");
                    return;
                }
            }

            // Insert new user into the database
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Users (Name, Email, Password, ProfileImage) VALUES (@Name, @Email, @Password, @ProfileImage)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", nm);
                        cmd.Parameters.AddWithValue("@Email", eml);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@ProfileImage", profileImagePath);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Write("<script>alert('User registered successfully!');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        // Read Users (View all users)
        protected void ReadUser_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT UserId, Name, Email, ProfileImage FROM Users";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Response.Write("<br/>UserId: " + row["UserId"] + ", Name: " + row["Name"] + ", Email: " + row["Email"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        // Update User (Update user details)
        protected void UpdateUser_Click(object sender, EventArgs e)
        {
            int userId = 1; // This should be fetched dynamically
            string newName = "Updated Name";
            string newEmail = "updatedemail@example.com";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Users SET Name = @Name, Email = @Email WHERE UserId = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", newName);
                        cmd.Parameters.AddWithValue("@Email", newEmail);
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Write("<script>alert('User updated successfully!');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        // Delete User (Delete a user)
        protected void DeleteUser_Click(object sender, EventArgs e)
        {
            int userId = 1; // This should be fetched dynamically

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE UserId = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Write("<script>alert('User deleted successfully!');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}
