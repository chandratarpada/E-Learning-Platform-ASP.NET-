using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace my_project
{
    public partial class teacher_profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTeacherProfile();
                LoadCourses();
            }
        }

        private void LoadTeacherProfile()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT Name, Picture, Qualification FROM Staff WHERE Id = @StaffId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", 1); // Change dynamically based on logged-in user
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblStaffName.Text = reader["Name"].ToString();
                        lblQualification.Text = reader["Qualification"].ToString();
                        imgStaff.ImageUrl = reader["Picture"].ToString();
                    }
                    conn.Close();
                }
            }

            LoadCounts();
        }

        private void LoadCounts()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT 
                        (SELECT COUNT(DISTINCT Playlist_id) FROM Lecturer WHERE Staff_id = @StaffId) AS TotalPlaylists,
                        (SELECT COUNT(Id) FROM Lecturer WHERE Staff_id = @StaffId) AS TotalVideos";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", 1);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblTotalPlaylists.Text = reader["TotalPlaylists"].ToString();
                        lblTotalVideos.Text = reader["TotalVideos"].ToString();
                    }
                    conn.Close();
                }
            }
        }

        private void LoadCourses()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT 
                        p.Name AS PlaylistName,
                        COUNT(l.Id) AS VideoCount, 
                        'ProfileImages/thumb-' + CAST(p.Playlist_id AS NVARCHAR) + '.png' AS Thumbnail
                    FROM Lecturer l
                    INNER JOIN Playlist p ON l.Playlist_id = p.Playlist_id
                    WHERE l.Staff_id = @StaffId
                    GROUP BY p.Name, p.Playlist_id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", 1);
                    conn.Open();
                    RepeaterCourses.DataSource = cmd.ExecuteReader();
                    RepeaterCourses.DataBind();
                    conn.Close();
                }
            }
        }
    }
}
