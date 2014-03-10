<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Bilannons
    </h1>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <asp:FormView ID="CarAdFormView" runat="server" ItemType="ss222yw_Projekt.Model.CarAd"
         RenderOuterTable="false"
         SelectMethod="CarAdFormView_GetItem"></asp:FormView>
</asp:Content>

