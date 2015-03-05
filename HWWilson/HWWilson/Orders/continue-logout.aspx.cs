﻿using System;
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
            Session.Remove("sordernbr");
            
        }

        protected void ButNewOrder_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("~/HWWilson/Orders/bookout.aspx"); 
            
        }

        protected void ButLogOut_Click(object sender, EventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
            Session.Remove("roles");
            Session.Remove("name");
            Session.Remove("userid");
            Response.Redirect("~/Login.aspx"); 
        }
            
    }
}