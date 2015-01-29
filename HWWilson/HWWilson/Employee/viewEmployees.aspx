<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewEmployees.aspx.cs" Inherits="HWWilson.HWWilson.Employee.viewEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="employee_id" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="employee_id" HeaderText="employee_id" ReadOnly="True" SortExpression="employee_id" />
        <asp:BoundField DataField="emp_firstname" HeaderText="emp_firstname" SortExpression="emp_firstname" />
        <asp:BoundField DataField="emp_surname" HeaderText="emp_surname" SortExpression="emp_surname" />
        <asp:BoundField DataField="role_id" HeaderText="role_id" SortExpression="role_id" />
    </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HWWilsonConnectionString %>" SelectCommand="SELECT [employee_id], [emp_firstname], [emp_surname], [role_id] FROM [tEmployee]"></asp:SqlDataSource>
</asp:Content>
