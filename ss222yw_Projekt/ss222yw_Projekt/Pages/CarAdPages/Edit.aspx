<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Redigera Bilannons
    </h1>

    <asp:FormView ID="FormView1" runat="server"></asp:FormView>

    <asp:FormView ID="FormView2" runat="server" ItemType="ss222yw_Projekt.Model.CarAd"
         DataKeyNames="CarAdID" DefaultMode="Edit" RenderOuterTable="false" SelectMethod="CarAdFormView_GetItem" UpdateMethod="CarAdFormView_UpdateItem"></asp:FormView>
</asp:Content>
