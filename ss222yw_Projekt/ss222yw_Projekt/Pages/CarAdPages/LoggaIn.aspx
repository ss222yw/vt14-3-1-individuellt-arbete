<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoggaIn.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.LoggaIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
<FormView ID="LoggaInForm" runat="server">
  
         <span><strong>SellYourCar AB hemsidan</strong></span>
    <p>För att kunna lägga till , ändra , ta bort bilannonser så  var vänlig och <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%$ RouteUrl:routename=User %>' Text="Logga In" CssClass="SitMasterColor" /></p>
         









    </FormView>
</asp:Content>
