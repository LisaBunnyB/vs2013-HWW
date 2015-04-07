<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="changeProducts.aspx.cs" Inherits="HWWilson.changeProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span><%:Session["name"] %></span>- Change the details of a product</h1>

    <asp:GridView ID="GVEditProducts" runat="server" AutoGenerateColumns="False"
        AllowSorting="True"
        DataKeyNames="product_id"
        OnRowCancelingEdit="GVEditProducts_RowCancelingEdit"
        OnRowEditing="GVEditProducts_RowEditing"
        OnRowUpdating="GVEditProducts_RowUpdating">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" />

            <asp:BoundField DataField="product_id" HeaderText="Product ID" ReadOnly="true" />
            <asp:TemplateField HeaderText="Barcode">
                <ItemTemplate>
                    <%# Eval("barcode")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtProductBarcode" Text='<%# Eval("barcode")%>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Description">
                <ItemTemplate>
                    <%# Eval("product_name")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtproduct_name" Text='<%# Eval("product_name")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Min Level">
                <ItemTemplate>
                    <%# Eval("product_min_level")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtproduct_min_level" Text='<%# Eval("product_min_level")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="In Stock">
                <ItemTemplate>
                    <%# Eval("prod_stock_level")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtprod_stock_level" Text='<%# Eval("prod_stock_level")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stock Code">
                <ItemTemplate>
                    <%# Eval("prod_stock_code")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtprod_stock_code" Text='<%# Eval("prod_stock_code")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Category">
                <ItemTemplate>
                    <%# Eval("prod_cat_desc")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DDLCat" runat="server" DataSourceID="SqlDataSource1" DataTextField="prod_cat_desc" DataValueField="prod_cat_id"></asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HWWConnectionString %>" SelectCommand="SELECT * FROM [tProductCategory]"></asp:SqlDataSource>

                </EditItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>


    <asp:TextBox ID="TxtAmendConf" runat="server"></asp:TextBox>


</asp:Content>
