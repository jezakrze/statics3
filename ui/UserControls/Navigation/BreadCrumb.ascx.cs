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
    public partial class BreadCrumb : Sikorsky_Life_PortWebAppEngine.Web.UI.BaseUserControl
    {
        protected Acsys.Web.SiteMap.SiteMapNode tierOneNode;
        protected Acsys.Web.SiteMap.SiteMapNode currentNode;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            DoInit();
        }

        protected void DoInit()
        {
            //enter user code here instead of Page_Load when dealing with the SiteMapNodes.
            currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.CurrentNode;
            tierOneNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMapHelper.CurrentTierOneNode;
            rprBreadcrumb.ItemDataBound += new RepeaterItemEventHandler(rprBreadcrumb_ItemDataBound);
            

            if (currentNode == null)
            {
                currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMapHelper.CurrentNode;
                 
                if (currentNode == null)
                {
                    currentNode =    (Acsys.Web.SiteMap.SiteMapNode)SiteMap.RootNode;
                }
            }
            List<Acsys.Web.SiteMap.SiteMapNode> nodes = new List<Acsys.Web.SiteMap.SiteMapNode>();
            nodes.Add(currentNode);
            while (currentNode.ParentNode != null)
            {
                currentNode = (Acsys.Web.SiteMap.SiteMapNode)currentNode.ParentNode;
                 
                nodes.Add(currentNode);
                
            }
            nodes.Reverse();
            rprBreadcrumb.DataSource = nodes;
            rprBreadcrumb.DataBind();
            //if (tierOneNode == null)
            //{
            //    tierOneNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.RootNode;
            //}

        }

        void rprBreadcrumb_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Acsys.Web.SiteMap.SiteMapNode node = (Acsys.Web.SiteMap.SiteMapNode)e.Item.DataItem;
                //<a href="#" class="active" runat="server" id="item">
                HtmlAnchor anchor = (HtmlAnchor)e.Item.FindControl("item");
                anchor.HRef = node.Url;
                anchor.InnerText = node.NavigationTitle;
                if (node.Url == currentNode.Url)
                {
                    anchor.Attributes.Add("class", "active");
                }
            }
        }

        //protected void BreadCrumb_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item == null || e.Item.DataItem == null)
        //        return;

        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        e.Item.Visible = false;

        //        Acsys.Web.SiteMap.SiteMapNode node = (Acsys.Web.SiteMap.SiteMapNode)e.Item.DataItem;
        //        if (node == null)
        //        {
        //            EventLogHelper.WriteToErrorLog("webapp", "Could not find the SiteMapNode with the name '" + Convert.ToString(e.Item.DataItem) + "' for the Bread Crumb.");
        //            return;
        //        }
        //        if (currentNode.Equals(SiteMap.RootNode) || tierOneNode.Equals(SiteMap.RootNode))
        //        {
        //            return;
        //        }
        //        if ((!node.IsDescendantOf(tierOneNode)) && (!tierOneNode.Equals(node)))
        //        {
        //            return;
        //        }

        //        HtmlAnchor t1Link = (HtmlAnchor)e.Item.FindControl("t1Link");
        //        Label lbl1Link = (Label)e.Item.FindControl("lbl1Link");
        //        Label t1Seperator = (Label)e.Item.FindControl("t1Seperator");
        //        t1Seperator.Text = " > ";

        //        if (t1Link == null || lbl1Link == null)
        //        {
        //            return;
        //        }

        //        if (!String.IsNullOrEmpty(node.Href))
        //        {
        //            t1Link.HRef = node.Href;
        //        }

        //        if (!String.IsNullOrEmpty(node.NavigationTitle))
        //        {
        //            t1Link.InnerText = node.NavigationTitle;
        //            t1Link.Title = node.NavigationTitle;
        //            lbl1Link.Text = node.NavigationTitle;
        //        }

        //        if (currentNode.Equals(node))
        //        {
        //            t1Link.Visible = false;
        //        }
        //        else
        //        {
        //            lbl1Link.Visible = false;
        //        }

        //        e.Item.Visible = true;
        //        if (currentNode.IsDescendantOf(node))
        //        {
        //            Repeater rptBreadCrumbT2 = (Repeater)e.Item.FindControl("rptBreadCrumbT2");
        //            if (rptBreadCrumbT2 != null)
        //            {
        //                rptBreadCrumbT2.ItemDataBound += new RepeaterItemEventHandler(BreadCrumbT2_ItemDataBound);
        //                rptBreadCrumbT2.DataSource = tierOneNode.ChildNodes;
        //                rptBreadCrumbT2.DataBind();
        //            }
        //        }
        //    }
        //}

        //protected void BreadCrumbT2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item == null || e.Item.DataItem == null)
        //        return;

        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        e.Item.Visible = false;

        //        Acsys.Web.SiteMap.SiteMapNode node = (Acsys.Web.SiteMap.SiteMapNode)e.Item.DataItem;
        //        if (node == null)
        //        {
        //            EventLogHelper.WriteToErrorLog("webapp", "Could not find the SiteMapNode with the name '" + Convert.ToString(e.Item.DataItem) + "' for the Bread Crumb.");
        //            return;
        //        }

        //        if ((!node.IsDescendantOf(tierOneNode)) && (!tierOneNode.Equals(node)))
        //        {
        //            return;
        //        }

        //        if (!node.Equals(currentNode) && !currentNode.IsDescendantOf(node))
        //        {
        //            return;
        //        }

        //        HtmlAnchor t2Link = (HtmlAnchor)e.Item.FindControl("t2Link");
        //        Label lbl2Link = (Label)e.Item.FindControl("lbl2Link");
        //        Label t2Seperator = (Label)e.Item.FindControl("t2Seperator");
        //        t2Seperator.Text = " > ";

        //        if (t2Link == null || lbl2Link == null)
        //        {
        //            return;
        //        }

        //        if (!String.IsNullOrEmpty(node.Href))
        //        {
        //            t2Link.HRef = node.Href;
        //        }

        //        if (!String.IsNullOrEmpty(node.NavigationTitle))
        //        {
        //            t2Link.InnerHtml = node.NavigationTitle;
        //            t2Link.Title = node.NavigationTitle;
        //            lbl2Link.Text = node.NavigationTitle;
        //        }

        //        if (currentNode.Equals(node))
        //        {
        //            t2Link.Visible = false;
        //        }
        //        else
        //        {
        //            lbl2Link.Visible = false;
        //        }

        //        e.Item.Visible = true;
        //        if (currentNode.IsDescendantOf(node))
        //        {
        //            Repeater rptBreadCrumbT3 = (Repeater)e.Item.FindControl("rptBreadCrumbT3");
        //            if (rptBreadCrumbT3 != null)
        //            {
        //                rptBreadCrumbT3.ItemDataBound += new RepeaterItemEventHandler(BreadCrumbT3_ItemDataBound);
        //                rptBreadCrumbT3.DataSource = node.ChildNodes;
        //                rptBreadCrumbT3.DataBind();
        //            }
        //        }
        //    }
        //}

        //protected void BreadCrumbT3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item == null || e.Item.DataItem == null)
        //        return;

        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        e.Item.Visible = false;

        //        Acsys.Web.SiteMap.SiteMapNode node = (Acsys.Web.SiteMap.SiteMapNode)e.Item.DataItem;
        //        if (node == null)
        //        {
        //            EventLogHelper.WriteToErrorLog("webapp", "Could not find the SiteMapNode with the name '" + Convert.ToString(e.Item.DataItem) + "' for the Bread Crumb.");
        //            return;
        //        }

        //        if ((!node.IsDescendantOf(tierOneNode)) && (!tierOneNode.Equals(node)))
        //        {
        //            return;
        //        }

        //        if (!node.Equals(currentNode) && !currentNode.IsDescendantOf(node))
        //        {
        //            return;
        //        }

        //        HtmlAnchor t3Link = (HtmlAnchor)e.Item.FindControl("t3Link");
        //        Label lbl3Link = (Label)e.Item.FindControl("lbl3Link");
        //        Label t3Seperator = (Label)e.Item.FindControl("t3Seperator");
        //        t3Seperator.Text = " > ";

        //        if (t3Link == null || lbl3Link == null)
        //        {
        //            return;
        //        }

        //        if (!String.IsNullOrEmpty(node.Href))
        //        {
        //            t3Link.HRef = node.Href;
        //        }

        //        if (!String.IsNullOrEmpty(node.NavigationTitle))
        //        {
        //            t3Link.InnerHtml = node.NavigationTitle;
        //            t3Link.Title = node.NavigationTitle;
        //            lbl3Link.Text = node.NavigationTitle;
        //        }

        //        if (currentNode.Equals(node))
        //        {
        //            t3Link.Visible = false;
        //        }
        //        else
        //        {
        //            lbl3Link.Visible = false;
        //        }

        //        e.Item.Visible = true;

        //        if (currentNode.IsDescendantOf(node))
        //        {
        //            Repeater rptBreadCrumbT4 = (Repeater)e.Item.FindControl("rptBreadCrumbT4");
        //            if (rptBreadCrumbT4 != null)
        //            {
        //                rptBreadCrumbT4.ItemDataBound += new RepeaterItemEventHandler(BreadCrumbT4_ItemDataBound);
        //                rptBreadCrumbT4.DataSource = node.ChildNodes;
        //                rptBreadCrumbT4.DataBind();
        //            }
        //        }
        //    }
        //}

        //protected void BreadCrumbT4_ItemDataBound(object sender, RepeaterItemEventArgs e)
        // {
        //if (e.Item == null || e.Item.DataItem == null)
        //    return;

        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    e.Item.Visible = false;

        //    Acsys.Web.SiteMap.SiteMapNode node = (Acsys.Web.SiteMap.SiteMapNode)e.Item.DataItem;
        //    if (node == null)
        //    {
        //        EventLogHelper.WriteToErrorLog("webapp", "Could not find the SiteMapNode with the name '" + Convert.ToString(e.Item.DataItem) + "' for the Bread Crumb.");
        //        return;
        //    }

        //    if (!node.Equals(currentNode))
        //    {
        //        return;
        //    }

        //    HtmlAnchor t4Link = (HtmlAnchor)e.Item.FindControl("t4Link");
        //    Label lbl4Link = (Label)e.Item.FindControl("lbl4Link");
        //    Label t4Seperator = (Label)e.Item.FindControl("t4Seperator");
        //    t4Seperator.Text = " > ";

        //    if (t4Link == null || lbl4Link == null)
        //    {
        //        return;
        //    }

        //    if (!String.IsNullOrEmpty(node.Href))
        //    {
        //        t4Link.HRef = node.Href;
        //    }

        //    if (!String.IsNullOrEmpty(node.NavigationTitle))
        //    {
        //        t4Link.InnerHtml = node.NavigationTitle;
        //        t4Link.Title = node.NavigationTitle;
        //        lbl4Link.Text = node.NavigationTitle;
        //    }

        //    if (currentNode.Equals(node))
        //    {
        //        t4Link.Visible = false;
        //    }
        //    else
        //    {
        //        lbl4Link.Visible = false;
        //    }
        //    e.Item.Visible = true;
        //}
    }
}
