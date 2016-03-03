<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewEmployees.aspx.cs" Inherits="HWWilson.HWWilson.Employee.viewEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="pagecontent">
    <br />
    <asp:GridView ID="GVEmployee" runat="server" AutoGenerateColumns="False" CellPadding="5" BorderWidth="2px">
    <AlternatingRowStyle BackColor="#C5F08A" ForeColor="Black" />
    <Columns>
        <asp:BoundField DataField="employee_id"  HeaderText="Employee Id   "  SortExpression="" />
        <asp:BoundField DataField="emp_firstname" HeaderText="Firstname    " SortExpression="" />
        <asp:BoundField DataField="emp_surname" HeaderText="Surname" SortExpression="" />
        <asp:BoundField DataField="role_description" HeaderText="Role" SortExpression="" />
    </Columns>
    <HeaderStyle BackColor="#97CA51" BorderWidth="2px" HorizontalAlign="Center" />
        
    </asp:GridView>
   
</div>
</asp:Content>
