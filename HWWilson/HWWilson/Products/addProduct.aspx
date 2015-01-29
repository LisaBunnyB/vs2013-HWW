<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="HWWilson.addProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblProdName" width="150" runat="server" Text="Product Name"></asp:Label>
    <asp:TextBox ID="TextProdName" width="150" runat="server"></asp:TextBox><br />
    <asp:Label ID="LblProdBarcode" width="150" runat="server" Text="Product Barcode"></asp:Label>
    <asp:TextBox ID="TextProdBarcode" width="150" runat="server"></asp:TextBox><br />
    <asp:Label ID="LblProdMinLevel" width="150" runat="server" Text="Minimum stock level"></asp:Label>
    <asp:TextBox ID="TextProdMinLevel" width="150" runat="server"></asp:TextBox><br />
     <asp:Label ID="LblProdStockLevel" width="150" runat="server" Text="Amount to add to stock"></asp:Label>
    <asp:TextBox ID="TextProdStockLevel" width="150" runat="server"></asp:TextBox><br />
    <asp:Label ID="LblProdStockCode" width="150" runat="server" Text="Stock Code"></asp:Label>
    <asp:TextBox ID="TextProdStockCode" width="150" runat="server"></asp:TextBox><br />
    <asp:DropDownList ID="DDLProdCat" runat="server" DataSourceID="SqlDataSource1" DataTextField="prod_cat_desc" DataValueField="prod_cat_id"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HWWilsonConnectionString %>" SelectCommand="SELECT [prod_cat_desc], [prod_cat_id] FROM [tProductCategory]"></asp:SqlDataSource>
    <asp:Button ID="ProdSubmit" onclick="addNewProduct" runat="server" Text="Submit Product"  /><br /><br /><br /><br />


</asp:Content>



