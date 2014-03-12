<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listning.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Listning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <h1>
        Bilannonser
    </h1>


    <asp:ValidationSummary runat="server" CssClass="validation-summary-errors"/>
     <div class="editor-field">
        <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=CarAdCreate %>' Text="Lägg till ny bilannons" />
    </div>
    <asp:ListView ID="CarAdListView" runat="server" 
        ItemType="ss222yw_Projekt.Model.CarAd"
         SelectMethod="CarAdListView_GetData"
         DataKeyNames="CarAdID" >

      <LayoutTemplate>
            <%-- Platshållare för CarAd --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl class="CarAd-card">
                <dt>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("CarAdDetails", new { id = Item.CarAdID })  %>' Text='<%# Item.Header %>' />

                </dt>
  
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då CarAd saknas i databasen. --%>
            <p>
                bilannonser saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
