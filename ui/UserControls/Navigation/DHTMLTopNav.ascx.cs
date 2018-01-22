using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class UI_UserControls_Navigation_DHTMLTopNav : Sikorsky_Life_PortWebAppEngine.Web.UI.BaseUserControl
{
    protected Acsys.Web.SiteMap.SiteMapNode currentNode;
    private int menuCount = 0;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        DoInit();
    }

    protected void DoInit()
    {
        //enter user code here instead of Page_Load when dealing with the SiteMapNodes.
        currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.CurrentNode;

        if (currentNode == null)
        {
            currentNode = (Acsys.Web.SiteMap.SiteMapNode)SiteMap.RootNode;
        }
    }

    protected void TopNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item == null || e.Item.DataItem == null)
            return;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.Visible = false;

            Acsys.Web.SiteMap.SiteMapNode node = (Acsys.Web.SiteMap.SiteMapNode)e.Item.DataItem;
            if (node == null)
            {
                Acsys.EventLogHelper.WriteToErrorLog("webapp", "Could not find the SiteMapNode with the name '" + Convert.ToString(e.Item.DataItem) + "' for the Top Navigation.");
                return;
            }

            if (node.Visible == false)
            {
                return;
            }

            HtmlAnchor link = (HtmlAnchor)e.Item.FindControl("link");
            HtmlGenericControl ul = (HtmlGenericControl)e.Item.FindControl("ulSubMenu");
            HtmlGenericControl item = (HtmlGenericControl)e.Item.FindControl("item");
            Repeater rptT2 = e.Item.FindControl("rptT2") as Repeater;

            e.Item.ID = "_" + e.Item.ItemIndex.ToString();

            if (link == null)
            {
                return;
            }
            menuCount++;

            if (item != null)
            {
                if (node.Equals(currentNode) || currentNode.IsDescendantOf(node))
                {
                    item.Attributes.Add("class", "current");
                }
                else
                {
                    item.Attributes.Add("class", node.Description);
                }
            }

            if (!String.IsNullOrEmpty(node.Href))
            {
                link.HRef = node.Href;
                link.InnerText = node.NavigationTitle;
            }

            if (!String.IsNullOrEmpty(node.Target))
            {
                link.Target = node.Target;
            }
            e.Item.Visible = true;

            if (VisibleChildCount(node) <= 0)
            {
                ul.Visible = false;
                rptT2.Visible = false;
                return;
            }
            if (VisibleChildCount((Acsys.Web.SiteMap.SiteMapNode)SiteMap.RootNode) == menuCount)
            {
                ul.Attributes.Add("style", "margin:0px 0px 0px -78px");
            }

            rptT2.ItemDataBound += new RepeaterItemEventHandler(rptT2_ItemDataBound);
            rptT2.DataSource = node.ChildNodes;
            rptT2.DataBind();

        }
    }
    void rptT2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.Visible = false;

            Acsys.Web.SiteMap.SiteMapNode node = e.Item.DataItem as Acsys.Web.SiteMap.SiteMapNode;

            if (node == null || node.Visible == false)
            {
                // Nothing logged here intentionally, if this happens something when sour with the site map
                // file and there'd already be something logged.  No need to bloat event logs with too many 
                // exceptions.
                return;
            }

            HtmlAnchor lnkT2 = e.Item.FindControl("lnkT2") as HtmlAnchor;

            if (lnkT2 == null)
            {
                return;
            }

            e.Item.ID = "_" + e.Item.ItemIndex.ToString();
            e.Item.Visible = true;
            lnkT2.HRef = node.Href;
            lnkT2.InnerText = node.NavigationTitle;

            if (!String.IsNullOrEmpty(node.Target))
            {
                lnkT2.Target = node.Target;
            }

        }
    }


    private int VisibleChildCount(Acsys.Web.SiteMap.SiteMapNode node)
    {
        int count = 0;
        foreach (Acsys.Web.SiteMap.SiteMapNode child in node.ChildNodes)
        {
            if (child.Visible) count++;
        }
        return count;
    }

}
