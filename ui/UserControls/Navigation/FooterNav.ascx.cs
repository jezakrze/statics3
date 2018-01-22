using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Acsys;
using Acsys.Web;

namespace Sikorsky_Life_PortWebApp.UI.UserControls.Navigation
{
    public partial class FooterNav : Sikorsky_Life_PortWebAppEngine.Web.UI.BaseUserControl
    {
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
            this.EnableViewState = false;
            this.rptFooterNav.ItemDataBound += new RepeaterItemEventHandler(rptFooterNav_ItemDataBound);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.DoOnLoad();
        }

        protected void DoOnLoad()
        {
            // force the databind on postback
            if (this.IsPostBack)
            {
                this.rptFooterNav.DataBind();
            }
        }

        void rptFooterNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Visible = false;

                Acsys.Web.SiteMap.SiteMapNode node = e.Item.DataItem as Acsys.Web.SiteMap.SiteMapNode;

                if (node == null)
                {
                    return;
                }

                HtmlAnchor link = e.Item.FindControl("link") as HtmlAnchor;

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