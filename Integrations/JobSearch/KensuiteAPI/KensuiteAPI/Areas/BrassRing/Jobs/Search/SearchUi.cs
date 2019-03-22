using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KensuiteAPI.Areas.BrassRing.Jobs.Search
{

    public class SearchUi
    {
        public List<FilterCategory> FilterCategories { get; set; }
        public List<FilterCategory> FeaturedFilterCategories { get; set; }
        public List<Question> SearchQuestions { get; set; }
        public bool IsHotJob { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Watermark { get; set; }
        public string SearchKey { get; set; }
        public List<location> location { get; set; }
    }

    public class FilterCategory
    {
        public string Title { get; set; }
        public List<FilterItem> FilterItems { get; set; }
        public int Id { get; set; }
    }

    public class FilterItem
    {
        public string FilterItemTitle { get; set; }
        public int FilterItemResultCount { get; set; }
        public bool IsSelected { get; set; }
    }

    public class location
    {
        public int Id { get; set; }
        public List<string> value { get;}
    }

}