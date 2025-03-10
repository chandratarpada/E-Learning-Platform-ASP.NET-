using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace staff
{
    public class staff
    {
        SqlConnection con;

        public staff()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            con = new SqlConnection(connectionString);
        }

        // Insert new staff record
        public void insert(string name, string email, string contact, string qualification,
            string experience, string picture)
        {
            using (SqlCommand cmd = new SqlCommand(@"INSERT INTO Staff 
                (Name, Email, Contact, Qualification, Experience, Picture) 
                VALUES (@Name, @Email, @Contact, @Qualification, @Experience, @Picture)", con))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Qualification", qualification);
                cmd.Parameters.AddWithValue("@Experience", experience);
                cmd.Parameters.AddWithValue("@Picture", picture ?? (object)DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Update existing staff record
        public void update(int id, string name, string email, string contact,
            string qualification, string experience)
        {
            using (SqlCommand cmd = new SqlCommand(@"UPDATE Staff 
                SET Name=@Name, Email=@Email, Contact=@Contact, 
                    Qualification=@Qualification, Experience=@Experience 
                WHERE Id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Qualification", qualification);
                cmd.Parameters.AddWithValue("@Experience", experience);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Update staff record with picture
        public void updateWithPicture(int id, string name, string email, string contact,
            string qualification, string experience, string picture)
        {
            using (SqlCommand cmd = new SqlCommand(@"UPDATE Staff 
                SET Name=@Name, Email=@Email, Contact=@Contact, 
                    Qualification=@Qualification, Experience=@Experience, Picture=@Picture 
                WHERE Id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Qualification", qualification);
                cmd.Parameters.AddWithValue("@Experience", experience);
                cmd.Parameters.AddWithValue("@Picture", picture ?? (object)DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Delete staff record
        public void delete(int id)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Staff WHERE Id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Select all staff records
        public DataSet select()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Staff", con))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        // Select a single staff record by id
        public DataSet selectid(int id)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Staff WHERE Id=@Id", con))
            {
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
