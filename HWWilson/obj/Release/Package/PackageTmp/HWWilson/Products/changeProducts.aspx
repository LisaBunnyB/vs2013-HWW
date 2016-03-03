<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="changeProducts.aspx.cs" Inherits="HWWilson.changeProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span><%:Session["name"] %></span>- Change the details of a product</h1>
    <%-- Creates a text box that will be displayed if any errors occur when changing a products details --%>
    <asp:TextBox ID="TxtAmendError" width="600" Visible="false" Height="40" runat="server" ForeColor="Red"></asp:TextBox>
    <%-- Creates a text box that will be displayed to confirm the product details have been changed --%>
    <asp:TextBox ID="TxtAmendConf" width="600" Visible="false" Height="40" runat="server" ></asp:TextBox>
    <%-- Creates an editable grdiview to enable the user to amend the details entered for a product --%>
    <asp:GridView ID="GVEditProducts" runat="server" AutoGenerateColumns="False"  CellPadding="5" BorderWidth="2px"
        AllowSorting="True"
        DataKeyNames="product_id"
        OnRowCancelingEdit="GVEditProducts_RowCancelingEdit"
        OnRowEditing="GVEditProducts_RowEditing"
        OnRowUpdating="GVEditProducts_RowUpdating">
        <AlternatingRowStyle BackColor="#C5F08A" ForeColor="Black" />
        <Columns>
            <%--Shows the edit, update and cancel buttons --%>
            <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" />
            <%--Shows the product id as read only --%>
            <asp:BoundField DataField="product_id" HeaderText="Product ID" ReadOnly="true" />
            <%--Shows the barcode --%>
            <asp:TemplateField HeaderText="Barcode">
                <ItemTemplate>
                    <%# Eval("barcode")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--Shows the barcode in editable textbox --%>
                    <asp:TextBox runat="server" ID="txtProductBarcode" Text='<%# Eval("barcode")%>' />
                    <%--Shows the barcode in editable textbox --%>
                    <%--Validates a barcode has been entered --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidattxtProductBarcode" runat="server"
                        ErrorMessage="Please enter a barcode for the product"
                        ControlToValidate="txtProductBarcode"
                        CssClass="ErrorMsg"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <%--Validates a 13 digit number for the barcode has been entered --%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidattxtProductBarcode" runat="server"
                        ErrorMessage="The Barcode should be a 13 digit number"
                        ControlToValidate="txtProductBarcode"
                        CssClass="ErrorMsg"
                        ForeColor="Red"
                        Display="Dynamic"
                        ValidationExpression='^(\d{13})?$'>
                    </asp:RegularExpressionValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <%# Eval("product_name")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtproduct_name" Text='<%# Eval("product_name")%>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidtxtproduct_name" runat="server"
                        ErrorMessage="Please enter the products name"
                        ControlToValidate="txtproduct_name"
                        CssClass="ErrorMsg"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <%--Validates the product name does not exceed 100 characters --%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidtxtproduct_name" runat="server"
                        ErrorMessage="The product name should contain between 5 and 100 Characters"
                        ControlToValidate="txtproduct_name"
                        CssClass="ErrorMsg"
                        ForeColor="Red"
                        Display="Dynamic" ValidationExpression='^[\s\S]{5,100}$'>
                    </asp:RegularExpressionValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Min Level">
                <ItemTemplate>
                    <%# Eval("product_min_level")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtproduct_min_level" Text='<%# Eval("product_min_level")%>' />
                    <%--Validates a minimum stock level has been entered --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidattxtproduct_min_level" runat="server"
                        ErrorMessage="Please enter the minimum stock level for the product"
                        ControlToValidate="txtproduct_min_level"
                        CssClass="ErrorMsg"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <%--Validates a minimum stock level between 1 and 10000 has been entered --%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidattxtproduct_min_level" runat="server"
                        ErrorMessage="The minimum stock level must be a number between 1 and 1000 number"
                        ControlToValidate="txtproduct_min_level"
                        CssClass="ErrorMsg"
                        ForeColor="Red"
                        Display="Dynamic"
                        ValidationExpression="^([1-9][0-9]{0,2}|1000)$">
                    </asp:RegularExpressionValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="In Stock">
                <ItemTemplate>
                    <%# Eval("prod_stock_level")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtprod_stock_level" Text='<%# Eval("prod_stock_level")%>' />
                    <%--Validates a stock level has been entered --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidattxtprod_stock_level" runat="server"
                        ErrorMessage="Please enter the quantity you are booking into stock"
                        ControlToValidate="txtprod_stock_level"
                        CssClass="ErrorMsg"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <%--Validates stock level between 1 and 10000 has been entered --%>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidattxtprod_stock_level" runat="server"
                        ErrorMessage="The amount to add to stock level be a number between 1 and 1000 number"
                        ControlToValidate="txtprod_stock_level"
                        CssClass="ErrorMsg"
                        ForeColor="Red"
                        Display="Dynamic"
                        ValidationExpression="^([1-9][0-9]{0,2}|1000)$">
                    </asp:RegularExpressionValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stock Code">
                <ItemTemplate>
                    <%# Eval("prod_stock_code")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtprod_stock_code" Text='<%# Eval("prod_stock_code")%>' />
                    <%--Validates a stock code has been entered for the product --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidattxtprod_stock_code" runat="server"
                        ErrorMessage="Please enter a stock code for the product"
                        ControlToValidate="txtprod_stock_code"
                        CssClass="ErrorMsg"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>

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
        <HeaderStyle BackColor="#97CA51" BorderWidth="2px" HorizontalAlign="Center" />
    </asp:GridView>


    


</asp:Content>
