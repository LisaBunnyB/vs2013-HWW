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
        protected void fillStockCat()
        { // populates a gridview with all categories
            Products myProds = new Products();
            SqlDataReader myDataReader = myProds.GetProduct();
            gvProducts.DataSource = myDataReader;
            gvProducts.DataBind();
        }


        //on page load the stock category drop down contain all categories from the database
        protected void fillDDLStockCat()
        { // on page load the Drop down list is populated with all product categories from the database
            Products allProducts = new Products();
            SqlDataReader ddlCat = allProducts.GetStockCode();
            DDLStockCat.DataSource = ddlCat;
            DDLStockCat.DataTextField = "prod_cat_desc";
            DDLStockCat.DataValueField = "prod_cat_id";
            DDLStockCat.DataBind();
            DDLStockCat.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        }

        protected void DDLStockCat_SelectedIndexChanged(object sender, EventArgs e)
        { // When the user selects a job number the gridview shows the description for that site
            Products catProd = new Products();
            catProd.prodStockCode = Convert.ToString(DDLStockCat.SelectedValue);
            gvProducts.DataSource = catProd.GetStockCat();
            gvProducts.DataBind();
             }

        protected void BtnAllCats_Click(object sender, EventArgs e)
        {
            fillStockCat();
        }

        protected void TxtProdDesc_TextChanged(object sender, EventArgs e)
        {
            // When the user enters a product description products like are returned
            Products prodName = new Products();
            prodName.productName = Convert.ToString(TxtProdDesc.Text);
            gvProducts.DataSource = prodName.GetProdName();
            gvProducts.DataBind();
        }
    }
}

