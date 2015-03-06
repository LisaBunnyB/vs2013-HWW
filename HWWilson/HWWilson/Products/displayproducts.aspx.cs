using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HWWilson.App_Code;

namespace HWWilson
{
    public partial class displayproducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Products myProds = new Products();
            SqlDataReader myDataReader = myProds.GetProduct();
            gvProducts.DataSource = myDataReader;
            gvProducts.DataBind();
        }
    }
}

