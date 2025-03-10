using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace my_project
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user input
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtNumber.Text.Trim();
                string msg = txtMessage.Text.Trim();

                // Validation: Ensure all fields are filled
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(msg))
                {
                    SetErrorMessage("All fields are required.");
                    return;
                }

                // Validate email format with regex
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(email, emailPattern))
                {
                    SetErrorMessage("Please enter a valid email address.");
                    return;
                }

                // Validate phone number (ensure it contains only digits, spaces, dashes, or parentheses)
                string phonePattern = @"^[\d\s\-\(\)]+$";
                if (!Regex.IsMatch(phone, phonePattern))
                {
                    SetErrorMessage("Please enter a valid phone number.");
                    return;
                }

                // Database operations
                bool success = SaveContactToDatabase(name, email, phone, msg);

                if (success)
                {
                    // Success message
                    lblMessage.Text = "Your message has been sent successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    // Clear input fields after successful submission
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                // Log detailed error message
                System.Diagnostics.Debug.WriteLine("Error in contact form: " + ex.ToString());
                SetErrorMessage("An error occurred while processing your request. Please try again later.");
            }
        }

        private bool SaveContactToDatabase(string name, string email, string phone, string message)
        {
            try
            {
                // Get database connection string from Web.config
                string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

                if (string.IsNullOrEmpty(connStr))
                {
                    Debug.WriteLine("Connection string 'db' not found in Web.config");
                    SetErrorMessage("Database configuration error. Please contact administrator.");
                    return false;
                }

                // Create database connection
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Define SQL query - make sure column names match your actual table structure
                    string query = @"
                        INSERT INTO Contact (Name, Email, Phone, Msg) 
                        VALUES (@Name, @Email, @Phone, @Msg)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = phone;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 1000).Value = message;
                        //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;

                        // Open connection
                        conn.Open();

                        // Execute command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Close connection
                        conn.Close();

                        // Check if any rows were affected
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL-specific error details
                Debug.WriteLine("SQL Error: " + sqlEx.ToString());

                if (sqlEx.Number == 4060) // Invalid database
                    SetErrorMessage("Database connection error. Please contact administrator.");
                else if (sqlEx.Number == 208) // Invalid object name (table doesn't exist)
                    SetErrorMessage("Database table not found. Please contact administrator.");
                else if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Unique constraint violation
                    SetErrorMessage("This email is already registered in our system.");
                else
                    SetErrorMessage("Database error: " + sqlEx.Message);

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("General DB Error: " + ex.ToString());
                SetErrorMessage("Database error: " + ex.Message);
                return false;
            }
        }

        private void SetErrorMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtNumber.Text = "";
            txtMessage.Text = "";
        }
    }
}