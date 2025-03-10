// Model file: PlaylistModel.cs
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace my_project.Models
{
    public class PlaylistModel
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffImage { get; set; }

        public static PlaylistModel GetPlaylistDetails(int playlistId)
        {
            PlaylistModel playlist = null;
            string connString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT p.*, s.Name AS StaffName, s.Image AS StaffImage " +
                    "FROM Playlist p " +
                    "JOIN Staff s ON p.Staff_id = s.Id " +
                    "WHERE p.Playlist_id = @PlaylistId", conn);

                cmd.Parameters.AddWithValue("@PlaylistId", playlistId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    playlist = new PlaylistModel
                    {
                        PlaylistId = Convert.ToInt32(reader["Playlist_id"]),
                        PlaylistName = reader["Playlist_name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Thumbnail = reader["Thumbnail"].ToString(),
                        StaffId = Convert.ToInt32(reader["Staff_id"]),
                        StaffName = reader["StaffName"].ToString(),
                        StaffImage = reader["StaffImage"].ToString()
                    };
                }
            }
            return playlist;
        }
    }
}
