using Infotrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Infotrack.Controllers
{
    public class SEOSearchPositionController : Controller
    {
        // GET: SEOSearchPosition
        public ActionResult Index()
        {
            SearchModel searchModel = new SearchModel("https://www.google.co.uk/search?num=100&q=", "land registry search", "www.infotrack.co.uk");
            

            return View(searchModel);
        }

        [HttpPost]
        public ActionResult Search(SearchModel searchModel)
        {
            var client = new WebClient();
            client.Encoding = System.Text.Encoding.GetEncoding("utf-8");

            var completeSearchURL = searchModel.searchEngineURL + searchModel.searchKeywords.Replace(' ','+');
            var content = client.DownloadString(completeSearchURL);
            var targetWebsite = searchModel.targetURLSearch;

            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(content);
            var result = document.DocumentNode.SelectNodes("//div//div[contains(@class, 'ZINbbc xpd O9g5cc uUPGi')]/div[contains(@class, 'kCrYT')][1]/a");

            List<int> websitePlaces = new List<int>();
            int placeCounter = 0;

            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    if (item.Attributes["href"].Value.Contains(targetWebsite))
                    {
                        //record result in place
                        websitePlaces.Add(placeCounter);
                    }

                    //increase counter
                    placeCounter = placeCounter + 1;
                }
            }

            ViewBag.SearchPosition = String.Join(", ", websitePlaces);
            return View("Index");
        }
    }
}