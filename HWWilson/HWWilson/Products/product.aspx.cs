using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HWWilson.HWWilson.Products
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButnAddPrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("addProduct.aspx");
        }

        protected void ButnViewPrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("displayproducts.aspx");
        }

        protected void ButnChgPrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("changeProducts.aspx");
        }
    }
}