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
            string name = Convert.ToString(TxtEmpFName.Text);
            string surname = Convert.ToString(TxtSurname.Text);
            Employees addEmp = new Employees();
            addEmp.fName = Convert.ToString(TxtEmpFName.Text);
            addEmp.Sname = Convert.ToString(TxtSurname.Text);
            addEmp.roleId = Convert.ToInt32(DDLEmpRole.SelectedValue);
            addEmp.userName = Convert.ToString(TxtUsername.Text);
            addEmp.password = Convert.ToString(TxtPassword.Text);
            addEmp.AddNewEmp();
            TxtConfirm.Visible = true;
            TxtConfirm.Text = "The user " + name + " " + surname + " has been successfully added to the database";
            TxtEmpFName.Text = "";
            TxtSurname.Text = "";
            TxtUsername.Text = "";
            TxtPassword.Text = "";
        }
    }
}

