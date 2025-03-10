using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Admin_learning
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Stud_Name, Stud_Email, Image, Video FROM Lecturer ORDER BY Id DESC", conn))
                {
                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                gvLecturers.DataSource = dt;
                                gvLecturers.DataBind();
                                gvLecturers.Visible = true;
                            }
                            else
                            {
                                gvLecturers.Visible = false;
                                // Optionally show a message when no data is found
                                // lblNoData.Visible = true;
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        // Log the SQL-specific error
                        LogError(sqlEx);
                        ShowErrorMessage("A database error occurred. Please try again later.");
                    }
                    catch (Exception ex)
                    {
                        // Log the general error
                        LogError(ex);
                        ShowErrorMessage("An unexpected error occurred. Please try again later.");
                    }
                }
            }
        }

        private void ShowErrorMessage(string message)
        {
            // You can implement this to show error messages in your UI
            // For example, using a Label control or ClientScript
            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                $"alert('{message.Replace("'", "\\'")}');", true);
        }

        private void LogError(Exception ex)
        {
            // Implement proper error logging here
            // For example, log to a file, database, or monitoring service
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }
}