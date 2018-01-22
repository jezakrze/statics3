using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls ;
using Sikorsky_Life_PortWebAppEngine.BusinessObjects;
namespace Sikorsky_Life_PortWebApp.UI.UserControls
{
    public partial class PressReleases : System.Web.UI.UserControl
    {
        public int NumStories{get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                rprNews.ItemDataBound += new RepeaterItemEventHandler(rprNews_ItemDataBound);
                List<NewsStory> news = new List<NewsStory>();
                if (Cache.Get("news") != null)
                {
                    news = (List<NewsStory>)Cache.Get("news");
                }
                else
                {
                    news = Sikorsky_Life_PortWebAppEngine.Helpers.NewsHelper.GetNews(System.Configuration.ConfigurationSettings.AppSettings["newsRss"]);//.Skip(page * pagesize).Take(pagesize);
                    Cache.Insert("news", news, null, DateTime.Now.AddMinutes(5), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                rprNews.DataSource = news.Take(this.NumStories);
                rprNews.DataBind();
            }
            catch { }
        }

        void rprNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ){
                return;
            }
            Literal litStory = (Literal)e.Item.FindControl("litStory");
            HtmlAnchor linkNews = (HtmlAnchor)e.Item.FindControl("linkNews");
                NewsStory story = (NewsStory)e.Item.DataItem;
            litStory.Text = string.Format("{0:MM.dd.yy}-{1}", story.PubDate, story.Title);
            linkNews.HRef = "/news-story.aspx?Id=" + story.ID;


        }
    }
}