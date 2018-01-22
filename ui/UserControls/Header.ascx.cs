using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acsys;
using Acsys.Web;
using Acsys.Web.SiteMap;

namespace Sikorsky_Life_PortWebApp.UI.UserControls
{
    public partial class Header : Sikorsky_Life_PortWebAppEngine.Web.UI.BaseUserControl
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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoOnLoad();
        }

        protected void DoOnLoad()
        {
            Acsys.Web.SiteMap.SiteMapNode parentNode = currentNode;
            if (currentNode.IsDescendantOf(tierOneNode))
            {
                parentNode = (Acsys.Web.SiteMap.SiteMapNode)currentNode.ParentNode;
            }

            if (currentNode.Images.ContainsKey(ImageKeys.HeaderImg))
            {
                img.Src = currentNode.Images[ImageKeys.HeaderImg].Src;
                img.Alt = currentNode.NavigationTitle;
            }
            else if (currentNode.IsDescendantOf(tierOneNode) && parentNode.Images.ContainsKey(ImageKeys.HeaderImg))
            {
                img.Src = parentNode.Images[ImageKeys.HeaderImg].Src;
                img.Alt = parentNode.NavigationTitle;
            }
            else if (tierOneNode != null && tierOneNode.Images.ContainsKey(ImageKeys.HeaderImg))
            {
                img.Src = tierOneNode.Images[ImageKeys.HeaderImg].Src;
                img.Alt = tierOneNode.NavigationTitle;
            }
            else
            {
                img.Visible = false;
            }
        }

    }
}