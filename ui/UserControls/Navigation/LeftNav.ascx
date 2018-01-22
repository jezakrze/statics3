<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="LeftNav.ascx.cs" Inherits="Sikorsky_Life_PortWebApp.UI.UserControls.Navigation.LeftNav" %>
<asp:SiteMapDataSource ID="MainSiteMap" runat="server" SiteMapProvider="MainSiteMap" ShowStartingNode="false" />
<div class="TierContentLeftNav">
<!-- TierContentLeft Starts -->
    <div class="T2Nav">
        <!-- T2Nav Starts -->
        <asp:Repeater ID="t2Nav" runat="server" DataSourceID="MainSiteMap">
            <HeaderTemplate><ul></HeaderTemplate>
            <ItemTemplate><li id="liItem2" runat="server" ><a id="link2" runat="server" /></li>
                <asp:Repeater ID="t3Nav" runat="server">
                    <HeaderTemplate><li class="T3Nav"><ul></HeaderTemplate>
                    <ItemTemplate><li id="liItem3" runat="server"><a id="link3" runat="server" /></li>
                        <asp:Repeater ID="t4Nav" runat="server">
                            <HeaderTemplate><li class="T4Nav"><ul></HeaderTemplate>
                            <ItemTemplate><li id="liItem4" runat="server"><a id="link4" runat="server" /></li></ItemTemplate>
                            <FooterTemplate></ul></li></FooterTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                    <FooterTemplate></ul></li></FooterTemplate>
                </asp:Repeater>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
        <!-- T2Nav Ends -->
    </div>
<!-- TierContentLeft Ends -->
</div>