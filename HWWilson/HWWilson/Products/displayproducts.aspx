<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="displayproducts.aspx.cs" Inherits="HWWilson.displayproducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pagecontent">
        <h1><span> <%:Session["name"] %></span>Display all Products</h1>
        <br />
        <br />
        <asp:Label ID="LblSelect" runat="server" Text="Select a Product Category"></asp:Label>
        <asp:DropDownList ID="DDLStockCat" AutoPostBack="true" OnSelectedIndexChanged="DDLStockCat_SelectedIndexChanged" runat="server">
    </asp:DropDownList> 
         <asp:Button ID="BtnAllCats" runat="server" OnClick="BtnAllCats_Click" Text="Show all Products" /><br />
        <asp:Label ID="LblProdName" runat="server" Text="Enter a product Description"></asp:Label>
        <asp:TextBox ID="TxtProdDesc" AutoPostBack="true" runat="server" OnTextChanged="TxtProdDesc_TextChanged"></asp:TextBox>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False"  CellPadding="5" BorderWidth="2px">
            
        <AlternatingRowStyle BackColor="#C5F08A" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="product_id" HeaderText="Product ID" SortExpression="product_id" />
            <asp:BoundField DataField="barcode" HeaderText="Barcode" SortExpression="" />
            <asp:BoundField DataField="product_name" HeaderText="Product Description" SortExpression="" />
            <asp:BoundField DataField="product_min_level" HeaderText="Min Level" SortExpression="" />
             <asp:BoundField DataField="prod_stock_level" HeaderText="In Stock" SortExpression="" />
             <asp:BoundField DataField="prod_stock_code" HeaderText="Stock Code" SortExpression="" />
             <asp:BoundField DataField="prod_cat_desc" HeaderText="Product Category" SortExpression="" />
        </Columns>
        <HeaderStyle BackColor="#97CA51" BorderWidth="2px" HorizontalAlign="Center" />
        <SortedAscendingCellStyle BorderStyle="Double" />

        </asp:GridView>
            </div>
</asp:Content>
