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

namespace HWWilson.HWWilson.Orders
{
    public partial class bookoutgoods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDdljobNo();
                fillJobDesc();
            }
            TxtBarcode.Focus();

        }


        protected void fillDdljobNo()
        { // on page load the Drop down list is populated with all job numbers from the database
            JobNumbers myJob = new JobNumbers();
            SqlDataReader drJob = myJob.GetJobNo();
            DDLjobNo.DataSource = drJob;
            DDLjobNo.DataTextField = "job_number";
            DDLjobNo.DataValueField = "job_Number";
            DDLjobNo.DataBind();
        }

        protected void fillJobDesc()
        { // populates a gridview with all job numbers
            JobNumbers myJob = new JobNumbers();
            GVjobDesc.DataSource = myJob.GetJobNo();
            GVjobDesc.DataBind();
        }

        protected void DDLjobNo_SelectedIndexChanged(object sender, EventArgs e)
        { // When the user selects a job number the gridview shows the description for that site
            JobNumbers myJob = new JobNumbers();
            myJob.jobNo = Convert.ToString(DDLjobNo.SelectedValue);
            GVjobDesc.DataSource = myJob.GetJobNoFilter();
            GVjobDesc.DataBind();
            focus();
        }

        protected void focus()
        {
            TxtBarcode.Focus();
        }

        protected void BtnAllJob_Click(object sender, EventArgs e)
        {
            fillJobDesc();
        }


        protected void TxtBarcode_TextChanged(object sender, EventArgs e)
        {// This gets the products details from the database when a barcode is scanned into the TxtBarcode text box
            Session["barcode"] = TxtBarcode.Text;
            TxtCode.Text = "" + Session["barcode"];
            SqlConnection myConn = new SqlConnection();
            string myConnectionString = "Data Source= BUNNY-TOSH;Initial Catalog=HWWilson;Integrated Security=True";

            myConn.ConnectionString = myConnectionString;

            // Build command object //
            string sql1;
            sql1 = "SELECT product_name, prod_barcode, prod_stock_level FROM tProduct WHERE prod_barcode=" + Session["barcode"];
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = sql1;
            myCommand.Connection = myConn;

            // Open the connection //
            myConn.Open();

            // Build and fill the dataReader //
            SqlDataReader myDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (myDataReader.Read() == true)
            {
                LblProdDetails.Text += "" + myDataReader["product_name"] + "<br />";
                LblProdQuantity.Text = "1" + "<br />";
            }   // end of loop

            myDataReader.Close();
            TxtBarcode.Text = " ";
        }
    }
}