<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HWWilson._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <h1>Book out goods for a site</h1>
    <asp:DropDownList ID="DDLjobNo" AutoPostBack="true"  runat="server">
    </asp:DropDownList>
    <asp:Button ID="BtnAllJob" runat="server"  Text="Show all Job Numbers" />
    <br /><br />
<asp:GridView ID="GVjobDesc" runat="server"></asp:GridView>
<asp:TextBox ID="TxtBarcode" AutoPostBack="true" runat="server"></asp:TextBox><br />
<asp:TextBox ID="TxtCode" Width="150" runat="server"></asp:TextBox> 
<asp:Label ID="LblProdDetails" runat="server" Text=""></asp:Label>
<asp:Label ID="LblProdQuantity" runat="server" Text=""></asp:Label> <br /><br />

<asp:Button ID="Button1" runat="server" Text="Book Out Goods" />

</asp:Content>
