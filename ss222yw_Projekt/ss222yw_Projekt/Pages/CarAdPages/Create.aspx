<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <h1>
            Ny Bilannons
        </h1>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <asp:FormView ID="CarAdView" runat="server" ItemType="ss222yw_Projekt.Model.CarAd"
         DefaultMode="Insert"
         RenderOuterTable="false"
         InsertMethod="CarAdView_InsertItem"></asp:FormView>
</asp:Content>
