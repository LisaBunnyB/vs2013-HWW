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

        }
        protected void Login1_Authenticate(object sender, EventArgs e)
        {

            int userId = 0;
            int role = 0;
            
            SqlConnection ConnHWW = new SqlConnection("Data Source=BUNNY-TOSH;Initial Catalog=HWW;Integrated Security=True");
         
            {

                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", Login1.UserName);                                        
                    cmd.Parameters.AddWithValue("@Password", Login1.Password);
                    cmd.Connection = ConnHWW;
                    ConnHWW.Open();

            userId = Convert.ToInt32(cmd.ExecuteScalar());
                    ConnHWW.Close();
                  }

                switch (userId)
                {

                    case -1:

                        Login1.FailureText = "Username and/or password is incorrect.";

                        break;

                   
                    default:

                        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);

                        break;

                }

            }

        }
    }
}
    