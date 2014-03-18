<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarBrandPage.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
            <h1>
        Ta bort bilmärken
    </h1>
    
       <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Images/Close.png" CausesValidation="False" CssClass="closebutton"/>
    </asp:Panel>
       <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:PlaceHolder runat="server" ID="ConfirmationPlaceHolder">
        <p>
            Är du säker på att du vill ta bort bilmärken <strong>
                <asp:Literal runat="server" ID="CarBrandName" ViewStateMode="Enabled" /></strong>?
        </p>
    </asp:PlaceHolder>
    <div>
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ta bort"
            OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>'  CssClass="Red"/>
        <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Avbryt" CssClass="Green"/>
    </div>

</asp:Content>
