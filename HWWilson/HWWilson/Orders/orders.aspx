<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="HWWilson.HWWilson.Orders.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span> <%:Session["name"] %></span> View all Orders</h1>
    <asp:Label ID="LblOrder" runat="server" Text="Select a job number"></asp:Label>
    <asp:DropDownList ID="DDLjobNos" OnSelectedIndexChanged="DDLjobNos_SelectedIndexChanged" AutoPostBack="true" runat="server"  >
    <asp:ListItem Text="-- pick one --"></asp:ListItem>
    </asp:DropDownList>
     <asp:Button ID="BtnAllOrders" runat="server" OnClick="BtnAllOrders_Click" Text="Show all Orders" />
    <asp:Label ID="Label1" runat="server" Text="Please enter the start Date"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
    <asp:Calendar ID="Calendar1" runat="server" Visible="false"></asp:Calendar>
   

    <br />
    <br />
    <asp:GridView ID="GVOrders" runat="server" AutoGenerateColumns="False"  CellPadding="5" BorderWidth="2px">
        <AlternatingRowStyle BackColor="#C5F08A" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="order_id" HeaderText="Order ID" SortExpression="" />
            <asp:BoundField DataField="job_number" HeaderText="Job Number" SortExpression="" />
            <asp:BoundField DataField="emp_firstname" HeaderText="Employee" SortExpression="" />
            <asp:BoundField DataField="emp_surname" HeaderText="Employee" SortExpression="" />
            <asp:BoundField DataField="order_date" HeaderText="Order Date" SortExpression="" />
            <asp:BoundField DataField="order_time" HeaderText="Order Time" SortExpression="" />
            <asp:BoundField DataField="product_id" HeaderText="Product ID" SortExpression="" />
            <asp:BoundField DataField="product_name" HeaderText="Product Description" SortExpression="" />
            <asp:BoundField DataField="order_qty" HeaderText="Order QTY" SortExpression="" />
           </Columns>
        <HeaderStyle BackColor="#97CA51" BorderWidth="2px" HorizontalAlign="Center" />
        <SortedAscendingCellStyle BorderStyle="Double" />
    </asp:GridView>
</asp:Content>

