using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace my_project
{
    public partial class courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPlaylists();  // Fetch and display playlists
            }
        }

        private void LoadPlaylists()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT Playlist_id, Name, Description, Pimg FROM Playlist"; // Fixed column name
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Pimg"] == DBNull.Value || string.IsNullOrEmpty(row["Pimg"].ToString()))
                        {
                            row["Pimg"] = "~/default.jpg";  // Fallback image
                        }
                    }

                    rptPlaylists.DataSource = dt;
                    rptPlaylists.DataBind();
                }
            }
        }
    }
}
