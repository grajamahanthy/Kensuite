using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using KensuiteAPI.BrassRingJobs;
using KensuiteAPI.Areas.BrassRing.Jobs.Search.XmlMappers;
using KensuiteAPI.Areas.BrassRing.Jobs.Search;
using System.Configuration;

namespace KensuiteAPI.Areas.BrassRing.Jobs.Search
{
    public class SearchData
    {
        //Search All Result
        public List<EnvelopeUnitPacketPayloadResultSetJob> GetAllData()
        {
            BrassRingJobs.WebRouterSoapClient obj = new WebRouterSoapClient("WebRouterSoap");
            // string data = obj.route("<Envelope version=\"01.00\"> <Sender><Id>12345</Id><Credential>25253</Credential></Sender> <TransactInfo transactId=\"1\" transactType=\"data\"><TransactId>01/27/2010</TransactId> <TimeStamp>12:00:00 AM</TimeStamp></TransactInfo> <Unit UnitProcessor=\"SearchAPI\"> <Packet> <PacketInfo packetType=\"data\"> <packetId>1</packetId></PacketInfo><Payload><InputString> <ClientId>25253</ClientId><SiteId>5700</SiteId> <PageNumber>1</PageNumber><OutputXMLFormat>0</OutputXMLFormat> <AuthenticationToken/><HotJobs/> <ProximitySearch><Distance/> <Measurement/> <Country/><State/> <City/><zipCode/> </ProximitySearch><JobMatchCriteriaText/> <SelectedSearchLocaleId/> <Questions> <Question Sortorder=\"ASC\" Sort=\"No\"> <Id>35992</Id> <Value> <![CDATA[TG_SEARCH_ALL]]></Value></Question></Questions></InputString> </Payload> </Packet> </Unit></Envelope>");
            string data = obj.route("<Envelope version=\"01.00\"> <Sender><Id>12345</Id><Credential>25253</Credential></Sender> <TransactInfo transactId=\"1\" transactType=\"data\"><TransactId>01/27/2010</TransactId> <TimeStamp>12:00:00 AM</TimeStamp></TransactInfo> <Unit UnitProcessor=\"SearchAPI\"> <Packet> <PacketInfo packetType=\"data\"> <packetId>1</packetId></PacketInfo><Payload><InputString> <ClientId>25253</ClientId><SiteId>5584</SiteId> <PageNumber>1</PageNumber><OutputXMLFormat>0</OutputXMLFormat> <AuthenticationToken/><HotJobs/> <JobDescription>yes</JobDescription><ProximitySearch><Distance/> <Measurement/> <Country/><State/> <City/><zipCode/> </ProximitySearch><JobMatchCriteriaText/> <SelectedSearchLocaleId/> <Questions> <Question Sortorder=\"ASC\" Sort=\"No\"> <Id>35992</Id> <Value> <![CDATA[TG_SEARCH_ALL]]></Value></Question></Questions><ReturnJobDetailQues>1671,1653,59081,53211,35992</ReturnJobDetailQues></InputString> </Payload> </Packet> </Unit></Envelope>");
            data = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>" + data;

            ////////////////////////////////////////////////////////Get Search Result 
            //Loading Result XML
            XmlDocument searchResultXml = new XmlDocument();
            searchResultXml.LoadXml(data);
            XmlNodeList resultDoc = searchResultXml.GetElementsByTagName("Jobs")[0].ChildNodes;
            //Converting Result XML to C# Object
            string ResultData = searchResultXml.InnerXml;
            SerializeDeserialize<Envelope> SearchResultSerializer = new SerializeDeserialize<Envelope>();
            Envelope SearchResults = SearchResultSerializer.DeserializeData(ResultData);

            return SearchResults.Unit.Packet.Payload.ResultSet.Jobs.ToList();
        }

        //Field Mapper
        public FieldMap GetFieldMapper()
        {
            ////////////////////////////////////////////////////////Get Field Mapper 
            //Loading Field Mapper XML
            XmlDocument doc = new XmlDocument();
            string fmPath = ConfigurationManager.AppSettings.Get("FieldMapper");
            doc.Load(fmPath);
            //Converting Field Mapper XML to C# Object
            string FieldMapData = doc.InnerXml;
            SerializeDeserialize<FieldMap> FieldMapSerializer = new SerializeDeserialize<FieldMap>();
            FieldMap FieldMapResults = FieldMapSerializer.DeserializeData(FieldMapData);

            return FieldMapResults;
        }

        //Search By Filter
        public Search getJobsBySearch(SearchUi searchui)
        {
           // GetHotJobs();
            List<EnvelopeUnitPacketPayloadResultSetJob> searchDataSource = GetAllData();
            FieldMap fieldMapper = GetFieldMapper();
            Search srch = new Search();
            IEnumerable<EnvelopeUnitPacketPayloadResultSetJob> res = searchDataSource;
            bool searchKeysExist = false;

            ////Get Search Results By Question Keywords
            searchKeysExist = searchui != null && searchui.SearchQuestions != null && searchui.SearchQuestions.Count() > 0
                                   && searchui.SearchQuestions.Where(x => !string.IsNullOrEmpty(x.SearchKey)).Count() > 0;
            if (searchKeysExist)
            {
                foreach (var q in searchui.SearchQuestions)
                {
                    if (!string.IsNullOrEmpty(q.SearchKey))
                        res = (res.Where(x =>
                                            (x.Question.Where(r =>
                                            r.Id == q.Id &&
                                            (Convert.ToString(r.Value == null ? "" : r.Value).ToLower()).Contains(Convert.ToString(q.SearchKey).Trim().ToLower())).Count() > 0)));
                }
            }
            List<EnvelopeUnitPacketPayloadResultSetJob> filterItemResults = (searchui.IsHotJob ? (res.Where(y=>y.HotJob.ToLower() =="yes").ToList()) : res.ToList());

            ////Get Search Results By Filter
            bool IsFilterCatExist = false;
            if (searchui.FilterCategories != null)
                IsFilterCatExist = searchui.FilterCategories.Where(x => (x.FilterItems.Where(y => y.IsSelected == true)).Count() > 0).Count() > 0;

            if (IsFilterCatExist)
            {
                List<EnvelopeUnitPacketPayloadResultSetJob> catResults = filterItemResults;
                foreach (var f in searchui.FilterCategories)
                {
                    List<EnvelopeUnitPacketPayloadResultSetJob> itemResults = new List<EnvelopeUnitPacketPayloadResultSetJob>();
                    foreach (var fitem in f.FilterItems)
                    {
                        if (fitem.IsSelected)
                        {
                            var itemRes = (catResults.Where(x =>
                                                (x.Question.Where(r => r.Id == f.Id &&
                                                (Convert.ToString(r.Value == null ? "" : r.Value).ToLower()).Contains(Convert.ToString(fitem.FilterItemTitle).Trim().ToLower())).Count() > 0)));

                            itemResults.AddRange(itemRes.ToList());
                        }
                    }
                    if (itemResults.Count() > 0)
                        catResults = itemResults;
                }
                filterItemResults = catResults;
            }
            srch.SearchResult = filterItemResults;

            //Get Field Mapper
            srch.FieldMaper = fieldMapper;

            //searchui.CurrentFilter = (!searchui.IsCurrentFilterSelected ? )

            //Get Search Filter
            srch.SearchFilter = GetSearchFilter(srch.FieldMaper, searchDataSource, searchui.FilterCategories);

            srch.SearchFilter.SearchQuestions = searchui.SearchQuestions;

            srch.SearchFilter.IsHotJob = searchui.IsHotJob;

            return srch;
        }

        public List<FilterCategory> GetLeftFilter(FieldMap fieldMapper, List<EnvelopeUnitPacketPayloadResultSetJob> jobs, List<FilterCategory> filterCats, bool isHotJob)
        {
            //Get Left Filter
            List<FilterCategory> lstFc = new List<FilterCategory>();
            foreach (FieldMapFilterQuestion field in fieldMapper.SearchFilter)
            {
                FilterCategory fc = new FilterCategory();
                fc.Title = field.Title;
                fc.Id = field.Id;

                if (isHotJob)
                    jobs = jobs.Where(z => z.HotJob.ToLower() == "yes").ToList();

                var fItems = jobs
                    .SelectMany(x => x.Question.Where(q1 => q1.Id == field.Id).Select(y => new { qid = y.Id, qval = y.Value }))
                    .GroupBy(a => new
                    {
                        id = a.qid,
                        value = a.qval
                    })
                    .Select(a => new
                    {
                        questionid = a.Key.id,
                        filterTitle = a.Key.value,
                        FilterItemResultCount = a.Count()
                    });

                // var fItems = (data.Unit.Packet.Payload.ResultSet.Jobs.GroupBy(j => j.Location).Select(lis => new { FilterItemTitle = lis.Key, FilterItemResultCount = lis.Count() }));

                List<FilterItem> lstFi = new List<FilterItem>();
                foreach (var i in fItems.ToList())
                {
                    FilterItem fi = new FilterItem();
                    fi.FilterItemTitle = i.filterTitle;
                    fi.FilterItemResultCount = i.FilterItemResultCount;

                    if (filterCats != null)
                        fi.IsSelected = ((filterCats.Where(x => x.Id == fc.Id)
                                                .Select(y => y.FilterItems
                                                .Where(z => z.FilterItemTitle == fi.FilterItemTitle && z.IsSelected)))
                                                .FirstOrDefault().Count() > 0);

                    lstFi.Add(fi);
                }
                fc.FilterItems = lstFi;

                lstFc.Add(fc);
            }
            return lstFc;
        }

        public SearchUi GetSearchFilter(FieldMap fieldMapper, List<EnvelopeUnitPacketPayloadResultSetJob> jobs, List<FilterCategory> filterCats)
        {
            try
            {
                SearchUi uiObj = new SearchUi();
               
                    List<FilterCategory> lstFc = GetLeftFilter(fieldMapper, jobs, filterCats, false);
                    uiObj.FilterCategories = lstFc;
               

                List<FilterCategory> featuredLstFc = GetLeftFilter(fieldMapper, jobs, filterCats, true);
                uiObj.FeaturedFilterCategories = featuredLstFc;

                //Get Top Key Filter
                List<Question> lstSearchKeyQuestions = new List<Question>();
                foreach (FieldMapKeywordQuestion field in fieldMapper.SearchKeyword)
                {
                    Question q = new Question();
                    q.Id = field.Id;
                    q.Title = field.Title;
                    q.Watermark = field.Watermark;
                    lstSearchKeyQuestions.Add(q);
                }
                uiObj.SearchQuestions = lstSearchKeyQuestions;

                return uiObj;
            }
            catch(Exception ex)
            {
                return new SearchUi();
            }
        }

        public Search GetSearchkeyword()
        {
            Search srch = new Search();
            List<EnvelopeUnitPacketPayloadResultSetJob> searchDataSource = GetAllData();
            IEnumerable<EnvelopeUnitPacketPayloadResultSetJob> res = searchDataSource;

            FieldMap fieldMapper = GetFieldMapper();
            //Get Field Mapper
            SearchUi uiObj = new SearchUi();
            List<Question> lstSearchKeyQuestions = new List<Question>();
            List<location> location = new List<Jobs.Search.location>();
            foreach (FieldMapKeywordQuestion field in fieldMapper.SearchKeyword)
            {
                Question q = new Question();
                q.Id = field.Id;
                q.Title = field.Title;
                q.Type = field.Type;
                q.Watermark = field.Watermark;
                lstSearchKeyQuestions.Add(q);
                if (field.Type == "singleselect")
                {

                    var data = res.Select(x => x.Question).ToList();
                }

            }
            uiObj.SearchQuestions = lstSearchKeyQuestions;





            srch.SearchFilter = uiObj;
            return srch;
        }

        public SearchUi GetHotJobs()
        {
            SearchUi uiObj = new SearchUi();
            
            FieldMap fieldMapper = GetFieldMapper();
            List<EnvelopeUnitPacketPayloadResultSetJob> searchDataSource = GetAllData();
            IEnumerable<EnvelopeUnitPacketPayloadResultSetJob> res = searchDataSource;
            List<EnvelopeUnitPacketPayloadResultSetJob> filterItemResults =res.Where(y=>y.HotJob.ToLower() =="yes").ToList();
            List<FilterCategory> obj = null;
            List<FilterCategory> lstFc = GetLeftFilter(fieldMapper, filterItemResults, obj, false);
            uiObj.FilterCategories = lstFc;

            List<FilterCategory> featuredLstFc = GetLeftFilter(fieldMapper, filterItemResults, obj, true);
            uiObj.FeaturedFilterCategories= featuredLstFc;
            return uiObj;
        }

    }
}