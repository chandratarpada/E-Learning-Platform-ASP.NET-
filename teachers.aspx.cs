using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace my_project
{
    public partial class teachers : Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTeachers();
            }
        }

        private void LoadTeachers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Debugging: Log if the connection opens
                    Response.Write("<script>console.log('Database Connected');</script>");

                    string query = @"
                        SELECT 
                            s.Id AS StaffId, 
                            s.Name, 
                            s.Picture, 
                            COUNT(DISTINCT l.Playlist_id) AS PlaylistCount,
                            COUNT(l.Id) AS VideoCount
                        FROM Staff s
                        LEFT JOIN Lecturer l ON s.Id = l.Staff_id
                        GROUP BY s.Id, s.Name, s.Picture";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        string html = "";

                        bool hasTeachers = false;

                        while (reader.Read())
                        {
                            hasTeachers = true;
                            string staffId = reader["StaffId"].ToString();
                            string name = reader["Name"].ToString();
                            string picture = string.IsNullOrEmpty(reader["Picture"].ToString()) ? "ProfileImages/default-profile.png" : reader["Picture"].ToString();
                            int playlistCount = Convert.ToInt32(reader["PlaylistCount"]);
                            int videoCount = Convert.ToInt32(reader["VideoCount"]);

                            string status = playlistCount > 0 ? "Active" : "Inactive";
                            string statusColor = playlistCount > 0 ? "green" : "red";

                            html += $@"
                            <div class='box'>
                                <div class='tutor'>
                                    <img src='{picture}' alt='{name}'/>
                                    <div>
                                        <h3>{name}</h3>
                                        <span>Expert Tutor</span>
                                    </div>
                                </div>
                                <p>Total Playlists: <span>{playlistCount}</span></p>
                                <p>Total Videos: <span>{videoCount}</span></p>
                                <p>Status: <span style='color: {statusColor}; font-weight: bold;'>{status}</span></p>
                                <a href='teacher_profile.aspx?id={staffId}' class='inline-btn'>View Profile</a>
                            </div>";

                            // Debugging: Log fetched data
                            Response.Write($"<script>console.log('Fetched Tutor: {name}, Playlists: {playlistCount}, Videos: {videoCount}');</script>");
                        }

                        reader.Close();

                        if (!hasTeachers)
                        {
                            html += "<p class='empty'>No tutors found!</p>";
                            Response.Write("<script>console.log('No tutors found in database');</script>");
                        }

                        boxContainer.Text = html;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error loading teachers: {ex.Message.Replace("'", "\\'")}');</script>");
                Response.Write($"<script>console.log('Error: {ex.Message}');</script>");
            }
        }
    }
}
