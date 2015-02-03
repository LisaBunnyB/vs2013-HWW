using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using HWWilson.App_Code;


namespace HWWilson
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string roles;
            string username = TxtUserName.Text.Trim();
            if (DBHelper.CheckUser(username, TxtPass.Text.Trim()) == true)
            {
                //These session values are just for demo purpose to show the user details on master page
                Session["User"] = username;
                roles = DBHelper.GetUserRoles(username);
                Session["Roles"] = roles;

                //Let us now set the authentication cookie so that we can use that later.
                FormsAuthentication.SetAuthCookie(username, false);

                //Login successful lets put him to requested page
                string returnUrl = Request.QueryString["ReturnUrl"] as string;

                if (returnUrl != null)
                {
                    Response.Redirect(returnUrl);
                }
                else
                {
                    //no return URL specified so lets kick him to home page
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Label1.Text = "Login Failed";
            }

        }
    }
}