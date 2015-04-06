<%@ Page Title="Product Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="HWWilson.HWWilson.Products.product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h2>Add a new product </h2>
            <p>To add a new product with barcode</p>
            <asp:Button ID="ButnAddPrd" OnClick="ButnAddPrd_Click" runat="server" Text="Add Product" />
        </div>
        <div class="col-md-4">
            <h2>Add a barcode</h2>
            <p>To add an additional barcode to an existing product</p>
            <asp:Button ID="ButAddBarcode" runat="server" OnClick="ButAddBarcode_Click" Text="Add a Barcode" />
        </div>
        <div class="col-md-4">
            <h2>View all Products</h2>
            <p>To view all details of products held in the stores</p>
            <asp:Button ID="ButnViewPrd" runat="server" OnClick="ButnViewPrd_Click" Text="View Products" />
        </div>

        <div class="col-md-4">
            <h2>Change product details</h2>
            <p>To change a products details such as stock level</p>
            <asp:Button ID="ButnChgPrd" OnClick="ButnChgPrd_Click" runat="server" Text="Change Product details" />
        </div>
    </div>
    <!-- closes the row -->
</asp:Content>
