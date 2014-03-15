<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listning.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Listning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <h1>
        Bilannonser
    </h1>
     <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Images/Close.png" CausesValidation="False" CssClass="closebutton"/>
    </asp:Panel>

    <span><strong>Inloggad</strong></span>
    <asp:FormView ID="UserFormView" runat="server"
         ItemType="ss222yw_Projekt.Model.User"
         RenderOuterTable="false"
         SelectMethod="UserListView1_GetData">
          <ItemTemplate>
            <div class="editor-label">
                <label for="Name"><strong>Välkommen</strong></label>
               </div>
              <div class="editor-field">
                <%#: Item.Name %>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:ValidationSummary runat="server" CssClass="validation-summary-errors"/>
     <div>
       <asp:HyperLink ID="HyperLink1"  runat="server" NavigateUrl='<%$ RouteUrl:routename=CarAdCreate %>' Text="Lägg till ny bilannons" CssClass="SitMasterColor"/>
    </div>
    <asp:ListView ID="CarAdListView" runat="server" 
        ItemType="ss222yw_Projekt.Model.CarAd"
         SelectMethod="CarAdListView_GetData"
         DataKeyNames="CarAdID" >

      <LayoutTemplate>
  
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl class="CarAd-card">
                <dt>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("CarAdDetails", new { id = Item.CarAdID })  %>' Text='<%# Item.Header %>'/>
          

                </dt>
  
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>

            <p>
                bilannonser saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
