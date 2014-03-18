<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarBrandPage.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink2" runat="server" Text="Tillbaka" NavigateUrl='<%$ RouteUrl:routename=CarAdCreate %>'  CssClass="Green"/>
    </div>
    <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Images/Close.png" CausesValidation="False" CssClass="closebutton" />
    </asp:Panel>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="validation-summary-errors" ValidationGroup="EditValidation" ShowModelStateErrors="false" />
    <asp:ListView ID="ListView1" runat="server"
        ItemType="ss222yw_Projekt.Model.CarBrand"
        UpdateMethod="CarBrandFormView_UpdateItem"
        SelectMethod="CarAdFormView_GetItem"
        DefaultMode="Edit"
        DataKeyNames="CarBrandID">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>

        <ItemTemplate>
            <li>
                <div class="editor-field">
                   
                    <span><%# Item.BrandName %></span>
                
                </div>

                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("DeleteCarBrand", new { id = Item.CarBrandID }) %>' />
            </li>
        </ItemTemplate>

        <EditItemTemplate>
            <li>
                <asp:TextBox ID="BrandName" runat="server" Text='<%# BindItem.BrandName %>' MaxLength="40" Enabled="true" />
                <asp:RequiredFieldValidator ID="HeaderRequiredFieldValidator" runat="server"
                    ErrorMessage="Bilmärke måste anges." ControlToValidate="BrandName"
                    Display="None" ValidationGroup="EditValidation">
                </asp:RequiredFieldValidator>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" Text="Spara" />
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
            </li>
        </EditItemTemplate>

    </asp:ListView>
</asp:Content>
