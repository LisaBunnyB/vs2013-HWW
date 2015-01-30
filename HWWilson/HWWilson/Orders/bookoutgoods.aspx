<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bookoutgoods.aspx.cs" Inherits="HWWilson.HWWilson.Orders.bookoutgoods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book out goods for a site</h1>
    <asp:DropDownList ID="DDLjobNo" AutoPostBack="true" OnSelectedIndexChanged="DDLjobNo_SelectedIndexChanged" runat="server">
    </asp:DropDownList>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>


</asp:Content>
