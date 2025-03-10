using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Admin_learning
{
    public class UsersClass
    {
        private readonly string connectionString;

        public UsersClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        }

        // Get All Users
        public DataTable GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, Name, Email, ProfileImage FROM Users"; // Ensure column names match DB
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Delete User by ID
        public void DeleteUser(int userID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
