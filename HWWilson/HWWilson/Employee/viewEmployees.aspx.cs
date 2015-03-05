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

namespace HWWilson.HWWilson.Employee
{
    public partial class viewEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillEmployees();
        }

        protected void fillEmployees()
        { // populates a gridview with all orders numbers
            Employees allEmployees = new Employees();
            GVEmployee.DataSource = allEmployees.getEmployees();
            GVEmployee.DataBind();
        }// closes the fillorders
    }
}