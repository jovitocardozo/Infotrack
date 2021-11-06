using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infotrack.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            searchEngineURL = string.Empty;
            searchKeywords = string.Empty;
            targetURLSearch = string.Empty;
        }

        public SearchModel(string SearchEngineURL, string SearchKeywords, string TargetURLSearch)
        {
            searchEngineURL = SearchEngineURL;
            searchKeywords = SearchKeywords;
            targetURLSearch = TargetURLSearch;
        }

        public string searchEngineURL { get; set; }

        public string searchKeywords { get; set; }

        public string targetURLSearch { get; set; }

    }
}