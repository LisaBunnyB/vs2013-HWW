<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HWWilson.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblUserName" runat="server" Text="Label">UserName</asp:Label>
    <asp:TextBox ID="TxtUserName" runat="server">Trade</asp:TextBox><br />
      <asp:Label ID="LblPass" runat="server" Text="Label">Password</asp:Label>
    <asp:TextBox ID="TxtPass" runat="server">Trade</asp:TextBox><br />
    <asp:Button ID="BtnLogin" onclick="BtnLogin_Click"  runat="server" Text="Login" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>
