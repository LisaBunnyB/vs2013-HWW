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
            if (!IsPostBack)
            {
                fillDDLSelectCat();
                fillProdCat();
            }
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



        protected void GVProds2_SelectedIndexChanged(object sender, EventArgs e)
        { // Identies the row number that has been selected on the gridview
            GridViewRow row = GVProds2.SelectedRow;
            Products catProd = new Products();
            catProd.prodID = Convert.ToInt16(row.Cells[0].Text);
            GVProds2.DataSource = catProd.GetProductByID();
            GVProds2.DataBind();
            GVProds3.DataSource = catProd.GetProductByID();
            GVProds3.DataBind();


        }// closes GVProds2_SelectedIndexChanged

        protected void ButnShowAllProds_Click(object sender, EventArgs e)
        {
            fillProdCat();
            TxtProductDesc.Text = string.Empty;
            TxtBarcodeSearch.Text = string.Empty;
            DDLSelectCat.ClearSelection();

        }

        protected void TxtProductDesc_TextChanged(object sender, EventArgs e)
        {  // When the user enters a product description products like the decsription are returned from the databsse
            Products prodName = new Products();
            prodName.productName = Convert.ToString(TxtProductDesc.Text);
            GVProds2.DataSource = prodName.GetProdName();
            GVProds2.DataBind();

        }

        protected void TxtBarcodeSearch_TextChanged(object sender, EventArgs e)
        {   // When the user enters a barcode the matching product is returned from the database
            Products prod = new Products();
            prod.prodBar = Convert.ToInt64(TxtBarcodeSearch.Text);
            GVProds2.DataSource = prod.GetProductByBarcode();
            GVProds2.DataBind();
            GVProds3.DataSource = prod.GetProductByBarcode();
            GVProds3.DataBind();

        }

        protected void TxtProdBarcode_TextChanged(object sender, EventArgs e)
        {

            
            TxtAddBarcodeConfirmation.Text = "The barcode " + " " + TxtProdBarcode.Text + "will be added to product ID ";


        }//closes TxtProdBarcode_TextChanged

    }//closes addBarcode
}//Closes namespace
