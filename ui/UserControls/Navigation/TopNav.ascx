<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="TopNav.ascx.cs" Inherits="Sikorsky_Life_PortWebApp.UI.UserControls.Navigation.TopNav" %>
<asp:SiteMapDataSource ID="MainSiteMap" runat="server" SiteMapProvider="MainSiteMap" ShowStartingNode="false" />
<div class="T1Nav">
		<!-- T1Nav Starts -->
    <asp:Repeater ID="rptTopNav" runat="server" DataSourceID="MainSiteMap">
        <HeaderTemplate>
            <ul id="qm0" class="qmmc">
        </HeaderTemplate>
        <FooterTemplate>
           <li class="qmclear">&nbsp;</li>
            </ul>
            <!-- Create Menu Settings: (Menu ID, Is Vertical, Show Timer, Hide Timer, On Click, Right to Left, Horizontal Subs, Flush Left) -->
            <script type="text/javascript">                qm_create(0, false, 0, 500, false, false, false, false);</script>
            <!-- QuickMenu Structure Ends [Menu 0] -->
            <div class="ReqQuoteButton">
                <a href="/sales-and-support/sales-and-support.aspx?frm=3">Request a Quote</a>
            </div>
        </FooterTemplate>
        <ItemTemplate>
            <li><a href="#" id="link" runat="server">Lorem Ipsum</a>
                <asp:Repeater ID="rprT2" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <FooterTemplate>
                        </ul></FooterTemplate>
                    <ItemTemplate>
                        <li><a href="#" id="link" runat="server"></a>
                        <asp:Repeater ID="rprT3" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <FooterTemplate>
                        </ul></FooterTemplate>
                    <ItemTemplate>
                        <li><a href="#" id="link" runat="server"></a></li>
                    </ItemTemplate>
                </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater></li>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    

		<!-- T1Nav Ends -->
	</div>