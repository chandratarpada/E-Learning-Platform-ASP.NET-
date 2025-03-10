using System;
using System.Data.SqlClient;

namespace MyWebApp
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        string connectionString = "YourConnectionStringHere";
        protected int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userId"] != null)
            {
                userId = int.Parse(Request.QueryString["userId"]);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Users WHERE UserId = @UserId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("view_users.aspx");
                }
            }
        }
    }
}
