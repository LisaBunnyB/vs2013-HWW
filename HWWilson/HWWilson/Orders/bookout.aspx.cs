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
            TxtBar.Focus();
        }
        protected void BtnAllJob_Click(object sender, EventArgs e)
        {
            fillJobDesc();
        }

    }
}