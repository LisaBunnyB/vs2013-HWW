<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="HWWilson.addProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pagecontent">
        <h1><span><%:Session["name"] %></span> - Add a new Product</h1>
        <%-- This is where the main content of the page is placed. The header and Footer are in the Site.Master file--%>
        <asp:Label ID="LblProdName" Width="150" runat="server" Text="Product Name"></asp:Label>
        <asp:TextBox ID="TextProdName" Width="250" runat="server"></asp:TextBox>
        <%--Validate the text box is not blank --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the products name" ControlToValidate="TextProdName" CssClass="ErrorMsg" ForeColor="Red"></asp:RequiredFieldValidator><br />
        <asp:Label ID="LblProdBarcode" Width="150" runat="server" Text="Product Barcode"></asp:Label>
        <asp:TextBox ID="TextProdBarcode" Width="150" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter a barcode for the product" ControlToValidate="TextProdBarcode" CssClass="ErrorMsg" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblProdMinLevel" Width="150" runat="server" Text="Minimum stock level"></asp:Label>
        <asp:TextBox ID="TextProdMinLevel" Width="150" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter the minimum stock level for the product" ControlToValidate="TextProdMinLevel" CssClass="ErrorMsg" ForeColor="Red"></asp:RequiredFieldValidator><br />
        <asp:Label ID="LblProdStockLevel" Width="150" runat="server" Text="Amount to add to stock"></asp:Label>
        <asp:TextBox ID="TextProdStockLevel" Width="150" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter the quantity you are booking into stock" ControlToValidate="TextProdStockLevel" CssClass="ErrorMsg" ForeColor="Red"></asp:RequiredFieldValidator><br />
        <asp:Label ID="LblProdStockCode" Width="150" runat="server" Text="Stock Code"></asp:Label>
        <asp:TextBox ID="TextProdStockCode" Width="150" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter a stock code for the product" ControlToValidate="TextProdStockCode" CssClass="ErrorMsg" ForeColor="Red"></asp:RequiredFieldValidator><br />
        <br />
         <asp:Label ID="LblProdCat" Width="150" runat="server" Text="Product Category"></asp:Label>
        <asp:DropDownList ID="DDLProdCat" runat="server" DataSourceID="SqlDataSource1" DataTextField="prod_cat_desc" DataValueField="prod_cat_id"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HWWilsonConnectionString %>" SelectCommand="SELECT [prod_cat_desc], [prod_cat_id] FROM [tProductCategory]"></asp:SqlDataSource>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please select a category ID for the product" ControlToValidate="DDLProdCat" CssClass="ErrorMsg" ForeColor="Red"></asp:RequiredFieldValidator><br />
        <br />
        <asp:Button ID="ProdSubmit" OnClick="addNewProduct" runat="server" Text="Submit Product" /><br />
       <asp:TextBox ID="TxtProdConfirm" Width="600" Height="100" runat  ="server"></asp:TextBox><br />
        </div>
</asp:Content>



