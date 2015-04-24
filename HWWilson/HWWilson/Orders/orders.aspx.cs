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
    public partial class orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDdljobNo3();
                fillOrders();
            }
        }


        protected void fillOrders()
        { // populates a gridview with all orders numbers
            Order allOrders = new Order();
            GVOrders.DataSource = allOrders.getOrders();
            GVOrders.DataBind();
        }// closes the fillorders

        /* on page load the Drop down list is populated with all job numbers from the database
            * Uses the same method as the job number drop downn in bookout goods
            */
        protected void fillDdljobNo3()
        {
            JobNumbers myJob = new JobNumbers();
            SqlDataReader drJob = myJob.GetJobNo();
            DDLjobNos.DataSource = drJob;
            DDLjobNos.DataTextField = "job_number";
            DDLjobNos.DataValueField = "job_Number";
            DDLjobNos.DataBind();
            DDLjobNos.Items.Insert(0, new ListItem(String.Empty, String.Empty));

        }


        /*
         * When the user selects a job number from the drop down list the gridview updates to orders for that one job
         */
        protected void DDLjobNos_SelectedIndexChanged(object sender, EventArgs e)
        { // When the user selects a job number the gridview shows the description for that site
            Order myOrder = new Order();
            myOrder.jobNo = Convert.ToString(DDLjobNos.SelectedValue);
            GVOrders.DataSource = myOrder.getOrdersByJob();
            GVOrders.DataBind();
            DDLjobNos.SelectedValue = null;
        }
        //if the user click the button BtnAllOrders then the gridview displays all orders
        protected void BtnAllOrders_Click(object sender, EventArgs e)
        {
            fillOrders();
        }
    }
}