<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Bilannons
    </h1>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />

    <asp:FormView ID="CarAdView" runat="server"
         ItemType="ss222yw_Projekt.Model.CarAd"
         RenderOuterTable="false"
         SelectMethod="CarAdView_GetItem">

          <ItemTemplate>
            <div class="editor-label">
                <label for="Header"><strong>Rubrik :</strong></label>
            </div>
            <div class="editor-field">
                <%#: Item.Header %>
            </div>
            <div class="editor-label">
                <label for="ModelYear"><strong>Årsmodell :</strong></label>
            </div>
            <div class="editor-field">
                <%#: Item.ModelYear %>
            </div>
            <div class="editor-label">
                <label for="CarColor"><strong>Färg :</strong></label>
            </div>
            <div class="editor-field">
                <%#: Item.CarColor %>
            </div>
            <div class="editor-label">
                <label for="Price"><strong>Pris :</strong></label>
            </div>
            <div class="editor-field">
                <%#: Item.Price %>
            </div>
               <div class="editor-label">
                <label for="Description"><strong>Beskrivning :</strong></label>
            </div>
            <div class="editor-field">
                <%#: Item.Description %>
            </div>
           
        </ItemTemplate>
    </asp:FormView>

    <asp:FormView ID="UserFormView" runat="server"
         ItemType="ss222yw_Projekt.Model.User"
         RenderOuterTable="false"
         SelectMethod="UserFormView_GetItem">
          <ItemTemplate>
              <span><strong>User</strong></span>
            <div class="editor-label">
                <label for="Name"><strong>Namn :</strong></label>
               </div>
              <div class="editor-field">
                <%#: Item.Name %>
            </div>
            <div>
                <asp:HyperLink  runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("CarAdEdit", new { id = Item.UserID }) %>' />
                <asp:HyperLink  runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("CarAdDelete", new { id = Item.UserID }) %>' />
                <asp:HyperLink  runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("CarAds", null)%>' />
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>

