<%@ Page Title="Add Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addEmployee.aspx.cs" Inherits="HWWilson.HWWilson.Employee.addEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add a new Employee</h1>

        <%-- This is where the main content of the page is placed. The header and Footer are in the Site.Master file--%>
        <asp:Label ID="LblemplID" Width="150" runat="server" Text="Employee ID"></asp:Label>
        <asp:TextBox ID="TextEmpd" Width="150" runat="server"></asp:TextBox>
        <%--Validate the text box is not blank --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the employee ID" ControlToValidate="TextEmpd" CssClass="ErrorMsg" ForeColor="Red"></asp:RequiredFieldValidator><br />
       <asp:Label ID="LblEmpFName" Width="150" runat="server" Text="Employee First Name"></asp:Label>
       <asp:TextBox ID="TxtEmpFName" Width="150" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="LblSurname" Width="150" runat="server" Text="Employee Surname"></asp:Label>
        <asp:TextBox ID="TxtSurname" Width="150" runat="server"></asp:TextBox><br />
        <asp:DropDownList ID="DDLEmpRole" runat="server" DataSourceID="SqlDataSource1" DataTextField="role_description" DataValueField="role_id"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HWWilsonConnectionString %>" SelectCommand="SELECT [role_id], [role_description] FROM [tRole]"></asp:SqlDataSource>
       
        <br />
        <asp:Button ID="EmpSubmit" OnClick="EmpSubmit_Click" runat="server" Text="Create Employee" /><br />
</asp:Content>
