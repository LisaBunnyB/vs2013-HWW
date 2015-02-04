using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HWWilson.HWWilson.Employee
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void ButnViewEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewEmployees.aspx");
        }

        protected void ButnChgEmp_Click(object sender, EventArgs e)
        {
             Response.Redirect("changeEmployee.aspx");
        }

        protected void ButnAddEmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("addEmployee.aspx");
        } 
    }
}