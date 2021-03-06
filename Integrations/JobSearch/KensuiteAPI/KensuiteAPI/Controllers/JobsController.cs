﻿using System;
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
        public KensuiteAPI.Areas.BrassRing.Jobs.Search.Search GetAllResult([FromBody]SearchUi searchUi, String cId)
        {
            KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData sobj = new KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData();

            //return sobj.getJobsByLocation();
            //string yourJson = Newtonsoft.Json.JsonConvert.SerializeObject(p);
            KensuiteAPI.Areas.BrassRing.Jobs.Search.Search alldata= sobj.getJobsBySearch(searchUi, cId);
          //  return Newtonsoft.Json.JsonConvert.SerializeObject(alldata);
            return sobj.getJobsBySearch(searchUi, cId);
        }
        // GET: api/Jobs
        [HttpGet]
        public List<EnvelopeUnitPacketPayloadResultSetJob> GetAllResult(string cId)
        {
            SearchData searchData  = new SearchData();
            List<EnvelopeUnitPacketPayloadResultSetJob> list= searchData.GetAllData(cId);
            return list;
        }

        [HttpGet]
        public KensuiteAPI.Areas.BrassRing.Jobs.Search.Search GetSearchKeyword(string cId)
        {
            KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData sobj = new KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData();

            //return sobj.getJobsByLocation();
            return sobj.GetSearchkeyword(cId);
        }

        [HttpGet]
        public SearchUi GetFeturedJobs(string cId)
        {
            KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData sobj = new KensuiteAPI.Areas.BrassRing.Jobs.Search.SearchData();

            //return sobj.getJobsByLocation();
            return sobj.GetHotJobs(cId);
        }


    }
}
