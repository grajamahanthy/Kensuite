using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KensuiteAPI.BrassRingJobs;

namespace KensuiteAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {

            BrassRingJobs.WebRouterSoapClient obj = new WebRouterSoapClient("WebRouterSoap");
            string data = obj.route("<Envelope version=\"01.00\"> <Sender><Id>12345</Id><Credential>25253</Credential></Sender> <TransactInfo transactId=\"1\" transactType=\"data\"><TransactId>01/27/2010</TransactId> <TimeStamp>12:00:00 AM</TimeStamp></TransactInfo> <Unit UnitProcessor=\"SearchAPI\"> <Packet> <PacketInfo packetType=\"data\"> <packetId>1</packetId></PacketInfo><Payload><InputString> <ClientId>25253</ClientId><SiteId>5584</SiteId> <PageNumber>1</PageNumber><OutputXMLFormat>0</OutputXMLFormat> <AuthenticationToken/><HotJobs/> <JobDescription>yes</JobDescription><ProximitySearch><Distance/> <Measurement/> <Country/><State/> <City/><zipCode/> </ProximitySearch><JobMatchCriteriaText/> <SelectedSearchLocaleId/> <Questions> <Question Sortorder=\"ASC\" Sort=\"No\"> <Id>35992</Id> <Value> <![CDATA[TG_SEARCH_ALL]]></Value></Question></Questions><ReturnJobDetailQues>1671,1653,59081,53211</ReturnJobDetailQues></InputString> </Payload> </Packet> </Unit></Envelope>");
            data = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>" + data;
            return data;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
