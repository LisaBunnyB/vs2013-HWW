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
    public partial class addProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDDLProdCat();

            }

        }// closes Page_load

        //on page load the stock category drop down contain all categories from the database
        protected void fillDDLProdCat()
        { // on page load the Drop down list is populated with all job numbers from the database
            Products allProducts = new Products();
            SqlDataReader ddlCat = allProducts.GetStockCode();
            DDLProdCat.DataSource = ddlCat;
            DDLProdCat.DataTextField = "prod_cat_desc";
            DDLProdCat.DataValueField = "prod_cat_id";
            DDLProdCat.DataBind();
            DDLProdCat.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        }

        protected void addNewProduct(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Products addProd = new Products();
                addProd.productName = Convert.ToString(TextProdName.Text);
                addProd.prodBar = Convert.ToInt64(TextProdBarcode.Text);
                addProd.prodMinLevel = Convert.ToInt32(TextProdMinLevel.Text);
                addProd.prodStockLevel = Convert.ToInt32(TextProdStockLevel.Text);
                addProd.prodStockCode = Convert.ToString(TextProdStockCode.Text);
                addProd.prodCatID = Convert.ToInt32(DDLProdCat.SelectedValue);
                addProd.AddNewProduct();

                String errNumber = Convert.ToString(addProd.errNo);

                if (addProd.errNo.Equals(2627) && (addProd.errMsg.Contains("Error in Adding barcode")))
                {
                    LblDupBarcode.Text = "The barcode already exists in the database";
                    LblDupStockCode.Text = string.Empty;
                }
                else if (addProd.errNo.Equals(2627) && (addProd.errMsg.Contains("Error in Adding product")))
                {
                    LblDupStockCode.Text = "The stock code already exists in the database";
                    LblDupBarcode.Text = string.Empty;
                }
                else
                {
                    //displays a confirmation that the product has been added to the database
                    TxtProdAdded.Text = "The product " + addProd.productName + " has been successfully added to the database";
                                   
                    LblDupBarcode.Text = string.Empty;
                    LblDupStockCode.Text = string.Empty;
                    TxtProdAdded.Visible = true;
                    TextProdName.Text = string.Empty;
                    TextProdBarcode.Text = string.Empty;
                    TextProdMinLevel.Text = string.Empty;
                    TextProdStockLevel.Text = string.Empty;
                    TextProdStockCode.Text = string.Empty;
                    DDLProdCat.ClearSelection();
                }
            } //closes if page is valid
        }//closes the addNewProduct class

        protected void CancelProd_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/HWWilson/Products/Add-Product.aspx");
           
        }
                       
    } //closes the addProduct class
} // closes the namespace