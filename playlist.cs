using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Admin_learning
{
    public class PlaylistManager
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public DataTable GetAllPlaylists()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Playlist_id, Name, Description, Pimg FROM Playlist";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void InsertPlaylist(string name, string description, string pimg)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Playlist (Name, Description, Pimg) VALUES (@Name, @Description, @Pimg)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Pimg", pimg);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePlaylist(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Playlist WHERE Playlist_id = @Playlist_id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Playlist_id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
