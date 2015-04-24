using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HWWilson.HWWilson.Orders
{
    public partial class continue_logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // removes the previous orderId from the session variable
            Session.Remove("sordernbr");
            
        }

        protected void ButNewOrder_Click(object sender, EventArgs e)
        {
           //if the user clicks create another order they are taken to the bookout.aspx page
            Response.Redirect("~/HWWilson/Orders/bookout.aspx"); 
            
        }

        protected void ButLogOut_Click(object sender, EventArgs e)
        {
            //if the user clicks log out they are taken to the bookout.aspx page, the role, bname and userid are removed from session variables
            Context.GetOwinContext().Authentication.SignOut();
            Session.Remove("roles");
            Session.Remove("name");
            Session.Remove("userid");
            Response.Redirect("~/Login.aspx"); 
        }
            
    }
}