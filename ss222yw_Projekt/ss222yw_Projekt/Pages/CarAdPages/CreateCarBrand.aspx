<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCarBrand.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.CreateCarBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Images/Close.png" CausesValidation="False" CssClass="closebutton" />
    </asp:Panel>

     <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="validation-summary-errors" ValidationGroup="CreateValidation" ShowModelStateErrors="false"/>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />

    <asp:ListView ID="CarAdFormView" runat="server"
        ItemType="ss222yw_Projekt.Model.CarBrand"
        InsertMethod="ListView_InsertItem"
        SelectMethod="CarAdFormView_GetItem"
        DataKeyNames="CarBrandID"
        InsertItemPosition="FirstItem">
        
        <ItemTemplate>
            <ul>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
        </ItemTemplate>

        <InsertItemTemplate>
            <div class="editor-label">
                <label for="BrandName"><strong>Lägg till en ny bilmärke</strong></label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="BrandName" runat="server" Text='<%# BindItem.BrandName %>' MaxLength="40" />
                   <asp:RequiredFieldValidator ID="BrandNameRequiredFieldValidator" runat="server"
                     ErrorMessage="Bilmärken måste anges." ControlToValidate="BrandName"
                     Display="None" ValidationGroup="CreateValidation">
                </asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Insert" CssClass="Green" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%$ RouteUrl:routename=CarAdCreate %>' CssClass="Green" />
            </div>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
