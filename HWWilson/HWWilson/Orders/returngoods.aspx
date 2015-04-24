<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="returngoods.aspx.cs" Inherits="HWWilson.HWWilson.Orders.returngoods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><span><%:Session["name"] %></span>Return good from a site</h1>
    <%-- Creates a drop down list that shows the job numbers --%>
    <asp:DropDownList ID="DDLjobNos" AutoPostBack="true" OnSelectedIndexChanged="DDLjobNos_SelectedIndexChanged" runat="server">
    </asp:DropDownList>
    <%-- This button when clicked will call the method BtnAllJob_Click that shows all job numbers in a gridview --%>
    <asp:Button ID="BtnAllJob" runat="server" OnClick="BtnAllJob_Click" Text="Show all Job Numbers" />
    <asp:TextBox ID="TxtBar" AutoPostBack="true" OnTextChanged="NewBarcode2" runat="server"></asp:TextBox><br />
    <br />
    <%-- Creates a gridview that displays all the job numbers and the site details --%>
    <asp:GridView ID="GVjobDesc2" runat="server" AutoGenerateColumns="False" CellPadding="5" BorderWidth="2px">

        <AlternatingRowStyle BackColor="#C5F08A" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="job_number" HeaderText="Job Number" SortExpression="" />
            <asp:BoundField DataField="job_description" HeaderText="Job Description" SortExpression="" />
            <asp:BoundField DataField="job_status" HeaderText="Status" SortExpression="" />
        </Columns>
        <HeaderStyle BackColor="#97CA51" BorderWidth="2px" HorizontalAlign="Center" />
        <SortedAscendingCellStyle BorderStyle="Double" />
    </asp:GridView>
    <br />
    <%-- Creates a gridview that displays all the products that will be returned from the site --%>
    <asp:GridView ID="GVprods2" runat="server" OnSelectedIndexChanged="GVprodsRemoveProduct2" AutoGenerateColumns="False" CellPadding="5" BorderWidth="2px">
        <AlternatingRowStyle BackColor="#C5F08A" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="product_name" HeaderText="Product Description" SortExpression="" />
            <asp:BoundField DataField="product_id" HeaderText="Product ID" SortExpression="" />
            <asp:BoundField DataField="order_qty" HeaderText="Quantity" SortExpression="" />
            <asp:ButtonField CommandName="Select" Text="Remove" />
        </Columns>
        <HeaderStyle BackColor="#97CA51" BorderWidth="2px" HorizontalAlign="Center" />
        <SortedAscendingCellStyle BorderStyle="Double" />
    </asp:GridView>
    <%-- This button when clicked will call the method ButRturn_Clickk that will submit the return order and order details to the database --%>
    <asp:Button ID="ButRturn" runat="server" OnClick="ButRturn_Click" ForeColor="#009933" CssClass="marRight" Text="Confirm Returns" />
     <%-- This button when clicked will call the method ButCancelreturn_Click that will cancel the goods being returned and
       the order and order details will be rolled back in the database --%>
    <asp:Button ID="ButCancelreturn" runat="server" OnClick="ButCancelreturn_Click" ForeColor="#FF3300" Text="Cancel Order" />
</asp:Content>
