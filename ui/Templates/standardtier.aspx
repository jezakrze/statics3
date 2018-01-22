<%@ Page Language="C#" MasterPageFile="~/Templates/TierPage.master"  AutoEventWireup="true"   %>
<%@ Register TagPrefix="Acsys" Namespace="AcsysWebControlLibrary" Assembly="AcsysWebControlLibrary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<div class="content">		
			<acsys:HotSpotServerControl id="StandardHotspotID" runat="server"  hotspotname="StandardHotSpotName" />
		</div>
</asp:Content>