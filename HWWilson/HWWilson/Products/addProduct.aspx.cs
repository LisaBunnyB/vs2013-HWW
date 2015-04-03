using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HWWilson.App_Code;

namespace HWWilson
{
    public partial class addProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }// closes Page_load



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
                LblDupBarcode.Text = string.Empty;
                LblDupStockCode.Text = string.Empty;
                TxtProdAdded.Visible = true;
                TxtProdAdded.Text = "The product " + addProd.productName + " has been successfully added to the database";
                TextProdName.Text = string.Empty;
                TextProdBarcode.Text = string.Empty;
                TextProdMinLevel.Text = string.Empty;
                TextProdStockLevel.Text = string.Empty;
                TextProdStockCode.Text = string.Empty;
            }
            } //closes if page is valid
        }//closes the addNewProduct class
       
    } //closes the addProduct class
} // closes the namespace