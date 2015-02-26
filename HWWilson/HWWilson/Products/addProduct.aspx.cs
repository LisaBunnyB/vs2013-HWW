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
            Products addProd = new Products();
            addProd.productName = Convert.ToString(TextProdName.Text);
            addProd.prodBar = Convert.ToInt64(TextProdBarcode.Text);
            addProd.prodMinLevel = Convert.ToInt32(TextProdMinLevel.Text);
            addProd.prodStockLevel = Convert.ToInt32(TextProdStockLevel.Text);
            addProd.prodStockCode = Convert.ToString(TextProdStockCode.Text);
            addProd.prodCatID = Convert.ToInt32(DDLProdCat.SelectedValue);
            addProd.AddNewProduct();


        }////closes the addNewProduct class
    } //closes the addProduct class
} // closes the namespace