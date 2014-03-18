<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Ny Bilannons
    </h1>
    <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Images/Close.png" CausesValidation="False" CssClass="closebutton" />
    </asp:Panel>


    <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="validation-summary-errors" ValidationGroup="CreateValidation" ShowModelStateErrors="false" />
    <asp:FormView ID="CarAdFormView" runat="server"
        ItemType="ss222yw_Projekt.Model.CarAd"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="CarAdFormView_InsertItem">

        <InsertItemTemplate>
            <div class="editor-label">
                <label for="Header">Rubrik</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Header" runat="server" Text='<%# BindItem.Header %>' MaxLength="25" />
                <asp:RequiredFieldValidator ID="HeaderRequiredFieldValidator" runat="server"
                    ErrorMessage="Rubrik måste anges." ControlToValidate="Header"
                    Display="None" ValidationGroup="CreateValidation">
                </asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="ModelYear">Årsmodell</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="ModelYear" runat="server" Text='<%# BindItem.ModelYear %>' MaxLength="4" />
                <asp:RequiredFieldValidator ID="ModelYearRequiredFieldValidator" runat="server"
                    ErrorMessage="Årsmodell måste anges." ControlToValidate="ModelYear"
                    Display="None" ValidationGroup="CreateValidation">
                </asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="CarColor">Färg</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="CarColor" runat="server" Text='<%# BindItem.CarColor %>' MaxLength="25" />
                <asp:RequiredFieldValidator ID="CarColorRequiredFieldValidator1" runat="server"
                    ErrorMessage="Färgen måste anges." ControlToValidate="CarColor"
                    Display="None" ValidationGroup="CreateValidation">
                </asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="Price">Pris</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' />
                <asp:RequiredFieldValidator ID="PriceRequiredFieldValidator1" runat="server"
                    ErrorMessage="Priset måste anges." ControlToValidate="Price"
                    Display="None" ValidationGroup="CreateValidation">
                </asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="Description">Beskrivning</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Description" runat="server" Text='<%# BindItem.Description %>' MaxLength="500" TextMode="MultiLine" ValidateRequestMode="Disabled" />
            </div>
            <asp:RequiredFieldValidator ID="DescriptionRequiredFieldValidator1" runat="server"
                ErrorMessage="Beskrivning måste anges." ControlToValidate="Description"
                Display="None" ValidationGroup="CreateValidation">
            </asp:RequiredFieldValidator>
            <li>
                <asp:DropDownList ID="CarBrandDropDownList" runat="server"
                    SelectMethod="CarBrandMethod_GetData"
                    DataTextField="BrandName"
                    DataValueField="CarBrandID" />
            </li>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Insert" CssClass="Green" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%$ RouteUrl:routename=User %>' CssClass="Green" />
            </div>
            <div>
                <h3>Bilmärket finns inte ?
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%$ RouteUrl:routename=CareateCarBrand %>' Text="Lägg till ny bimärken" CssClass="SitMasterColor" /></h3>

            </div>
            <div>
                <h3>Eller 
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%$ RouteUrl:routename=EditCarBrand %>' Text="Redigera bimärken" CssClass="SitMasterColor" />
                    om ni önskar så!</h3>

            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
