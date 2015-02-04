using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HWWilson.App_Code;

namespace HWWilson.HWWilson.Employee
{
    public partial class addEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EmpSubmit_Click(object sender, EventArgs e)
        {
            Employees addEmp = new Employees();
            addEmp.empId = Convert.ToInt64(TextEmpd.Text);
            addEmp.fName = Convert.ToString(TxtEmpFName.Text);
            addEmp.Sname = Convert.ToString(TxtSurname.Text);
            addEmp.roleId = Convert.ToInt32(DDLEmpRole.SelectedValue);
            addEmp.AddNewEmp();
        }
    }
}

