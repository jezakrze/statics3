<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BreadCrumb.ascx.cs" Inherits="Sikorsky_Life_PortWebApp.UI.UserControls.Navigation.BreadCrumb" %>
<asp:SiteMapDataSource ID="MainSiteMap" runat="server" SiteMapProvider="MainSiteMap" ShowStartingNode="false" />
<asp:Repeater ID="rprBreadcrumb" runat="server">
<HeaderTemplate><div class="BreadCrumbs"></HeaderTemplate>
<FooterTemplate></div></FooterTemplate>
<ItemTemplate><a href="#"  runat="server" id="item"></a></ItemTemplate>
<SeparatorTemplate> &gt; </SeparatorTemplate>
</asp:Repeater>
 

		