using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Admin_learning
{
    public class ContactManager
    {
        private readonly string connectionString;

        public ContactManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        }

        // Get All Users
        public DataTable GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Email, Phone, Msg FROM Contact";
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
        public void DeleteUser(int ContactID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Contact WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", ContactID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
