<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Edit" %>
<asp:Content  ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Redigera Bilannons
    </h1>


    <asp:ValidationSummary  runat="server" CssClass="validation-summary-errors" />
    <asp:FormView ID="CarAdFormView" runat="server" 
        ItemType="ss222yw_Projekt.Model.CarAd"
         DataKeyNames="CarAdID"
         DefaultMode="Edit" 
        RenderOuterTable="false" 
        SelectMethod="CarAdFormView_GetItem"
         UpdateMethod="CarAdFormView_UpdateItem">

     <EditItemTemplate>
            <div class="editor-label">
                <label for="Header">Rubrik</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Header" runat="server" Text='<%# BindItem.Header %>' />
            </div>
            <div class="editor-label">
                <label for="ModelYear">Årsmodell</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="ModelYear" runat="server" Text='<%# BindItem.ModelYear %>' />
            </div>
            <div class="editor-label">
                <label for="CarColor">Färg</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="CarColor" runat="server" Text='<%# BindItem.CarColor %>' />
            </div>
            <div class="editor-label">
                <label for="Price">Pris</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' />
            </div>
            <div class="editor-label">
                <label for="Description">Beskrivning</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Description" runat="server" Text='<%# BindItem.Description %>' />
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara annonsen" CommandName="Update" CausesValidation="false" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt"  NavigateUrl='<%# GetRouteUrl("CarAdDetails", new { id = Item.CarAdID }) %>' />
            </div>
        </EditItemTemplate>
        </asp:FormView>




    <asp:FormView ID="UserFormView" runat="server" ItemType="ss222yw_Projekt.Model.User"
         DataKeyNames="UserID" DefaultMode="Edit" RenderOuterTable="false" SelectMethod="UserFormView_GetItem"
         UpdateMethod="UserFormView_UpdateItem">

     <EditItemTemplate>
            <div class="editor-label">
                <label for="Name">Namn</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara namnet" CommandName="Update" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("CarAdDetails", new { id = Item.UserID }) %>' />
            </div>
        </EditItemTemplate>
        </asp:FormView>
</asp:Content>
