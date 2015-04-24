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
            // if the user clicks the view emoployees button the are taken to the viewEmployees.aspx page
            Response.Redirect("viewEmployees.aspx");
        }

        protected void ButnChgEmp_Click(object sender, EventArgs e)
        {
            // if the user clicks the change emoployees button the are taken to the changeEmployee.aspx page
             Response.Redirect("changeEmployee.aspx");
        }

        protected void ButnAddEmp_Click(object sender, EventArgs e)
        {
            // if the user clicks the add emoployees button the are taken to the addEmployee.aspx page
            Response.Redirect("addEmployee.aspx");
        } 
    }
}