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

        // if the user clicks the add products button the are taken to the addProduct.aspx page
        protected void ButnAddPrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("addProduct.aspx");
        }

        // if the user clicks the view products button the are taken to the displayproducts.aspx page
        protected void ButnViewPrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("displayproducts.aspx");
        }

        // if the user clicks the change product details button the are taken to the changeProducts.aspx page
        protected void ButnChgPrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("changeProducts.aspx");
        }

        // if the user clicks the add a barcode button the are taken to the addBarcode.aspx page
        protected void ButnAddBarcode_Click(object sender, EventArgs e)
        {
            Response.Redirect("addBarcode.aspx");
        }
        
        
    }
}