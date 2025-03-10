using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace lecturer
{
    public class LecturerClass
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        // Get all lecturers with related playlist and staff information
        public DataTable GetAllLecturers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        L.Id,
                        L.Name,
                        L.Video,
                        P.Name AS PlaylistName,
                        S.Name AS StaffName,
                        L.Playlist_id,
                        L.Staff_id
                    FROM Lecturer L
                    LEFT JOIN Playlist P ON L.Playlist_id = P.Playlist_id
                    LEFT JOIN Staff S ON L.Staff_id = S.Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Get all playlists
        public DataTable GetAllPlaylists()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Playlist_id AS Id, Name FROM Playlist";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Get all staff members
        public DataTable GetAllStaff()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Staff";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Get lecturer by ID
        public DataRow GetLecturerById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        L.Id,
                        L.Name,
                        L.Video,
                        L.Playlist_id,
                        L.Staff_id
                    FROM Lecturer L
                    WHERE L.Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                    }
                }
            }
        }

        // Insert lecturer
        public void Insert(string name, string videoPath, int playlistId, int staffId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO Lecturer (Name, Video, Playlist_id, Staff_id) 
                    VALUES (@Name, @Video, @PlaylistId, @StaffId)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Video", videoPath);
                    cmd.Parameters.AddWithValue("@PlaylistId", playlistId);
                    cmd.Parameters.AddWithValue("@StaffId", staffId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update lecturer with optional video update
        public void Update(int id, string name, int playlistId, int staffId, string videoPath = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query;
                if (videoPath != null)
                {
                    query = @"
                        UPDATE Lecturer 
                        SET Name = @Name,
                            Video = @Video,
                            Playlist_id = @PlaylistId,
                            Staff_id = @StaffId
                        WHERE Id = @Id";
                }
                else
                {
                    query = @"
                        UPDATE Lecturer 
                        SET Name = @Name,
                            Playlist_id = @PlaylistId,
                            Staff_id = @StaffId
                        WHERE Id = @Id";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@PlaylistId", playlistId);
                    cmd.Parameters.AddWithValue("@StaffId", staffId);

                    if (videoPath != null)
                    {
                        cmd.Parameters.AddWithValue("@Video", videoPath);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete lecturer
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Lecturer WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}