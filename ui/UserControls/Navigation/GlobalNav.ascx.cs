using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Acsys;
using Acsys.Web;

namespace Sikorsky_Life_PortWebApp.UI.UserControls.Navigation
{
    public partial class GlobalNav : Sikorsky_Life_PortWebAppEngine.Web.UI.BaseUserControl
    {
        protected Acsys.Web.SiteMap.SiteMapNode currentNode;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            DoOnInit();
        }

        /// <summary>
        /// Wire up Events for any child controls.
        /// </summary>
        protected void DoOnInit()
        {
            EnableViewState = false;
            rptGlobalNav.ItemDataBound += rptGlobal_ItemDataBound;
            currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.CurrentNode;
            if (currentNode == null)
            {
                currentNode = SiteMapHelper.CurrentNode;
                if (currentNode == null)
                {
                    currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.RootNode;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoOnLoad();
        }

        protected void DoOnLoad()
        {
            if (IsPostBack)
            {
                rptGlobalNav.DataBind();
            }
        }

        protected void rptGlobal_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                Acsys.Web.SiteMap.SiteMapNode node = e.Item.DataItem as Acsys.Web.SiteMap.SiteMapNode;

                if (node == null)
                {
                    // Nothing logged here intentionally, if this happens something when sour with the site map
                    // file and there'd already be something logged.  No need to bloat event logs with too many 
                    // exceptions.
                    return;
                }
                if (!node.Visible)
                {
                    return;
                }

                HtmlAnchor link = (HtmlAnchor)e.Item.FindControl("link");



                if (link == null)
                {
                    return;
                }

                if (!String.IsNullOrEmpty(node.Href))
                {
                    link.HRef = node.Href;
                }

                if (!String.IsNullOrEmpty(node.NavigationTitle))
                {
                    link.InnerHtml = node.NavigationTitle;
                }

                if (!String.IsNullOrEmpty(node.Target))
                {
                    link.Target = node.Target;
                }
                //if (node.NextSibling == null)
                //    litSep.Visible = false;

                e.Item.Visible = true;
            }
        }
    }
}