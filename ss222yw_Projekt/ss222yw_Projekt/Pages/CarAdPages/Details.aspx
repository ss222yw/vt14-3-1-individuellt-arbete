<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Bilannons
    </h1>

      <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Images/Close.png" CausesValidation="False" CssClass="closebutton"/>
    </asp:Panel>

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
                  <div class="editor-label">
                <label for="Date"><strong>Datum :</strong></label>
            </div>
            <div class="editor-field">
                <%#: Item.Date %>
            </div>
              
           <div>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("CarAdEdit", new { id = Item.CarAdID }) %>' CssClass="Green"/>
                <asp:HyperLink ID="HyperLink2" runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("CarAdDelete", new { id = Item.CarAdID }) %>'  CssClass="Green"/>
                <asp:HyperLink ID="HyperLink3" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("CarAd", null)%>'  CssClass="Green"/>
            </div>
        </ItemTemplate>
       
    </asp:FormView>

   <asp:ListView ID="CarBrandListView" runat="server"
        ItemType="ss222yw_Projekt.Model.CarBrand"
        DataKeyNames="CarBrandID"
        SelectMethod="GetCarBrandByCarAdID"
        OnItemDataBound="CarBrandListView_ItemDataBound">
         <LayoutTemplate>
            <ul>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
          <ItemTemplate>

           <span><strong>Bilmärken :</strong></span>
               <li>
                <asp:DropDownList ID="CarBrandDropDownList" runat="server"
                    DataTextField="BrandName"
                    DataValueField="CarBrandID"
                     Enabled="false"
                      SelectedValue='<%# Item.CarBrandID %>'
                     SelectMethod="GetCarBrandByCarAdID1"/>
            </li>
  
        </ItemTemplate>
          </asp:ListView>
</asp:Content>


