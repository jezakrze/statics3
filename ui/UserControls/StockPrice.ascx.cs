using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using log4net;
using System.Diagnostics;
namespace Sikorsky_Life_PortWebApp.UI.UserControls
{
    
    public partial class StockPrice : Sikorsky_Life_PortWebAppEngine.Web.UI.BaseUserControl 
    {
        const string PriceURL = "http://finance.yahoo.com/d/quotes.csv?s=UTX&f=l1c";
        protected static ILog Log = LogManager.GetLogger(typeof(Sikorsky_Life_PortWebApp.UI.UserControls.StockPrice));
        protected void Page_Load(object sender, EventArgs e)
        {
            string  stockprice = Cache.Get("stockprice") as string ;
            if(string.IsNullOrEmpty(stockprice)){
                stockprice = GetStockPrice();
                if (stockprice == string.Empty)
                {
                    return;
                }
                Cache.Insert("stockprice", stockprice, null, DateTime.UtcNow.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            litPrice.Text  = stockprice;
            Debug.WriteLine("Setting stock price to " + stockprice);
        }

        public string GetStockPrice(){
            //"83.40,\"-0.48 - -0.57%\"\r\n"
            try
            {
                using (WebClient client = new WebClient())
                {
                    char[] delimiters = new char[] { ',', ' ', '\r', '\n' };
                    string results = client.DownloadString(PriceURL);
                    string[] quotes = results.Split(delimiters);
                    return string.Format("{0:c2} {1}", Acsys.SafeConvert.ToDecimal( quotes[0]), quotes[1].Replace("\"", string.Empty));
                }
            }
            catch (Exception ex) {
                Log.ErrorFormat("Error getting stock price: {0}", ex.ToString());
                Debug.WriteLine("Error getting stock price: " + ex.ToString());
            }
            return string.Empty;
        }
    }
}