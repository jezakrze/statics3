<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PressReleases.ascx.cs" Inherits="Sikorsky_Life_PortWebApp.UI.UserControls.PressReleases" %>
<div class="top">
                    <h2>
                        Press Releases</h2>
                </div>


<asp:Repeater ID="rprNews" runat="server">
<HeaderTemplate><div class="body1">
                    <table border="0" cellpadding="0" cellspacing="0">

</HeaderTemplate>
<FooterTemplate>
</table>
                </div>

</FooterTemplate>
<ItemTemplate>
<tr valign="top">
                            <td class="icons">
                                <asp:Literal ID="litStory" runat="server" /> &hellip;<a href="" id="linkNews" runat="server">More</a>
                            </td>
                        </tr>

</ItemTemplate>
</asp:Repeater>