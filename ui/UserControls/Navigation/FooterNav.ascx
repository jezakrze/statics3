<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="FooterNav.ascx.cs" Inherits="Sikorsky_Life_PortWebApp.UI.UserControls.Navigation.FooterNav" %>
<asp:SiteMapDataSource ID="FooterSiteMap" runat="server" SiteMapProvider="FooterSiteMap" ShowStartingNode="false" />
<div class="HomeFooter">
    <asp:Repeater ID="rptFooterNav" runat="server" DataSourceID="FooterSiteMap">
        <HeaderTemplate> </HeaderTemplate>
        <ItemTemplate><a id="link" runat="server" /></ItemTemplate>
        <SeparatorTemplate> | </SeparatorTemplate>
        <FooterTemplate> </FooterTemplate>
    </asp:Repeater>
	</div>
    
	 