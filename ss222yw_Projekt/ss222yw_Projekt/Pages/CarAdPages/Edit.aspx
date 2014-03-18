<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Edit" %>
<asp:Content  ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Redigera Bilannons
    </h1>
   
      <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Images/Close.png" CausesValidation="False" CssClass="closebutton"/>
    </asp:Panel>

    <asp:ValidationSummary  runat="server" CssClass="validation-summary-errors" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="validation-summary-errors" ValidationGroup="EditValidation" ShowModelStateErrors="false"/>
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
                 <asp:RequiredFieldValidator ID="HeaderRequiredFieldValidator"
                      runat="server" ErrorMessage="Rubrik måste anges."
                      ControlToValidate="Header" Display="None"
                      ValidationGroup="EditValidation">
                 </asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="ModelYear">Årsmodell</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="ModelYear" runat="server" Text='<%# BindItem.ModelYear %>' />
                <asp:RequiredFieldValidator ID="ModelYearRequiredFieldValidator1"
                      runat="server" ErrorMessage="Årsmodellen måste anges."
                      ControlToValidate="ModelYear" Display="None"
                      ValidationGroup="EditValidation">
                 </asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="CarColor">Färg</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="CarColor" runat="server" Text='<%# BindItem.CarColor %>' />
                <asp:RequiredFieldValidator ID="CarColorRequiredFieldValidator1"
                      runat="server" ErrorMessage="Färgen måste anges."
                      ControlToValidate="CarColor" Display="None"
                      ValidationGroup="EditValidation">
                 </asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="Price">Pris</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' />
                <asp:RequiredFieldValidator ID="PriceRequiredFieldValidator1"
                      runat="server" ErrorMessage="Priset måste anges."
                      ControlToValidate="Price" Display="None"
                      ValidationGroup="EditValidation">
                 </asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="Description">Beskrivning</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Description" runat="server" Text='<%# BindItem.Description %>'  TextMode="MultiLine"/>
                <asp:RequiredFieldValidator ID="DescriptionRequiredFieldValidator1"
                      runat="server" ErrorMessage="Beskrivning måste anges."
                      ControlToValidate="Description" Display="None"
                      ValidationGroup="EditValidation">
                 </asp:RequiredFieldValidator>
            </div>
         
           <li>
               <asp:DropDownList ID="DropDownList1" runat="server"
                   ItemType="ss222yw_Projekt.Model.CarBrand"
                    DataTextField="BrandName"
                    DataValueField="CarBrandID"
                     Enabled="true"
                     SelectMethod="EditGetCarBrands"/>
         </li>

            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara annonsen" CommandName="Update" CausesValidation="false"  CssClass="Green"/>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt"  NavigateUrl='<%# GetRouteUrl("CarAdDetails", new { id = Item.CarAdID }) %>' CssClass="Green" />
            </div>
           </EditItemTemplate>
        </asp:FormView>
</asp:Content>
 
          
      