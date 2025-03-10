using System;
using System.Web;

namespace Admin_learning
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Destroy session
            Session.Clear();
            Session.Abandon();
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1);

            // Redirect to login page
            Response.Redirect("login.aspx");
        }
    }
}
