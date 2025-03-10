using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Admin_learning
{
    public partial class user : System.Web.UI.Page
    {
        UsersClass usersClass = new UsersClass(); // Use the correct class name

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        // Load Users into GridView
        private void LoadUsers()
        {
            DataTable dt = usersClass.GetAllUsers();
            if (dt.Rows.Count > 0)
            {
                GridViewUsers.DataSource = dt;
                GridViewUsers.DataBind();
            }
            else
            {
                GridViewUsers.DataSource = null;
                GridViewUsers.DataBind();
            }
        }

        // Delete User
        protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);
            usersClass.DeleteUser(userID);
            LoadUsers(); // Refresh GridView after deletion
        }
    }
}
