using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KensuiteAPI.Foundation;

namespace KensuiteAPI.Areas.BrassRing.Foundations
{
    public class Foundation
    {
        public string UpdateFoundation(string foundationXml)
        {
            string data=null;
            KensuiteAPI.Foundation.DispatchMessageSoapClient fobj=null;
            try
            {
                fobj = new DispatchMessageSoapClient("DispatchMessageSoap");

            }
            catch (Exception ex)
            {

            }
            finally { 
            data = fobj.Dispatch("<Envelope version=\"01.00\">< Sender >< Id > HRXMLEMPLID </ Id >< Credential > 25253 </ Credential ></ Sender >< Recipient >< Id /></ Recipient >< TransactInfo transactType = \"data\" >< TransactId > 15747 </ TransactId >< TimeStamp > 2019 - 02 - 06 22:31 PM </ TimeStamp ></ TransactInfo >< Packet >< PacketInfo packetType = \"data\" >< PacketId > 1 </ PacketId >< Action > SET </ Action >< Manifest > location </ Manifest ></ PacketInfo >< Payload >< ![CDATA[<? xml version = \"1.0\" ?>< Foundation_Data >< Foundation_Item >< Code > Dev </ Code >< Description language = \"EN\" > dev testing </ Description >< Status > I </ Status ></ Foundation_Item ></ Foundation_Data >]] ></ Payload ></ Packet ></ Envelope > ");
            }
            return data;
        }
    }
}