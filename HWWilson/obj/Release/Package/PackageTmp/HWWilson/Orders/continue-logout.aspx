<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="continue-logout.aspx.cs" Inherits="HWWilson.HWWilson.Orders.continue_logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
   
        <asp:Button  ID="ButNewOrder" CssClass="largeBut" OnClick="ButNewOrder_Click" runat="server" Text="Create another order" />
   
        <asp:Button  ID="ButLogOut" CssClass="largeBut" OnClick="ButLogOut_Click" runat="server" Text="Logout" />
   
</asp:Content>
