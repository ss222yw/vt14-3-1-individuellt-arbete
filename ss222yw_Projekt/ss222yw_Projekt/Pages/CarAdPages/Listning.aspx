<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listning.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Listning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <h1>
        Bilannonser
    </h1>


    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <asp:ListView ID="CarAdView" runat="server" ItemType="ss222yw_Projekt.Model.CarAd"
         SelectMethod="CarAdView_GetData"
         DataKeyNames="CarAdID"></asp:ListView>

 
</asp:Content>
