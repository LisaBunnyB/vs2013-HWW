<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="HWWilson.HWWilson.Employee.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4"><h2>Add employee</h2>
            <p>To add a new employee with barcode</p>
            <%-- Create a button to add an employee --%>
            <asp:Button ID="ButnAddEmp" OnClick="ButnAddEmp_Click" runat ="server" Text="Add Employee" />
        </div>
        <div class="col-md-4"><h2>View all employee details</h2>
            <p>To view all employees details</p>
             <%-- Create a button to view employees --%>
            <asp:Button ID="ButnViewEmployee" runat="server" OnClick="ButnViewEmployee_Click" Text="View Employees" />
        </div>
        <div class="col-md-4"><h2>Change employee details</h2>
            <p>To change an employees details</p>
             <%-- Create a button to change employee --%>
            <asp:Button ID="ButnChgEmp" OnClick="ButnChgEmp_Click" runat ="server" Text="Change Employee" />
        </div>
     </div> <!-- closes the row -->   
</asp:Content>
