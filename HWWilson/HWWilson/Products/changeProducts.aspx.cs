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

        // on page load populates a gridview with all products
        private void BindDataGV()
        { 
            Products myProds = new Products();
            SqlDataReader myDataReader = myProds.GetProduct();
            GVEditProducts.DataSource = myDataReader;
            GVEditProducts.DataBind();
        }//Closes BindDataGV()

        /* if the user clicks the cancel button from the edit mode on the gridview this cancels the edit process and displays
         * a message that no product details have been amended.
         * http://www.ezzylearning.com/tutorial/editing-data-using-asp-net-gridview-control
         */
        protected void GVEditProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GVEditProducts.EditIndex = -1;
            BindDataGV();
            TxtAmendConf.Text = "No Product Details have been  amended";
            TxtAmendConf.Visible = true;
        }

        // When the users clicks edit on a row in the gridview the row opens for edit and the mouse is placed in the barcode field
        protected void GVEditProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVEditProducts.EditIndex = e.NewEditIndex;
            BindDataGV();
            GVEditProducts.Rows[e.NewEditIndex].FindControl("txtProductBarcode").Focus();
            TxtAmendConf.Visible = false;
            TxtAmendError.Visible = false;

        }

        /* then the users has amended details in the gridview and selected the update button all the product details
         * are captured from the gridview and passed to the AmendProduct() method in the HWW.cs file
         * the details are then updated in the database
         */
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
            //if the database already contains the barcode entered in the gridview an error is returned and the barcode is not updated
            if (changeProd.errNo.Equals(2627) && (changeProd.errMsg.Contains("Error in Adding barcode")))
            {
                TxtAmendError.Text = "The barcode already exists in the database";
                TxtAmendError.Visible = true;
                TxtAmendConf.Visible = false;
                          
            }
            //if the stock code already exists in the database an error is returned and the stock code is not updated
            else if (changeProd.errNo.Equals(2627) && (changeProd.errMsg.Contains("Error in Adding product")))
            {
                TxtAmendError.Text = "The stock code already exists in the database";
                TxtAmendError.Visible = true;
                TxtAmendConf.Visible = false;
            }
            else
            {
                //displays a confirmation that the product has been added to the database
                TxtAmendConf.Text = "The product details have been successfully changed in the database";
                TxtAmendConf.Visible = true;
                TxtAmendError.Visible = false;
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
