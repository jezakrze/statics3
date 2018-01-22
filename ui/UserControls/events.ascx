<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="events.ascx.cs" Inherits="Sikorsky_Life_PortWebApp.UI.UserControls.events" %>
<div class="top">
    <h2>
        Events</h2>
</div>
<asp:Repeater ID="rprEvents" runat="server">
    <HeaderTemplate>
        <div class="body1">
            <table border="0" cellpadding="0" cellspacing="0"><tbody>
    </HeaderTemplate>
    <FooterTemplate>
       </tbody> </table></div></FooterTemplate>
    <ItemTemplate>
        <tr valign="top">
            <td class="icons">
                <asp:Literal ID="litEvent" runat="server"></asp:Literal>
                <a href="/about-us/events.aspx">...More</a>
            </td>
        </tr>
    </ItemTemplate>
     
</asp:Repeater>
