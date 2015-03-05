<%@ Page Title="Add Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addEmployee.aspx.cs" Inherits="HWWilson.HWWilson.Employee.addEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%:Session["name"] %>Add a new Employee</h1>

        <%-- This is where the main content of the page is placed. The header and Footer are in the Site.Master file--%>
        <asp:Label ID="LblEmpFName" Width="150" runat="server" Text="Employee First Name"></asp:Label>
       <asp:TextBox ID="TxtEmpFName" Width="150" runat="server"></asp:TextBox><br />
        <asp:Label ID="LblSurname" Width="150" runat="server" Text="Employee Surname"></asp:Label>
        <asp:TextBox ID="TxtSurname" Width="150" runat="server"></asp:TextBox><br />
        <asp:Label ID="LblRole" Width="150" runat="server" Text="Job Role"></asp:Label>
        <asp:DropDownList ID="DDLEmpRole" Width="150" runat="server" DataSourceID="SqlDataSource1" DataTextField="role_description" DataValueField="role_id"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HWWConnectionString %>" 
            SelectCommand="SELECT [role_id], [role_description] FROM [tRole]"></asp:SqlDataSource>      
        <br />
        <asp:Label ID="LblUsername" Width="150" runat="server" Text="Employee User Name"></asp:Label>
        <asp:TextBox ID="TxtUsername" Width="150" runat="server"></asp:TextBox><br />
         <asp:Label ID="LblPassword" Width="150" runat="server" Text="Employee Password"></asp:Label>
        <asp:TextBox ID="TxtPassword" Width="150" runat="server"></asp:TextBox><br />
        <asp:Button ID="EmpSubmit" OnClick="EmpSubmit_Click" runat="server" Text="Create Employee" /><br />
        <asp:TextBox ID="TxtConfirm" Width="600" visible="false" runat  ="server"></asp:TextBox><br />
</asp:Content>
