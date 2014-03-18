<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ss222yw_Projekt.Pages.CarAdPages.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <span><strong>Inloggad</strong></span>
        <div>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%$ RouteUrl:routename=Logga %>' Text="Logga ut" CssClass="SitMasterColor" />

    </div>
    

    <asp:FormView ID="CarAdFormView" runat="server"
        ItemType="ss222yw_Projekt.Model.CarAd"
        RenderOuterTable="false"
        SelectMethod="CarAdFormView_GetItem">
        <ItemTemplate>
            <li>
                <asp:DropDownList ID="UserDropDownList" runat="server"
                    SelectMethod="UserMethod_GetData"
                    DataTextField="Name"
                    DataValueField="UserID" AutoPostBack="true" />
            </li>

            <div>
        <asp:Button ID="Button1" runat="server" Text="Mina sidor" OnClick="Button1_Click" CssClass="Blue" />
    </div>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>

