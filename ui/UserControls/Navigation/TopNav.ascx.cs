using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Acsys.Web;
using Acsys.Web.SiteMap;
using Sikorsky_Life_PortWebAppEngine.Extension;

namespace Sikorsky_Life_PortWebApp.UI.UserControls.Navigation
{
    
    public partial class TopNav : Sikorsky_Life_PortWebAppEngine.Web.UI.BaseUserControl
    {
        protected Acsys.Web.SiteMap.SiteMapNode currentNode;
        private List<HtmlAnchor> anchorLinks = new List<HtmlAnchor>();
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
            rptTopNav.ItemDataBound += rptT1Nav_ItemDataBound;
            currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.CurrentNode;
            if (currentNode == null)
            {
                currentNode = SiteMapHelper.CurrentNode;
                if (currentNode == null)
                {
                    currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.RootNode;
                }
                
            }
            try
            {
                if (currentNode["a_BodyClass"] != null)
                {
                    if (this.Page.Master.FindControl("body") != null)
                    {
                        ((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("body")).Attributes["class"] = currentNode["a_BodyClass"];
                    }
                    else
                    {
                        if (this.Page.Master.Master.FindControl("body") != null)
                        {
                            ((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.Master.FindControl("body")).Attributes["class"] = currentNode["a_BodyClass"];
                        }
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("Error getting class: " + ex.ToString());
            }
        }
        private string getMetadata(Acsys.Web.SiteMap.SiteMapNode node)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (node == null)
            {
                return string.Empty ;
            }
            if (!string.IsNullOrEmpty(node.MetaDescription))
            {
                sb.AppendFormat("<meta name=\"description\" content=\"{0}\" />\n", node.MetaDescription);
            }
            if (!string.IsNullOrEmpty(node.MetaKeywords))
            {
                sb.AppendFormat("<meta name=\"keywords\" content=\"{0}\" />\n", node.MetaKeywords);
            }
            return sb.ToString();

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoOnLoad();
            Acsys.Web.SiteMap.SiteMapNode node = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.CurrentNode;
            if (node != null)
            {
                try
                {
                    //this.Page.Title = node.Title;
                    Literal litMeta = (Literal)this.Page.Master.FindControl("litMeta");
                    if (litMeta == null)
                    {
                        litMeta = (Literal)this.Page.Master.Master.FindControl("litMeta");
                    }
                    if (litMeta != null)
                    {
                        litMeta.Text = getMetadata(node);
                    }
                }
                catch  { }
            }
            Acsys.Web.SiteMap.SiteMapNode parentNode = node.ParentRoot();
            if (parentNode == null)
            {
                return;
            }
            string title = parentNode.NavigationTitle;
            var t1link =  anchorLinks.Where(link => link.InnerText == title).FirstOrDefault ();
            if (t1link == null) { return; }
            if (string.IsNullOrEmpty(t1link.Attributes["class"]))
            {
                t1link.Attributes.Add("class", "qmpersistent");
            }
            else {
                t1link.Attributes["class"] += " qmpersistent";
            }

             
        }

        protected void DoOnLoad()
        {
            // force the databind on postback
            
                rptTopNav.DataBind();
             
        }


        protected void rptT1Nav_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
               
                if (link == null  )
                {
                    return;
                }
                anchorLinks.Add(link);
                if (node.HasVisibleChildNodes() )
                {
                    Repeater rprT2 = (Repeater)e.Item.FindControl("rprT2");
                    link.Attributes.Add("class", "qmparent");
                    rprT2.DataSource = node.VisibleChildNodes();
                    rprT2.ItemDataBound += new RepeaterItemEventHandler(rprT2_ItemDataBound);
                    rprT2.DataBind();
                }
                Acsys.Web.SiteMap.SiteMapNode nextNode = (Acsys.Web.SiteMap.SiteMapNode)node.NextSibling;

              
                if (!String.IsNullOrEmpty(node.Href))
                {
                    link.HRef = node.Href;
                }
                if (!String.IsNullOrEmpty(node.NavigationTitle))
                {
                    link.InnerText = node.NavigationTitle;
                }
                if (!String.IsNullOrEmpty(node.Target))
                {
                    link.Target = node.Target;
                }

                e.Item.Visible = true;
            }
        }

        void rprT2_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                if (node.HasVisibleChildNodes() )
                {
                    if (e.Item.FindControl("rprT3") != null)
                    {
                    Repeater rprT3 = (Repeater)e.Item.FindControl("rprT3");
                    link.Attributes.Add("class", "qmparent");
                    rprT3.DataSource =  node.VisibleChildNodes(); ;
                    rprT3.ItemDataBound += new RepeaterItemEventHandler(rprT3_ItemDataBound);
                    rprT3.DataBind();
                    }
                }
                Acsys.Web.SiteMap.SiteMapNode nextNode = (Acsys.Web.SiteMap.SiteMapNode)node.NextSibling;


                if (!String.IsNullOrEmpty(node.Href))
                {
                    link.HRef = node.Href;
                }
                if (!String.IsNullOrEmpty(node.NavigationTitle))
                {
                    link.InnerText = node.NavigationTitle;
                }
                if (!String.IsNullOrEmpty(node.Target))
                {
                    link.Target = node.Target;
                }

                e.Item.Visible = true;
            }
        }

        void rprT3_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                if (node.HasVisibleChildNodes() )
                {
                    if (e.Item.FindControl("rprT3") != null)
                    {
                        Repeater rprT3 = (Repeater)e.Item.FindControl("rprT3");
                        link.Attributes.Add("class", "qmparent");
                        rprT3.DataSource = node.VisibleChildNodes();
                        rprT3.ItemDataBound += new RepeaterItemEventHandler(rprT3_ItemDataBound);
                        rprT3.DataBind();
                    }
                }
                Acsys.Web.SiteMap.SiteMapNode nextNode = (Acsys.Web.SiteMap.SiteMapNode)node.NextSibling;


                if (!String.IsNullOrEmpty(node.Href))
                {
                    link.HRef = node.Href;
                }
                if (!String.IsNullOrEmpty(node.NavigationTitle))
                {
                    link.InnerText = node.NavigationTitle;
                }
                if (!String.IsNullOrEmpty(node.Target))
                {
                    link.Target = node.Target;
                }

                e.Item.Visible = true;
            }
        }
    }
}