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
    public partial class bookout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDdljobNo();
                fillJobDesc();
            }
            TxtBar.Focus();

        } // Closes Page_Load

        //on page load the job number drop down contain all job from the database
        protected void fillDdljobNo()
        { // on page load the Drop down list is populated with all job numbers from the database
            JobNumbers myJob = new JobNumbers();
            SqlDataReader drJob = myJob.GetJobNo();
            DDLjobNo.DataSource = drJob;
            DDLjobNo.DataTextField = "job_number";
            DDLjobNo.DataValueField = "job_Number";
            DDLjobNo.DataBind();
        }

        /*
         On page load a gridview is populated that shows the job number and job decription for all jobs.
         * The user can review the gridview to identify the job nuumber if unkown
         */
        protected void fillJobDesc()
        { // populates a gridview with all job numbers
            JobNumbers myJob = new JobNumbers();
            GVjobDesc.DataSource = myJob.GetJobNo();
            GVjobDesc.DataBind();
        }

        /*
         * When the user selects a job number from the drop down list the gridview updates to show that one job
         */
        protected void DDLjobNo_SelectedIndexChanged(object sender, EventArgs e)
        { // When the user selects a job number the gridview shows the description for that site
            JobNumbers myJob = new JobNumbers();
            myJob.jobNo = Convert.ToString(DDLjobNo.SelectedValue);
            GVjobDesc.DataSource = myJob.GetJobNoFilter();
            GVjobDesc.DataBind();
            focus();
        }
        //Sets the focus to the barcode field to enure the barcode is always read into the system
        protected void focus()
        {
            TxtBar.Focus();
        }

        //if the user has selected a job they can push a button that will display all the jobs in the gridview
        protected void BtnAllJob_Click(object sender, EventArgs e)
        {
            fillJobDesc();
        }

        /* When a barcode is entered it checks if the session variable is null, if it is create a new order
         * otherwise add products to the current order
         */
        protected void NewBarcode(object sender, EventArgs e)
        {
            if (Session["sordernbr"] == null)
            {
                Order newOrder = new Order();
                newOrder.ordEmp = Convert.ToInt16(Session["userid"]);
                newOrder.jobNo = Convert.ToString(DDLjobNo.SelectedValue);
                newOrder.CreateNewOrder();
                (Session["sordernbr"]) = newOrder.sordNo;
                updateOrder();
            }
            else
            {
                updateOrder();
            }
        }


        protected void updateOrder()
        {
            Order addOrder = new Order();
            addOrder.sordNo = Convert.ToInt32(Session["sordernbr"]);
            addOrder.barcode = Convert.ToInt64(TxtBar.Text);
            addOrder.ordQty = 1;
            TxtBar.Text = null;
            addOrder.addOrderLines();
            fillOrderDetails();     

        }////closes the updateOrder class

        /* When the user seclects remove from the products gridview the product will be
         * removed from OrderDetails Table.
         */
        protected void GVprodsRemoveProduct(object sender, EventArgs e)
        { // Identies the row number that has been selected
            GridViewRow row = GVprods.SelectedRow;
            Order remove = new Order();
            remove.sordNo = Convert.ToInt32(Session["sordernbr"]);
            remove.prodId = Convert.ToInt32(row.Cells[1].Text);
            /* the product id is the 2nd cell of the selected row (starts at 0). order number and product are passed
             * to the removeOrderLines() method in HWW,CS
             */
            remove.removeOrderLines();
            //the product is removed and the grdiview is updated
            fillOrderDetails(); 

         }

        protected void fillOrderDetails()
        {
            Order dispOrder = new Order();
            dispOrder.sordNo = Convert.ToInt32(Session["sordernbr"]);
            GVprods.DataSource = dispOrder.getOrderDetails();
            GVprods.DataBind(); 
    }

        protected void ButBookout_Click(object sender, EventArgs e)
        {

        }

        protected void ButCancel_Click(object sender, EventArgs e)
        {

        }

        

    }//closed class bookout
}// closed namespace