using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace my_project
{
    public partial class playlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int playlistId;
                    if (int.TryParse(Request.QueryString["Id"], out playlistId))
                    {
                        LoadVideos(playlistId);
                    }
                }
            }
        }

        private void LoadVideos(int playlistId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT l.Name AS LecturerName, l.Video " +
                               "FROM Lecturer l " +
                               "WHERE l.Playlist_id = @PlaylistId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PlaylistId", playlistId);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Ensure we fetch the correct video path
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!DBNull.Value.Equals(row["Video"]) && !string.IsNullOrEmpty(row["Video"].ToString()))
                        {
                            // Assuming "Video" column stores paths like "Videos/vid-5.mp4"
                            row["Video"] = ResolveUrl("~/") + row["Video"].ToString();
                        }
                    }

                    rptVideos.DataSource = dt;
                    rptVideos.DataBind();
                }
            }
        }
    }
}
