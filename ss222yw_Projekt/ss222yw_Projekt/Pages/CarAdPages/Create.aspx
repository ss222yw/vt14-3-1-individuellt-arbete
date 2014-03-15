<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <h1>
            Ny Bilannons
        </h1>


    
    <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />

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
                <asp:TextBox ID="Header" runat="server" Text='<%# BindItem.Header %>'  MaxLength="25" />
            </div>
            <div class="editor-label">
                <label for="ModelYear">Årsmodell</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="ModelYear" runat="server" Text='<%# BindItem.ModelYear %>' MaxLength="4" />
            </div>
            <div class="editor-label">
                <label for="CarColor">Färg</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="CarColor" runat="server" Text='<%# BindItem.CarColor %>'  MaxLength="25"/>
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
                <asp:TextBox ID="Description" runat="server" Text='<%# BindItem.Description %>'  MaxLength="500" TextMode="MultiLine" ValidateRequestMode="Disabled"/>
            </div>
           
               <li>
                <asp:DropDownList ID="CarBrandDropDownList" runat="server"
                    SelectMethod="CarBrandMethod_GetData"
                    DataTextField="BrandName"
                    DataValueField="CarBrandID"/>
            </li>
              <div>
                <asp:LinkButton ID="LinkButton1"  runat="server" Text="Spara" CommandName="Insert"  CssClass="Green"/>
                <asp:HyperLink ID="HyperLink1"  runat="server" Text="Avbryt" NavigateUrl='<%$ RouteUrl:routename=Default %>' CssClass="Green" />
            </div>


        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
