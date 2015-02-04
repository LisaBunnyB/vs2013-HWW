﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bookoutgoods.aspx.cs" Inherits="HWWilson.HWWilson.Orders.bookoutgoods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book out goods for a site</h1>
    <asp:DropDownList ID="DDLjobNo" AutoPostBack="true" OnSelectedIndexChanged="DDLjobNo_SelectedIndexChanged" runat="server">
    </asp:DropDownList>
    <asp:Button ID="BtnAllJob" runat="server" OnClick="BtnAllJob_Click" Text="Show all Job Numbers" />
    <br /><br />
<asp:GridView ID="GVjobDesc" runat="server"></asp:GridView>
<asp:TextBox ID="TxtBarcode" AutoPostBack="true" OnTextChanged="TxtBarcode_TextChanged" runat="server"></asp:TextBox><br />
<asp:TextBox ID="TxtCode" Width="150" runat="server"></asp:TextBox> 
<asp:Label ID="LblProdDetails" runat="server" Text=""></asp:Label>
<asp:Label ID="LblProdQuantity" runat="server" Text=""></asp:Label>



</asp:Content>
