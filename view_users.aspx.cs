using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyWebApp
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        // Corrected: Retrieve connection string from Web.config
        string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUsers();
            }
        }

        private void BindUsers()
        {
            string query = "SELECT UserId, Name, Email, ProfilePicture FROM Users";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Ensure connection is opened before executing the query

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        RepeaterUsers.DataSource = dt;
                        RepeaterUsers.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}
