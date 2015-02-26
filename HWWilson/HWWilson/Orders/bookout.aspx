<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bookout.aspx.cs" Inherits="HWWilson.HWWilson.Orders.bookout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book out goods for a site</h1>
    <asp:DropDownList ID="DDLjobNo" AutoPostBack="true" OnSelectedIndexChanged="DDLjobNo_SelectedIndexChanged" runat="server">
    </asp:DropDownList>
    <asp:Button ID="BtnAllJob" runat="server" OnClick="BtnAllJob_Click" Text="Show all Job Numbers" />
    <br />
    <br />
    <asp:GridView ID="GVjobDesc" runat="server"></asp:GridView>
     <asp:TextBox ID="TxtBar" AutoPostBack="true" OnTextChanged="NewBarcode" runat="server" ></asp:TextBox><br />
    <asp:GridView ID="GVorder" runat="server"></asp:GridView>
     <asp:TextBox ID="TextBox1" AutoPostBack="true" runat="server" ></asp:TextBox><br />
</asp:Content>
