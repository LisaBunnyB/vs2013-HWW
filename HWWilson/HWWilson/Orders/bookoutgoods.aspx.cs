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
            JobNumbers myJob = new JobNumbers();
            SqlDataReader drJob = myJob.GetJobNo();
            DDLjobNo.DataSource = drJob;
            DDLjobNo.DataTextField = "job_number";
            DDLjobNo.DataValueField = "job_description";
            DDLjobNo.DataBind();
            
        }

        protected void DDLjobNo_SelectedIndexChanged(object sender, EventArgs e)
        {
              TextBox1.Text = DDLjobNo.SelectedValue;
        }
    }
}