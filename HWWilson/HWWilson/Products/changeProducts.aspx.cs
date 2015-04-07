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
    public partial class changeProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindDataGV();
            }
        }// closes the Page_Load

        private void BindDataGV()
        { // populates a gridview with all categories
            Products myProds = new Products();
            SqlDataReader myDataReader = myProds.GetProduct();
            GVEditProducts.DataSource = myDataReader;
            GVEditProducts.DataBind();
        }//Closes fillEditProds

        protected void GVEditProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GVEditProducts.EditIndex = -1;
            BindDataGV();
        }

        protected void GVEditProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVEditProducts.EditIndex = e.NewEditIndex;
            BindDataGV();   
        }

        protected void GVEditProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GVEditProducts.Rows[e.RowIndex];
            TextBox txtProductBarcode = (TextBox)row.FindControl("txtProductBarcode");
            TextBox txtproduct_name = (TextBox)row.FindControl("txtproduct_name");
            TextBox txtproduct_min_level = (TextBox)row.FindControl("txtproduct_min_level");
            TextBox txtprod_stock_level = (TextBox)row.FindControl("txtprod_stock_level");
            TextBox txtprod_stock_code = (TextBox)row.FindControl("txtprod_stock_code");
            TextBox txtprod_cat_desc = (TextBox)row.FindControl("tprod_cat_desc");
            DropDownList DDLCat = (DropDownList)row.FindControl("DDLCat");
            Products changeProd = new Products();
            changeProd.prodID = Convert.ToInt16(GVEditProducts.DataKeys[e.RowIndex].Value.ToString());
            changeProd.prodBar = Convert.ToInt64(txtProductBarcode.Text);
            changeProd.productName = Convert.ToString(txtproduct_name.Text);
            changeProd.prodMinLevel = Convert.ToInt32(txtproduct_min_level.Text);
            changeProd.prodStockLevel = Convert.ToInt32(txtprod_stock_level.Text);
            changeProd.prodStockCode = Convert.ToString(txtprod_stock_code.Text);
            changeProd.prodCatID = Convert.ToInt32(DDLCat.SelectedValue);
            changeProd.AmendProduct();
            String errNumber = Convert.ToString(changeProd.errNo);

            if (changeProd.errNo.Equals(2627) && (changeProd.errMsg.Contains("Error in Adding barcode")))
            {
                TxtAmendConf.Text = "The barcode already exists in the database";
                          
            }
            else if (changeProd.errNo.Equals(2627) && (changeProd.errMsg.Contains("Error in Adding product")))
            {
                TxtAmendConf.Text = "The stock code already exists in the database";
                
            }
            else
            {
                //displays a confirmation that the product has been added to the database
                TxtAmendConf.Text = changeProd.errNo + "The product has been successfully added to the database";
                
            }
            updategrid();

           
        }

        private void updategrid()
        {
            GVEditProducts.EditIndex = -1;
            BindDataGV();
        }
    }// Closes changeProducts
}// Closes the namespace
