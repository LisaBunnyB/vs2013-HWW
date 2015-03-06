<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="displayproducts.aspx.cs" Inherits="HWWilson.displayproducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pagecontent">
        <br />
        <br />
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False"  CellPadding="5" BorderWidth="2px">
            
        <AlternatingRowStyle BackColor="#C5F08A" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="product_id" HeaderText="Product ID" SortExpression="" />
            <asp:BoundField DataField="product_name" HeaderText="Product Description" SortExpression="" />
            <asp:BoundField DataField="product_min_level" HeaderText="Minumum Stock Level" SortExpression="" />
             <asp:BoundField DataField="prod_stock_level" HeaderText="Number in Stock" SortExpression="" />
             <asp:BoundField DataField="prod_stock_code" HeaderText="Stock Code" SortExpression="" />
             <asp:BoundField DataField="prod_cat_desc" HeaderText="Product Category" SortExpression="" />
        </Columns>
        <HeaderStyle BackColor="#97CA51" BorderWidth="2px" HorizontalAlign="Center" />
        <SortedAscendingCellStyle BorderStyle="Double" />

        </asp:GridView>
            </div>
</asp:Content>
