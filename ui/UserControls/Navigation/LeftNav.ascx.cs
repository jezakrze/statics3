using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Acsys.Web;

namespace Sikorsky_Life_PortWebApp.UI.UserControls.Navigation
{
    public partial class LeftNav : Sikorsky_Life_PortWebAppEngine.Web.UI.BaseUserControl
    {
        protected Acsys.Web.SiteMap.SiteMapNode currentNode;
        protected Acsys.Web.SiteMap.SiteMapNode tierOneNode;
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
            t2Nav.ItemDataBound += rptLeftNav_ItemDataBound;
            currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.CurrentNode;
            tierOneNode = SiteMapHelper.CurrentTierOneNode;
            if (currentNode == null)
            {
                currentNode = SiteMapHelper.CurrentNode;
                if (currentNode == null)
                {
                    currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.RootNode;
                }
            }

            if (tierOneNode == null)
            {
                return;
            }

            if (!SiteMap.RootNode.Equals(tierOneNode.ParentNode))
            {
                tierOneNode = (Acsys.Web.SiteMap.SiteMapNode)tierOneNode.ParentNode;
            }
            MainSiteMap.StartingNodeUrl = tierOneNode.Url;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoOnLoad();
        }

        protected void DoOnLoad()
        {
            // force the databind on postback
            if (IsPostBack)
            {
                t2Nav.DataBind();
            }

        }

        protected void rptLeftNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                HtmlAnchor link2 = (HtmlAnchor)e.Item.FindControl("link2");
                HtmlGenericControl li2 = (HtmlGenericControl)e.Item.FindControl("liItem2");

                if (link2 == null || li2 == null)
                {
                    return;
                }
                if (!String.IsNullOrEmpty(node.Href))
                {
                    link2.HRef = node.Href;
                }
                if (!String.IsNullOrEmpty(node.NavigationTitle))
                {
                    link2.InnerText = node.NavigationTitle;
                }

                if (!String.IsNullOrEmpty(node.Target))
                {
                    link2.Target = node.Target;
                }

                if (currentNode.Equals(node) || currentNode.IsDescendantOf(node))
                {
                    li2.Attributes.Add("class", "active");
                    if (node.HasChildNodes)
                    {
                        Repeater t3 = (Repeater)e.Item.FindControl("t3Nav");
                        t3.ItemDataBound += rptTier3_ItemDataBound;
                        t3.DataSource = node.ChildNodes;
                        t3.DataBind();
                    }
                }
                e.Item.Visible = true;
            }
        }
        protected void rptTier3_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

                HtmlAnchor link3 = (HtmlAnchor)e.Item.FindControl("link3");
                HtmlGenericControl li3 = (HtmlGenericControl)e.Item.FindControl("liItem3");

                if (link3 == null || li3 == null)
                {
                    return;
                }
                if (!String.IsNullOrEmpty(node.Href))
                {
                    link3.HRef = node.Href;
                }

                if (!String.IsNullOrEmpty(node.NavigationTitle))
                {
                    link3.InnerText = node.NavigationTitle;
                }

                if (!String.IsNullOrEmpty(node.Target))
                {
                    link3.Target = node.Target;
                }

                if (currentNode.Equals(node) || currentNode.IsDescendantOf(node))
                {
                    li3.Attributes.Add("class", "active");
                    if (node.HasChildNodes)
                    {
                        Repeater t4 = (Repeater)e.Item.FindControl("t4Nav");
                        t4.ItemDataBound += rptTier4_ItemDataBound;
                        t4.DataSource = node.ChildNodes;
                        t4.DataBind();
                    }
                }
                e.Item.Visible = true;
            }
        }
        protected void rptTier4_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

                HtmlAnchor link4 = (HtmlAnchor)e.Item.FindControl("link4");
                HtmlGenericControl li4 = (HtmlGenericControl)e.Item.FindControl("liItem4");

                if (link4 == null || li4 == null)
                {
                    return;
                }

                if (!String.IsNullOrEmpty(node.Href))
                {
                    link4.HRef = node.Href;
                }

                if (!String.IsNullOrEmpty(node.NavigationTitle))
                {
                    link4.InnerText = node.NavigationTitle;
                }

                if (!String.IsNullOrEmpty(node.Target))
                {
                    link4.Target = node.Target;
                }

                if (currentNode.Equals(node) || currentNode.IsDescendantOf(node))
                {
                    li4.Attributes.Add("class", "active");
                }

                e.Item.Visible = true;
            }
        }
    }
}