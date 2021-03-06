﻿using System;
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

        }// closes Page_load


        /* this method passes the barcode and product ID to the AddBarcodeToProduct method in the HWW.cs file 
         * to add the barcode to the database
         */
        protected void ButnConfBarcode_Click(object sender, EventArgs e)
        {
            /* the barcode scanner causes the page to act as though the Confirm add the barcode button has been clicked.
             * the page.valid will only try to pass the barcode details to the database once client side validation has been passed
             */
            if (Page.IsValid)
            {
                Products addBar = new Products();
                addBar.prodID = Convert.ToInt16(TxtProdID.Text);
                addBar.prodBar = Convert.ToInt64(TxtAddBarcode.Text);
                addBar.AddBarcodeToProduct();
                //If an error occurs when adding the barcode to the database then display the error messgae to the user
                if (addBar.errNo.Equals(2627) && (addBar.errMsg.Contains("Error in Adding barcode")))
                {
                    TxtAddBarcodeConfirmation.Text = "The barcode already exists in the database";
                    TxtAddBarcodeConfirmation.Visible = true;
                    TxtAddBarcodeConfirmation.ForeColor = System.Drawing.Color.Red;
                }
                else if (addBar.errNo.Equals(547))
                {
                    //If the product ID doesn't exist in the database then display the error messgae to the user
                    TxtAddBarcodeConfirmation.Text = "The product ID does not exists in the database";
                    TxtAddBarcodeConfirmation.Visible = true;
                    TxtAddBarcodeConfirmation.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    //displays a confirmation that the product has been added to the database
                    TxtAddBarcodeConfirmation.Text = "The product barcode " + TxtAddBarcode.Text +
                        " has been added to product ID " + TxtProdID.Text + " in the database";
                    TxtAddBarcodeConfirmation.Visible = true;
                    TxtAddBarcodeConfirmation.ForeColor = System.Drawing.Color.Black;
                    TxtAddBarcode.Text = string.Empty;
                    TxtProdID.Text = string.Empty;
                }
            }//Closes if Page is valid
        }

        protected void ButCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HWWilson/Products/addBarcode.aspx");
        }// closes ButnConfBarcode_Click

    }//closes addBarcode
}//Closes namespace
