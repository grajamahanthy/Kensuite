using KensuiteAPI.Integrations.BrassRing.Search;
using KensuiteAPI.XmlMappers;
using System;
using System.Web.Http;

namespace KensuiteAPI.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        [HttpPost]
        public XmlMappers.Search GetAllResult([FromBody]SearchUi searchUi)
        {
            KensuiteAPI.BrassRing.Search.SearchData sobj = new KensuiteAPI.BrassRing.Search.SearchData();

            //return sobj.getJobsByLocation();
            return sobj.getJobsBySearch(searchUi);
        }

        [HttpGet]
        public XmlMappers.Search GetSearchKeyword()
        {
            KensuiteAPI.BrassRing.Search.SearchData sobj = new KensuiteAPI.BrassRing.Search.SearchData();

            //return sobj.getJobsByLocation();
            return sobj.GetSearchkeyword();
        }
        


    }
}
