using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Admin_learning
{
    public partial class contact : System.Web.UI.Page
    {
        ContactManager contactManager = new ContactManager();

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
            DataTable dt = contactManager.GetAllUsers();
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
            int ContactID = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);
            contactManager.DeleteUser(ContactID);
            LoadUsers();
        }
    }
}
