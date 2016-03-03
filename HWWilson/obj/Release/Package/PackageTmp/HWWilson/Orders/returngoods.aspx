<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="returngoods.aspx.cs" Inherits="HWWilson.HWWilson.Orders.returngoods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <h1><span> <%:Session["name"] %></span>Return good from a site</h1>
    <asp:DropDownList ID="DDLjobNo" AutoPostBack="true" OnSelectedIndexChanged="DDLjobNo_SelectedIndexChanged" runat="server">
    </asp:DropDownList>
    <asp:Button ID="BtnAllJob" runat="server" OnClick="BtnAllJob_Click" Text="Show all Job Numbers" />
     <asp:TextBox ID="TxtBar" AutoPostBack="true" OnTextChanged="NewBarcode" runat="server"></asp:TextBox><br />
    <br />
   
    <asp:GridView ID="GVjobDesc2" runat="server" AutoGenerateColumns="False"  CellPadding="5" BorderWidth="2px">

        <AlternatingRowStyle BackColor="#C5F08A" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="job_number" HeaderText="Job Number" SortExpression="" />
            <asp:BoundField DataField="job_description" HeaderText="Job Description" SortExpression="" />
            <asp:BoundField DataField="job_status" HeaderText="Status" SortExpression="" />
        </Columns>
        <HeaderStyle BackColor="#97CA51" BorderWidth="2px" HorizontalAlign="Center" />
        <SortedAscendingCellStyle BorderStyle="Double" />
    </asp:GridView>
    <br />
       
    <asp:GridView ID="GVprods2" runat="server" OnSelectedIndexChanged="GVprodsRemoveProduct" AutoGenerateColumns="False" CellPadding="5" BorderWidth="2px">
    <AlternatingRowStyle BackColor="#C5F08A" ForeColor="Black" />
    <Columns>
            <asp:BoundField DataField="product_name" HeaderText="Product Description" SortExpression="" />
            <asp:BoundField DataField="product_id" HeaderText="Product ID" SortExpression="" />
            <asp:BoundField DataField="order_qty" HeaderText="Quantity" SortExpression="" />            
            <asp:ButtonField CommandName="Select" Text="Remove"/>
         </Columns>
        <HeaderStyle BackColor="#97CA51" BorderWidth="2px" HorizontalAlign="Center" />
        <SortedAscendingCellStyle BorderStyle="Double" />
   </asp:GridView>
    
    
 <asp:Button ID="ButRturn" runat="server" OnClick="ButBookout_Click" Text="Confirm Returns" />
 <asp:Button ID="ButCancel" runat="server" OnClick="ButCancel_Click" Text="Cancel Order" />
</asp:Content>
