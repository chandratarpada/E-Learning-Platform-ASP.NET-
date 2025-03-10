using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Admin_learning
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (!IsPostBack)
            {
                InsertDefaultUsers();
            }
        }

        private void InsertDefaultUsers()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string checkAdminQuery = "SELECT COUNT(*) FROM Admin WHERE Email='admin@gmail.com'";
                using (SqlCommand cmd = new SqlCommand(checkAdminQuery, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insertAdminQuery = "INSERT INTO Admin (Email, Password, Role) VALUES ('admin@gmail.com', 'admin', 'Admin')";
                        new SqlCommand(insertAdminQuery, conn).ExecuteNonQuery();
                    }
                }

                string checkLecturerQuery = "SELECT COUNT(*) FROM Admin WHERE Email='lecturer@gmail.com'";
                using (SqlCommand cmd = new SqlCommand(checkLecturerQuery, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insertLecturerQuery = "INSERT INTO Admin (Email, Password, Role) VALUES ('lecturer@gmail.com', 'lecturer', 'Lecturer')";
                        new SqlCommand(insertLecturerQuery, conn).ExecuteNonQuery();
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = ddlRole.SelectedValue;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                lblMessage.Text = "Please fill all fields!";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM Admin WHERE Email=@Email AND Password=@Password AND Role=@Role";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();

                    if (count > 0)
                    {
                        Session["UserEmail"] = email;
                        Session["UserRole"] = role;

                        if (role == "Admin")
                        {
                            Response.Redirect("index.aspx");
                        }
                        else if (role == "Lecturer")
                        {
                            Response.Redirect("lecturer.aspx");
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Invalid Email, Password, or Role!";
                    }
                }
            }
        }
    }
}
