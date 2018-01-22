<%@ Control Language="C#" AutoEventWireup="false" Inherits="UI_UserControls_Navigation_DHTMLTopNav" Codebehind="DHTMLTopNav.ascx.cs" %>
<script type="text/javascript">
/* <![CDATA[ */if(window.showHelp&&!window.XMLHttpRequest){if(qmad.bvis.indexOf("qm_over_select(b.cdiv);")==-1){qmad.bvis+="qm_over_select(b.cdiv);";qmad.bhide+="qm_over_select(a,1);";}};function qm_over_select(a,hide){var z;if((z=window.qmv)&&(z=z.addons)&&(z=z.over_select)&&!z["on"+qm_index(a)])return;if(!a.settingsid){var v=a;while(!qm_a(v))v=v[qp];a.settingsid=v.id;}var ss=qmad[a.settingsid];if(!ss)return;if(!ss.overselects_active)return;if(!hide&&!a.hasselectfix){var f=document.createElement("IFRAME");f.style.position="absolute";f.style.filter="alpha(opacity=0)";f.src="javascript:false;";f=a.parentNode.appendChild(f);f.frameborder=0;a.hasselectfix=f;}var b=a.hasselectfix;if(b){if(hide)b.style.display="none";else {if(a.hasrcorner&&a.hasrcorner.style.visibility=="inherit")a=a.hasrcorner;var oxy=0;if(a.hasshadow&&a.hasshadow.style.visibility=="inherit")oxy=parseInt(ss.shadow_offset);if(!oxy)oxy=0;b.style.width=a.offsetWidth+oxy;b.style.height=a.offsetHeight+oxy;b.style.top=a.style.top;b.style.left=a.style.left;b.style.margin=a.currentStyle.margin;b.style.display="block";}}}/* ]]> */

//Add-On Code: Persistent States With Auto Open Subs Option
if(!qmad.sopen_auto){qmad.sopen_auto=new Object();qmad.sopen_auto.log=new Array();if(window.attachEvent)window.attachEvent("onload",qm_sopen_auto_init);else  if(window.addEventListener)window.addEventListener("load",qm_sopen_auto_init,1);};function qm_sopen_auto_init(e,go){if(window.qmv)return;if(!go){setTimeout("qm_sopen_auto_init(null,1)",10);return;}var i;var ql=qmad.sopen_auto.log;for(i=0;i<10;i++){var ss=qmad["qm"+i];if(!ss||!ss.sopen_auto_enabled)continue;var curl=unescape(window.location.href).toLowerCase();curl=qm_sopen_auto_clean(curl);var a;if(a=document.getElementById("qm"+i)){var dd=a.getElementsByTagName("A");for(var j=0;j<dd.length;j++){var aurl=unescape(dd[j].getAttribute("href",1)).toLowerCase();aurl=qm_sopen_auto_clean(aurl);loc=curl.length-aurl.length;if(aurl&&aurl!="#"&&loc>-1&&curl.indexOf(aurl)+1){var wa=dd[j];if(wa.cdiv)wa=wa.cdiv;while(!qm_a(wa)){if(wa.tagName=="DIV"){if(wa.idiv){if(ss.sopen_auto_show_subs)ql.push(wa.idiv);x2("qmpersistent",wa.idiv,1);}}else  if(wa.tagName=="A")x2("qmpersistent",wa,1);wa=wa[qp];}}}}}var se=0;var sc=0;if(qmad.tree){se=qmad.tree.etype;sc=qmad.tree.ctype;qmad.tree.etype=0;qmad.tree.ctype=0;}for(i=ql.length-1;i>=0;i--){if(ql[i]){qm_oo(new Object(),ql[i],1);qm_li=null;}}if(qmad.tree){qmad.tree.etype=se;qmad.tree.ctype=sc;}};function qm_sopen_auto_clean(url){url=url.replace(/\:/g,"");url=url.replace("localhost","");url=url.replace("file","");url=url.replace(/\\/g,"");url=url.replace(/\//g,"");url=url.replace(/\./g,"");return url;}
</script>
<asp:SiteMapDataSource ID="MainSiteMap" runat="server" SiteMapProvider="MainSiteMap" ShowStartingNode="false" />
<div class="T1Nav">
    <ul id="qm0" class="qmmc">
        <asp:Repeater ID="rptTopNav" runat="server" DataSourceID="MainSiteMap" OnItemDataBound="DHTMLTopNav_ItemDataBound">
        <ItemTemplate>
            <li runat="server" id="item">
                <a href="" id="link" runat="server" ></a>
                <ul runat="server" id="ulSubMenu">
        	    <asp:Repeater ID="rptT2" runat="server">
			    <ItemTemplate>
			        <li>
			            <a id="lnkT2" runat="server"></a>
        		    </li>
	            </ItemTemplate>
	            </asp:Repeater>
	            </ul>
            </li>
        </ItemTemplate>
        </asp:Repeater>
       	<li class="qmclear">&nbsp;</li>
    </ul>

    <!-- Create Menu Settings: (Menu ID, Is Vertical, Show Timer, Hide Timer, On Click, Right to Left, Horizontal Subs, Flush Left) -->
    <script type="text/javascript">qm_create(0,false,0,100,false,false,false,false);</script>

</div>

		    
			
		   