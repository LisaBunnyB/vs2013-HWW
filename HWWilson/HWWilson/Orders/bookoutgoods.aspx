<%@ Page Title="Book Out Goods" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bookoutgoods.aspx.cs" Inherits="HWWilson.HWWilson.Orders.bookoutgoods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book out goods for a site</h1>
    <asp:DropDownList ID="DDLjobNo" AutoPostBack="true" OnSelectedIndexChanged="DDLjobNo_SelectedIndexChanged" runat="server">
    </asp:DropDownList>
    <asp:Button ID="BtnAllJob" runat="server" OnClick="BtnAllJob_Click" Text="Show all Job Numbers" />
    <br />
    <br />
    <asp:GridView ID="GVjobDesc" runat="server"></asp:GridView>
    <asp:TextBox ID="TxtBarcode" AutoPostBack="true" OnTextChanged="TxtBarcode_TextChanged" runat="server"></asp:TextBox><br />
    <asp:TextBox ID="TxtCode" Width="150" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TxtProdDetails" Width="400" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TxtProdQuantity" Width="150" runat="server" Visible="false"></asp:TextBox><br />

    <asp:TextBox ID="TxtCode2" Width="150" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TxtProdDetails2" Width="400" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TxtProdQuantity2" Width="150" runat="server" Visible="false"></asp:TextBox><br />

    <asp:TextBox ID="TxtCode3" Width="150" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TxtProdDetails3" Width="400" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TxtProdQuantity3" Width="150" runat="server" Visible="false"></asp:TextBox><br />

    <asp:TextBox ID="TxtCode4" Width="150" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TxtProdDetails4" Width="400" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TxtProdQuantity4" Width="150" runat="server" Visible="false"></asp:TextBox><br />

    <asp:TextBox ID="TextBox1" Width="150" runat="server" Visible="false"></asp:TextBox><br />

    <asp:Button ID="Button1" runat="server" Text="Book Out Goods" />

</asp:Content>
