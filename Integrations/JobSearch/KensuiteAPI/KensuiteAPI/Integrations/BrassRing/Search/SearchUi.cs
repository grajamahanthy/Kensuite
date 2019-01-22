using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KensuiteAPI.Integrations.BrassRing.Search
{
    public class SearchUi
    {
        public List<FilterCategory> FilterCategories { get; set; }
        public List<Question> SearchQuestions { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Watermark { get; set; }
        public string SearchKey { get; set; }
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
}