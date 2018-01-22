using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sikorsky_Life_PortWebAppEngine.Helpers;
namespace Sikorsky_Life_PortWebApp.UI.UserControls
{
    public partial class events : System.Web.UI.UserControl
    {
        public int NumStories { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> events = new List<string>();
            if (Cache.Get("events") == null)
            {
                events =  Sikorsky_Life_PortWebAppEngine.Helpers.NewsHelper.GetEvents(System.Configuration.ConfigurationSettings.AppSettings["eventsPage"]);
                Cache.Insert("events", events, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
            {
                events = (List<string>)Cache.Get("events");
            }

            rprEvents.ItemDataBound += new RepeaterItemEventHandler(rprEvents_ItemDataBound);
            rprEvents.DataSource = events.Take(this.NumStories );
            rprEvents.DataBind();
        }

        void rprEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem )
            {
                return;
            }
            Literal litEvent = (Literal)e.Item.FindControl("litEvent");
            litEvent.Text = e.Item.DataItem.ToString().Replace("<p>", string.Empty ).Replace("</p>", string.Empty );
            
        }
    }
}