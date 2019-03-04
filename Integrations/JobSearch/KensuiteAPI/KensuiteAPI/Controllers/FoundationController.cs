using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KensuiteAPI.Controllers
{
    public class FoundationController : ApiController
    {
        // GET: api/Foundation
        [HttpGet]
        public string postFoundation()
        {
            KensuiteAPI.Areas.BrassRing.Foundations.Foundation fobj = new KensuiteAPI.Areas.BrassRing.Foundations.Foundation();

            //return sobj.getJobsByLocation();
            return fobj.UpdateFoundation("<Envelope version=\"01.00\">< Sender >< Id > HRXMLEMPLID </ Id >< Credential > 25253 </ Credential ></ Sender >< Recipient >< Id /></ Recipient >< TransactInfo transactType = \"data\" >< TransactId > 15747 </ TransactId >< TimeStamp > 2019 - 02 - 06 22:31 PM </ TimeStamp ></ TransactInfo >< Packet >< PacketInfo packetType = \"data\" >< PacketId > 1 </ PacketId >< Action > SET </ Action >< Manifest > location </ Manifest ></ PacketInfo >< Payload >< ![CDATA[<? xml version = \"1.0\" ?>< Foundation_Data >< Foundation_Item >< Code > Dev </ Code >< Description language = \"EN\" > dev testing </ Description >< Status > I </ Status ></ Foundation_Item ></ Foundation_Data >]] ></ Payload ></ Packet ></ Envelope > ");
        }
    }
}
