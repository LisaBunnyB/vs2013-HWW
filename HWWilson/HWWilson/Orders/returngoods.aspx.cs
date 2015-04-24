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
    public partial class returngoods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //The first time the page loads the two methods are called
            if (!IsPostBack)
            {
                fillDdljobNo2();
                fillJobDesc2();
            }
            TxtBar.Focus();
        }
        //on page load the job number drop down contain all job from the database
        protected void fillDdljobNo2()
        { // on page load the Drop down list is populated with all job numbers from the database
            JobNumbers myJob = new JobNumbers();
            SqlDataReader drJob = myJob.GetJobNo();
            DDLjobNos.DataSource = drJob;
            DDLjobNos.DataTextField = "job_number";
            DDLjobNos.DataValueField = "job_Number";
            DDLjobNos.DataBind();
        }

        /*
         On page load a gridview is populated with the job number and job decription for all jobs.
         * The user can review the gridview to identify the job nuumber if unknown
         */
        protected void fillJobDesc2()
        { // populates a gridview with all job numbers
            JobNumbers myJob = new JobNumbers();
            GVjobDesc2.DataSource = myJob.GetJobNo();
            GVjobDesc2.DataBind();
        }

        // When the user selects a job number from the drop down list the gridview updates to show that one job number
        protected void DDLjobNos_SelectedIndexChanged(object sender, EventArgs e)
        { // When the user selects a job number the gridview shows the description for that site
            JobNumbers myJob = new JobNumbers();
            myJob.jobNo = Convert.ToString(DDLjobNos.SelectedValue);
            GVjobDesc2.DataSource = myJob.GetJobNoFilter();
            GVjobDesc2.DataBind();
            focus();
            // If the job number is changed after the order has been created call the updateJobNo();
            if (Session["sordernbr"] != null)
            {
                updateJobNo2();
            }

        }

        /*
         * When the user selects a job number from the drop down list after the orderId has been created then call
         * the changeOrderJob() method to update the job number in the order table for that order ID.
         */
        protected void updateJobNo2()
        {
            Order jobNo = new Order();
            jobNo.sordNo = Convert.ToInt32(Session["sordernbr"]);
            jobNo.jobNo = Convert.ToString(DDLjobNos.SelectedValue);
            jobNo.changeOrderJob();
            fillOrderDetails2();

        }////closes the updateJobNo class

        //Sets the focus to the barcode field to enure the barcode is always read into the system
        protected void focus()
        {
            TxtBar.Focus();
        }

        //if the user has selected a job they can push a button that will display all the jobs in the gridview
        protected void BtnAllJob_Click(object sender, EventArgs e)
        {
            fillJobDesc2();
        }

        /* When a barcode is entered it checks if the session variable is null, if it is create a new order
         * otherwise add products to the current order
         */
        protected void NewBarcode2(object sender, EventArgs e)
        {
            if (Session["sordernbr"] == null)
            {
                Order newOrder = new Order();
                newOrder.ordEmp = Convert.ToInt16(Session["userid"]);
                newOrder.jobNo = Convert.ToString(DDLjobNos.SelectedValue);
                newOrder.CreateNewOrder();
                (Session["sordernbr"]) = newOrder.sordNo;
                updateOrder2();
            }
            else
            {
                updateOrder2();
            }
        }

        // adds products to the order, passes the orderID barcode and negative qty to the addOrderLines() method in the HWW.cs
        protected void updateOrder2()
        {
            Order addOrder = new Order();
            addOrder.sordNo = Convert.ToInt32(Session["sordernbr"]);
            addOrder.barcode = Convert.ToInt64(TxtBar.Text);
            addOrder.ordQty = -1;
            TxtBar.Text = null;
            addOrder.addOrderLines();
            fillOrderDetails2();

        }////closes the updateOrder class

        /* When the user selects remove from the products gridview the product will be
         * removed from OrderDetails Table.
         */
        protected void GVprodsRemoveProduct2(object sender, EventArgs e)
        { // Identies the row number that has been selected
            GridViewRow row = GVprods2.SelectedRow;
            Order remove = new Order();
            remove.sordNo = Convert.ToInt32(Session["sordernbr"]);
            remove.prodId = Convert.ToInt32(row.Cells[1].Text);
            /* the product id is the 2nd cell of the selected row (starts at 0). order number and product are passed
             * to the removeOrderLines() method in HWW,CS
             */
            remove.removeOrderLines();
            //the product is removed and the grdiview is updated
            fillOrderDetails2();

        }

        /*this method updates the GVprods grdiview with all the products they are returned from site
       * each time a barcode is scanned or a products is removed from the gridview
       */
        protected void fillOrderDetails2()
        {
            Order dispOrder = new Order();
            dispOrder.sordNo = Convert.ToInt32(Session["sordernbr"]);
            GVprods2.DataSource = dispOrder.getOrderDetails();
            GVprods2.DataBind();
        }

        /*the order and order details are updated each time a barcode is scanned. When the user clicks the confirm order button
        * the order number is passed to the removeOrder() method in the HWW.cs file, if no products exists in the order details table
        * the order ID is removed from the orders table.
        */
        protected void ButRturn_Click(object sender, EventArgs e)
        {
            Order remove = new Order();
            remove.sordNo = Convert.ToInt32(Session["sordernbr"]);
            remove.removeOrder();
            Response.Redirect("~/HWWilson/Orders/continue-logout.aspx");
            Session.Remove("sordernbr");
        }

        /* if the user clicks the cancel order button the order ID is passed to the cancelOrder() in the HWW.cs file
         * the order id is removed from the order table and the products are removed from the tOrderDetail table
         */
        protected void ButCancelreturn_Click(object sender, EventArgs e)
        {
            Order remove = new Order();
            remove.sordNo = Convert.ToInt32(Session["sordernbr"]);
            remove.cancelOrder();
            Response.Redirect("~/HWWilson/Orders/continue-logout.aspx");
            Session.Remove("sordernbr");
        }

    }//closed class return good
}// closed namespace