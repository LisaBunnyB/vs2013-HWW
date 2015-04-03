<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="HWWilson.addProduct" %>

<%-- This is where the main content of the page is placed. The header and Footer are in the Site.Master file--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pagecontent">
        <h1><span><%:Session["name"] %></span> - Add a new Product</h1>
        <%--Creates a lable for the product name and text box for user input --%>
        <asp:Label ID="LblProdName" Width="150" runat="server" Text="Product Name"></asp:Label>
        <asp:TextBox ID="TextProdName" Width="250" runat="server"></asp:TextBox>
        <%--Validates a product name has been entered --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ErrorMessage="Please enter the products name"
            ControlToValidate="TextProdName"
            CssClass="ErrorMsg"
            ForeColor="Red"
            Display="Dynamic">
        </asp:RequiredFieldValidator>
        <%--Validates the product name does not exceed 100 characters --%>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="The product name should contain between 5 and 100 Characters"
            ControlToValidate="TextProdName"
            CssClass="ErrorMsg"
            ForeColor="Red"
            Display="Dynamic" ValidationExpression='^[\s\S]{5,100}$'>
         </asp:RegularExpressionValidator>
        <br />
        <%--Creates a lable for the barcode and text box for user input --%>
        <asp:Label ID="LblProdBarcode" Width="150" runat="server" Text="Product Barcode"></asp:Label>
        <asp:TextBox ID="TextProdBarcode" Width="150" runat="server"></asp:TextBox>
        <%--Validates a barcode has been entered --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
            ErrorMessage="Please enter a barcode for the product"
            ControlToValidate="TextProdBarcode"
            CssClass="ErrorMsg"
            ForeColor="Red"
            Display="Dynamic">
        </asp:RequiredFieldValidator>
        <%--Validates a 13 digit number for the barcode has been entered --%>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ErrorMessage="The Barcode should be a 13 digit number"
            ControlToValidate="TextProdBarcode"
            CssClass="ErrorMsg"
            ForeColor="Red"
            Display="Dynamic" 
            ValidationExpression='^(\d{13})?$'>
         </asp:RegularExpressionValidator>
       
        <%--When the data is INSERTED into the database if the barcode exists an error message will be displayed here --%>
        <asp:Label ID="LblDupBarcode" Width="300" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="LblProdMinLevel" Width="150" runat="server" Text="Minimum stock level"></asp:Label>
        <asp:TextBox ID="TextProdMinLevel" Width="150" runat="server"></asp:TextBox>
        <%--Validates a minimum stock level has been entered --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  
            ErrorMessage="Please enter the minimum stock level for the product" 
            ControlToValidate="TextProdMinLevel" 
            CssClass="ErrorMsg" 
            ForeColor="Red"
            Display="Dynamic">
        </asp:RequiredFieldValidator>
        <%--Validates a minimum stock level between 1 and 10000 has been entered --%>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ErrorMessage="The minimum stock level must be a number between 1 and 1000 number"
            ControlToValidate="TextProdMinLevel"
            CssClass="ErrorMsg"
            ForeColor="Red"
            Display="Dynamic" 
            ValidationExpression="^([1-9][0-9]{0,2}|1000)$">
         </asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="LblProdStockLevel" Width="150" runat="server" Text="Amount to add to stock"></asp:Label>
        <asp:TextBox ID="TextProdStockLevel" Width="150" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  
            ErrorMessage="Please enter the quantity you are booking into stock" 
            ControlToValidate="TextProdStockLevel" 
            CssClass="ErrorMsg" 
            ForeColor="Red"
            Display="Dynamic">
        </asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ErrorMessage="The amount to add to stock level be a number between 1 and 1000 number"
            ControlToValidate="TextProdStockLevel"
            CssClass="ErrorMsg"
            ForeColor="Red"
            Display="Dynamic" 
            ValidationExpression="^([1-9][0-9]{0,2}|1000)$">
         </asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="LblProdStockCode" Width="150" runat="server" Text="Stock Code"></asp:Label>
        <asp:TextBox ID="TextProdStockCode" Width="150" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"   
            ErrorMessage="Please enter a stock code for the product"
            ControlToValidate="TextProdStockCode" 
            CssClass="ErrorMsg" 
            ForeColor="Red" 
            Display="Dynamic">
        </asp:RequiredFieldValidator>
               
        <br />
        <asp:Label ID="LblDupStockCode" Width="300" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="LblProdCat" Width="150" runat="server" Text="Product Category"></asp:Label>
        <asp:DropDownList ID="DDLProdCat" runat="server" DataSourceID="SqlDataSource1" DataTextField="prod_cat_desc" DataValueField="prod_cat_id"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HWWilsonConnectionString %>" SelectCommand="SELECT [prod_cat_desc], [prod_cat_id] FROM [tProductCategory]"></asp:SqlDataSource>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"   ErrorMessage="Please select a category ID for the product" ControlToValidate="DDLProdCat" CssClass="ErrorMsg" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="ProdSubmit" OnClick="addNewProduct" runat="server" Text="Submit Product" /><br />
        <asp:TextBox ID="TxtProdAdded" Width="600" Height="100" runat="server"></asp:TextBox>
    </div>
</asp:Content>



