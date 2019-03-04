using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KensuiteAPI.BrassRingJobs;
using KensuiteAPI.Areas.BrassRing.Jobs.Search;

namespace KensuiteAPI.Controllers
{
    public class JobsController : ApiController
    {
        
        // GET: api/Jobs
        [HttpPost]
        public KensuiteAPI.Areas.BrassRing.Jobs.Search.Search GetAllResult([FromBody]SearchUi searchUi)
        {
            KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData sobj = new KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData();

            //return sobj.getJobsByLocation();
            return sobj.getJobsBySearch(searchUi);
        }

        [HttpGet]
        public KensuiteAPI.Areas.BrassRing.Jobs.Search.Search GetSearchKeyword()
        {
            KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData sobj = new KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData();

            //return sobj.getJobsByLocation();
            return sobj.GetSearchkeyword();
        }




    }
}
