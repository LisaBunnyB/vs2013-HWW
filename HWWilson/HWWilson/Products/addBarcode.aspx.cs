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
    public partial class addBarcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
                fillDDLSelectCat();
                fillProdCat();
        
        }// closes Page_load

        protected void fillDDLSelectCat()
        { // on page load the Drop down list is populated with all product categories from the database
            Products allProducts = new Products();
            SqlDataReader ddlCat = allProducts.GetStockCode();
            DDLSelectCat.DataSource = ddlCat;
            DDLSelectCat.DataTextField = "prod_cat_desc";
            DDLSelectCat.DataValueField = "prod_cat_id";
            DDLSelectCat.DataBind();
            DDLSelectCat.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        }// closes fillDDLSelectCat()

        protected void fillProdCat()
        { // populates a gridview with all categories
            Products myProds = new Products();
            SqlDataReader myDataReader = myProds.GetProduct();
            GVProds2.DataSource = myDataReader;
            GVProds2.DataBind();
        }

        protected void DDLSelectCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Products catProd = new Products();
            catProd.prodStockCode = Convert.ToString(DDLSelectCat.SelectedValue);
            GVProds2.DataSource = catProd.GetStockCat();
            GVProds2.DataBind();
        }// closes DDLSelectCat_SelectedIndexChanged


        protected void ButnShowAllProds_Click(object sender, EventArgs e)
        {
            fillProdCat();
            TxtProductDesc.Text = string.Empty;
         
            DDLSelectCat.ClearSelection();

        }

        protected void TxtProductDesc_TextChanged(object sender, EventArgs e)
        {  // When the user enters a product description products like the decsription are returned from the databsse
            Products prodName = new Products();
            prodName.productName = Convert.ToString(TxtProductDesc.Text);
            GVProds2.DataSource = prodName.GetProdName();
            GVProds2.DataBind();

        }

        

        

    }//closes addBarcode
}//Closes namespace
