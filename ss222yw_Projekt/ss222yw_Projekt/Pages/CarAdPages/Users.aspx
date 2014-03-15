<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />

    <asp:FormView ID="UserFormView" runat="server" ItemType="ss222yw_Projekt.Model.User" RenderOuterTable="false" SelectMethod="UsersDropDown_GetData1">
        <ItemTemplate>
             <li>
    <asp:DropDownList ID="UsersDropDownList" runat="server"         
         DataTextField="Name"
         DataValueField="UserID"
        SelectMethod="UsersDropDown_GetData"
          />
                 </li>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Gå vidare"   NavigateUrl='<%# GetRouteUrl("CarAd", new { id = Item.UserID }) %>' CssClass="Green" />
            </div>
            
          </ItemTemplate>
        </asp:FormView>
</asp:Content>
