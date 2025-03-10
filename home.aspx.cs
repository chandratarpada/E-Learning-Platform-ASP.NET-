using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace my_project
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPlaylists();
            }
        }

        private void LoadPlaylists()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"SELECT DISTINCT 
                                    p.Playlist_id, 
                                    p.Name, 
                                    p.Description, 
                                    p.Pimg,
                                    s.Name AS StaffName,
                                    (SELECT COUNT(*) FROM Lecturer l2 
                                     WHERE l2.Playlist_id = p.Playlist_id) AS LectureCount
                                FROM Playlist p
                                LEFT JOIN Lecturer l ON p.Playlist_id = l.Playlist_id
                                LEFT JOIN Staff s ON l.Staff_id = s.Id
                                GROUP BY p.Playlist_id, p.Name, p.Description, p.Pimg, s.Name
                                ORDER BY p.Playlist_id DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    // Handle null or empty image paths
                                    if (string.IsNullOrEmpty(row["Pimg"].ToString()))
                                    {
                                        row["Pimg"] = "~/images/default-playlist.png";
                                    }
                                    else
                                    {
                                        // Ensure the image path exists
                                        string imagePath = Server.MapPath(row["Pimg"].ToString());
                                        if (!File.Exists(imagePath))
                                        {
                                            row["Pimg"] = "~/images/default-playlist.png";
                                        }
                                    }

                                    // Handle null staff name
                                    if (string.IsNullOrEmpty(row["StaffName"].ToString()))
                                    {
                                        row["StaffName"] = "Not Assigned";
                                    }
                                }

                                pnlNoData.Visible = false;
                                rptPlaylists.Visible = true;
                                rptPlaylists.DataSource = dt;
                                rptPlaylists.DataBind();
                            }
                            else
                            {
                                pnlNoData.Visible = true;
                                rptPlaylists.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                ShowErrorMessage("An error occurred while loading playlists.");
            }
        }

        private void LogError(Exception ex)
        {
            // Implement error logging
            string logPath = Server.MapPath("~/App_Data/ErrorLog.txt");
            string errorMessage = $"[{DateTime.Now}] Error: {ex.Message}\n" +
                                $"Stack Trace: {ex.StackTrace}\n\n";

            try
            {
                File.AppendAllText(logPath, errorMessage);
            }
            catch
            {
                // Fail silently if unable to log
            }
        }

        private void ShowErrorMessage(string message)
        {
            ScriptManager.RegisterStartupScript(this, GetType(),
                "ShowError", $"alert('{message}');", true);
        }
    }
}