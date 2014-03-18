<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ss222yw_Projekt.Pages.Shared.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <p>
        Vi är beklagar att ett fel inträffade och vi inte kunde hantera din förfrågan.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" Text="Tillbaka till startsidan" NavigateUrl='<%$ RouteUrl:routename=Default %>' />
    </p>
</asp:Content>
