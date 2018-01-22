<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="GlobalNav.ascx.cs"
    Inherits="Sikorsky_Life_PortWebApp.UI.UserControls.Navigation.GlobalNav" %>
<asp:SiteMapDataSource ID="GlobalSiteMap" runat="server" SiteMapProvider="GlobalSiteMap"
    ShowStartingNode="false" />
<asp:Repeater ID="rptGlobalNav" runat="server" DataSourceID="GlobalSiteMap">
    <HeaderTemplate>
        <div class="GlobalNav">
            <!-- GlobalNav Starts -->
    </HeaderTemplate>
    <ItemTemplate>
        <a id="link" runat="server" />
    </ItemTemplate>
    <FooterTemplate>
        <!-- GlobalNav Ends -->
        </div>
    </FooterTemplate>
</asp:Repeater>
