using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HWWilson
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SetFocus(Login1.FindControl("Password"));
            if (!IsPostBack)
            {
                Login1.UserName = "Trade";
            }
        }
        protected void Login1_Authenticate(object sender, EventArgs e)
        {

            int userId = 0;
            string roles = string.Empty;
            Session["name"] = string.Empty;
            SqlConnection ConnHWW = new SqlConnection("Data Source=BUNNY-TOSH;Initial Catalog=HWW;Integrated Security=True");

            {

                using (SqlCommand cmd = new SqlCommand("Validate_User_Roles"))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", Login1.UserName);
                    cmd.Parameters.AddWithValue("@Password", Login1.Password);
                    cmd.Connection = ConnHWW;
                    ConnHWW.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    try
                    {
                        userId = Convert.ToInt32(reader["userID"]);
                    }
                    catch
                    {
                        userId = Convert.ToInt32(reader[""]);
                    }
                    try
                    {
                        Session["roles"] = reader["roles"].ToString();
                    }
                    catch
                    {
                        Session["roles"] = null;
                    }

                    try
                    {
                        Session["name"] = Convert.ToString(reader["name"]);
                    }
                    catch
                    {
                        Session["name"] = null;
                    }
                    ConnHWW.Close();


                    switch (userId)
                    {

                        case -1:

                            Login1.FailureText = "Username and/or password is incorrect.";

                            break;


                        default:

                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now, DateTime.Now.AddMinutes(2880), Login1.RememberMeSet, roles, FormsAuthentication.FormsCookiePath);
                            string hash = FormsAuthentication.Encrypt(ticket);
                            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                            Session["userid"] = userId;
                            if (ticket.IsPersistent)
                            {
                                cookie.Expires = ticket.Expiration;
                            }
                            Response.Cookies.Add(cookie);

                            Response.Redirect(FormsAuthentication.GetRedirectUrl(Login1.UserName, Login1.RememberMeSet));
                            break;

                    }

                }

            }
        }

    }
}