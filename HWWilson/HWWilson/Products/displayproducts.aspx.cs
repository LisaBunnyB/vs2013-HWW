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

            if (!IsPostBack)
            {
                fillDDLStockCat();
                fillStockCat();
            }
        }
        // when the page loads the gridview displays all products.
        protected void fillStockCat()
        { // populates a gridview with all categories
            Products myProds = new Products();
            SqlDataReader myDataReader = myProds.GetProduct();
            gvProducts.DataSource = myDataReader;
            gvProducts.DataBind();
        }


        // on page load the Drop down list is populated with all product categories from the database
        protected void fillDDLStockCat()
        {
            Products allProducts = new Products();
            SqlDataReader ddlCat = allProducts.GetStockCode();
            DDLStockCat.DataSource = ddlCat;
            DDLStockCat.DataTextField = "prod_cat_desc";
            DDLStockCat.DataValueField = "prod_cat_id";
            DDLStockCat.DataBind();
            DDLStockCat.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        }

        // When the user selects a product category from the Drop down list the gridview is updated to only show products of that category
        protected void DDLStockCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Products catProd = new Products();
            catProd.prodStockCode = Convert.ToString(DDLStockCat.SelectedValue);
            gvProducts.DataSource = catProd.GetStockCat();
            gvProducts.DataBind();
        }
        // When the user clicks the button show all products the gridview updates to show all products.
        protected void BtnAllCats_Click(object sender, EventArgs e)
        {
            fillStockCat();
            TxtBarcodeSearch.Text = string.Empty;
        }

        // if the user enters a product description the gridview is updated to show products with a similar name
        protected void TxtProdDesc_TextChanged(object sender, EventArgs e)
        {
            Products prodName = new Products();
            prodName.productName = Convert.ToString(TxtProdDesc.Text);
            gvProducts.DataSource = prodName.GetProdName();
            gvProducts.DataBind();
        }

        // When the user enters a barcode the matching product is returned from the database and displayed in the gridview
        protected void TxtBarcodeSearch_TextChanged(object sender, EventArgs e)
        {   
            Products prod = new Products();
            prod.prodBar = Convert.ToInt64(TxtBarcodeSearch.Text);
            gvProducts.DataSource = prod.GetProductByBarcode();
            gvProducts.DataBind();


        }
    }
}

