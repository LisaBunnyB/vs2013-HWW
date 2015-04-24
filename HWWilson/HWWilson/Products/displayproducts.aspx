<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="displayproducts.aspx.cs" Inherits="HWWilson.displayproducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pagecontent">
        <h1><span><%:Session["name"] %></span>Display all Products</h1>
        <br />
        <br />
        <%--Creates a label to select a product categoty --%>
        <asp:Label ID="LblSelect" runat="server" Text="Select a Product Category"></asp:Label>
        <%--Creates a drop down list that allows the user to select the product categoty --%>
        <asp:DropDownList ID="DDLStockCat" AutoPostBack="true" OnSelectedIndexChanged="DDLStockCat_SelectedIndexChanged" runat="server">
        </asp:DropDownList>
         <%--Creates a button that displays all products when clicked --%>
        <asp:Button ID="BtnAllCats" runat="server" OnClick="BtnAllCats_Click" Text="Show all Products" /><br />
        <%--Creates a label and a  text box that allows the user to enter the product name to search --%>
        <asp:Label ID="LblProdName" runat="server" Text="Enter a product Description"></asp:Label>
        <asp:TextBox ID="TxtProdDesc" AutoPostBack="true" runat="server" OnTextChanged="TxtProdDesc_TextChanged"></asp:TextBox>
         <%--Creates a label and a  text box that allows the user to enter a barcode to search --%>
        <asp:Label ID="Lblbarcode" runat="server" Text="Enter a barcode"></asp:Label>
        <asp:TextBox ID="TxtBarcodeSearch" AutoPostBack="true" runat="server" OnTextChanged="TxtBarcodeSearch_TextChanged"></asp:TextBox><br />
         <%--Creates a gridview that display the products --%>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CellPadding="5" BorderWidth="2px">
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
