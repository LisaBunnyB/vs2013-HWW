<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addBarcode.aspx.cs" Inherits="HWWilson.addBarcode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><span><%:Session["name"] %></span> - Add a new barcode to an existing Product</h1>
    <br />
    <br />
    <%--Creates a label and a text box for the product ID --%>
    <asp:Label ID="LblProductID" runat="server" Width="265" Text="Please enter the Product ID"></asp:Label>
    <asp:TextBox ID="TxtProdID" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldTextProdID" runat="server"
        ErrorMessage="Please enter the product ID"
        ControlToValidate="TxtProdID"
        CssClass="ErrorMsg"
        ForeColor="Red"
        Display="Dynamic">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidTxtProdID" runat="server" 
      ErrorMessage="The product ID must a number" 
         ControlToValidate="TxtProdID"
        ValidationExpression="^\d+$"
        CssClass="ErrorMsg"
        ForeColor="Red"
        Display="Dynamic">
    </asp:RegularExpressionValidator>
    <br />
    <%--Creates a label and a text box for the new barcode --%>
    <asp:Label ID="LblAddBarcode" runat="server" Width="265" Text="Please enter the barcode you wish to add"></asp:Label>
    <asp:TextBox ID="TxtAddBarcode" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidBarcode" runat="server"
        ErrorMessage="Please enter the barcode to be added to the product above"
        ControlToValidate="TxtAddBarcode"
        CssClass="ErrorMsg"
        ForeColor="Red"
        Display="Dynamic">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
            ErrorMessage="The Barcode should be a 13 digit number"
            ControlToValidate="TxtAddBarcode"
            CssClass="ErrorMsg"
            ForeColor="Red"
            Display="Dynamic"
            ValidationExpression='^(\d{13})?$'>
        </asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="LblInstructions" runat="server"
        Text="If you are unsure of the product ID you can use the search boxes below to identify the product." ForeColor="Red">     

    </asp:Label><br />
    <asp:TextBox ID="TxtAddBarcodeConfirmation" Visible="true" Width="600" Height="100" runat="server"></asp:TextBox><br />
    <asp:Button ID="ButnConfBarcode" runat="server" Text="Confirm Add the Barcode" />
    <br />
    <br />
    <%--Creates a label and a drop down list for product categories --%>
    <asp:Label ID="LblSelectCat" runat="server" Text="Select a Product Category"></asp:Label>
    <asp:DropDownList ID="DDLSelectCat" AutoPostBack="true"
        OnSelectedIndexChanged="DDLSelectCat_SelectedIndexChanged"
        runat="server">
    </asp:DropDownList>
    <%--Creates a button to show all products --%>
    <asp:Button ID="ButnShowAllProds" CausesValidation="False" runat="server" OnClick="ButnShowAllProds_Click" Text="Show all Products" /><br />
    <%--Creates a label and a text box to search by product name --%>
    <asp:Label ID="LblProductName" runat="server" Text="Enter a product Description"></asp:Label>
    <asp:TextBox ID="TxtProductDesc" AutoPostBack="true" runat="server" OnTextChanged="TxtProductDesc_TextChanged" CssClass="marRight"></asp:TextBox>
    <%--Creates a label and a text box to search by barcode --%>
    <asp:Label ID="Lblbarcode" runat="server" Text="Enter a barcode"></asp:Label>
    <asp:TextBox ID="TxtBarcodeSearch" AutoPostBack="true" runat="server" OnTextChanged="TxtBarcodeSearch_TextChanged"></asp:TextBox><br />
    <asp:GridView ID="GVProds2" runat="server" AutoGenerateColumns="False" CellPadding="5" BorderWidth="2px">
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
    <br />
    <br />
    <br />


</asp:Content>
