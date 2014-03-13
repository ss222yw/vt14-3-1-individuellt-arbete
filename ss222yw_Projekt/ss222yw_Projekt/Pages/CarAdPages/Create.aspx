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
                <asp:LinkButton  runat="server" Text="Spara" CommandName="Insert" />
                <asp:HyperLink  runat="server" Text="Avbryt" NavigateUrl='<%$ RouteUrl:routename=Default %>' />
            </div>

               <li>
                <asp:DropDownList ID="CarBrandDropDownList" runat="server"
                    SelectMethod="CarBrandMethod_GetData"
                    DataTextField="BrandName"
                    DataValueField="CarBrandID"/>
            </li>


        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
