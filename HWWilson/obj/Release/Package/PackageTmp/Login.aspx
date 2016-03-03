<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HWWilson.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID="Login1"  DisplayRememberMe="False" runat="server" OnAuthenticate="Login1_Authenticate">
     </asp:Login>

</asp:Content>
