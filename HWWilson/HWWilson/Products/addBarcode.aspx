﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addBarcode.aspx.cs" Inherits="HWWilson.addBarcode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><span><%:Session["name"] %></span> - Add a new barcode to an existing Product</h1>
    <br />
    <br />
    <%--Creates a label and a text box for the product ID --%>
    <asp:Label ID="LblProductID" runat="server" Width="265" Text="Please enter the Product ID"></asp:Label>
    <asp:TextBox ID="TxtProdID" runat="server"></asp:TextBox>
     <%--Validates a product ID has been entered --%>
    <asp:RequiredFieldValidator ID="RequiredFieldTextProdID" runat="server"
        ErrorMessage="Please enter the product ID"
        ControlToValidate="TxtProdID"
        CssClass="ErrorMsg"
        ForeColor="Red"
        Display="Dynamic">
    </asp:RequiredFieldValidator>
    <%--Validates a product ID entered is a number --%>
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
     <%--Validates a barcode has been entered --%>
    <asp:RequiredFieldValidator ID="RequiredFieldValidBarcode" runat="server"
        ErrorMessage="Please enter the barcode to be added to the product above"
        ControlToValidate="TxtAddBarcode"
        CssClass="ErrorMsg"
        ForeColor="Red"
        Display="Dynamic">
    </asp:RequiredFieldValidator>
    <%--Validates the barcode entered is a 13 digit number --%>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
            ErrorMessage="The Barcode should be a 13 digit number"
            ControlToValidate="TxtAddBarcode"
            CssClass="ErrorMsg"
            ForeColor="Red"
            Display="Dynamic"
            ValidationExpression='^(\d{13})?$'>
        </asp:RegularExpressionValidator>
    <br />
    
   <%--Creates a buttonm that calls the ButnConfBarcode_Click method when clicked which adds the barcode to the product --%>
    <asp:Button ID="ButnConfBarcode" runat="server" onclick="ButnConfBarcode_Click" ForeColor="#009933" CssClass="marRight" Text="Confirm Add the Barcode" />
    <%--Creates a buttonm that calls the ButCancel_Click method when clicked which cancels adding the barcode --%>
    <asp:Button ID="ButCancel" CausesValidation="False" onclick="ButCancel_Click" runat="server" ForeColor="#FF3300" Text="Cancel Adding the Barcode" />
    <br />
     <%--Creates a text box that display confirmation and error messages --%>
    <asp:TextBox ID="TxtAddBarcodeConfirmation" Visible="false" Width="600" Height="50" runat="server"></asp:TextBox><br />
   


</asp:Content>
