using KensuiteAPI.Areas.BrassRing.Jobs.Search.XmlMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KensuiteAPI.Areas.BrassRing.Jobs.Search
{
    public class Search
    {
        public List<EnvelopeUnitPacketPayloadResultSetJob> SearchResult { get; set; }
        public SearchUi SearchFilter { get; set; }
        public FieldMap FieldMaper { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Envelope
    {

        private EnvelopeSender senderField;

        private EnvelopeTransactInfo transactInfoField;

        private EnvelopeUnit unitField;

        private EnvelopeStatus statusField;

        private decimal versionField;

        /// <remarks/>
        public EnvelopeSender Sender
        {
            get
            {
                return this.senderField;
            }
            set
            {
                this.senderField = value;
            }
        }

        /// <remarks/>
        public EnvelopeTransactInfo TransactInfo
        {
            get
            {
                return this.transactInfoField;
            }
            set
            {
                this.transactInfoField = value;
            }
        }

        /// <remarks/>
        public EnvelopeUnit Unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        public EnvelopeStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeSender
    {

        private ushort idField;

        private ushort credentialField;

        /// <remarks/>
        public ushort Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public ushort Credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeTransactInfo
    {

        private string transactIdField;

        private string timeStampField;

        private string transactTypeField;

        private string transactIdField1;

        /// <remarks/>
        public string TransactId
        {
            get
            {
                return this.transactIdField;
            }
            set
            {
                this.transactIdField = value;
            }
        }

        /// <remarks/>
        public string TimeStamp
        {
            get
            {
                return this.timeStampField;
            }
            set
            {
                this.timeStampField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string transactType
        {
            get
            {
                return this.transactTypeField;
            }
            set
            {
                this.transactTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string transactId
        {
            get
            {
                return this.transactIdField1;
            }
            set
            {
                this.transactIdField1 = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnit
    {

        private EnvelopeUnitPacket packetField;

        private EnvelopeUnitStatus statusField;

        private string unitProcessorField;

        /// <remarks/>
        public EnvelopeUnitPacket Packet
        {
            get
            {
                return this.packetField;
            }
            set
            {
                this.packetField = value;
            }
        }

        /// <remarks/>
        public EnvelopeUnitStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UnitProcessor
        {
            get
            {
                return this.unitProcessorField;
            }
            set
            {
                this.unitProcessorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacket
    {

        private EnvelopeUnitPacketPacketInfo packetInfoField;

        private EnvelopeUnitPacketPayload payloadField;

        private EnvelopeUnitPacketStatus statusField;

        /// <remarks/>
        public EnvelopeUnitPacketPacketInfo PacketInfo
        {
            get
            {
                return this.packetInfoField;
            }
            set
            {
                this.packetInfoField = value;
            }
        }

        /// <remarks/>
        public EnvelopeUnitPacketPayload Payload
        {
            get
            {
                return this.payloadField;
            }
            set
            {
                this.payloadField = value;
            }
        }

        /// <remarks/>
        public EnvelopeUnitPacketStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPacketInfo
    {

        private byte packetIdField;

        private string packetTypeField;

        private string encryptedField;

        /// <remarks/>
        public byte packetId
        {
            get
            {
                return this.packetIdField;
            }
            set
            {
                this.packetIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string packetType
        {
            get
            {
                return this.packetTypeField;
            }
            set
            {
                this.packetTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string encrypted
        {
            get
            {
                return this.encryptedField;
            }
            set
            {
                this.encryptedField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPayload
    {

        private EnvelopeUnitPacketPayloadInputString inputStringField;

        private EnvelopeUnitPacketPayloadResultSet resultSetField;

        /// <remarks/>
        public EnvelopeUnitPacketPayloadInputString InputString
        {
            get
            {
                return this.inputStringField;
            }
            set
            {
                this.inputStringField = value;
            }
        }

        /// <remarks/>
        public EnvelopeUnitPacketPayloadResultSet ResultSet
        {
            get
            {
                return this.resultSetField;
            }
            set
            {
                this.resultSetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPayloadInputString
    {

        private ushort clientIdField;

        private ushort siteIdField;

        private byte pageNumberField;

        private byte outputXMLFormatField;

        private object authenticationTokenField;

        private object hotJobsField;

        private EnvelopeUnitPacketPayloadInputStringProximitySearch proximitySearchField;

        private object jobMatchCriteriaTextField;

        private object selectedSearchLocaleIdField;

        private EnvelopeUnitPacketPayloadInputStringQuestions questionsField;

        /// <remarks/>
        public ushort ClientId
        {
            get
            {
                return this.clientIdField;
            }
            set
            {
                this.clientIdField = value;
            }
        }

        /// <remarks/>
        public ushort SiteId
        {
            get
            {
                return this.siteIdField;
            }
            set
            {
                this.siteIdField = value;
            }
        }

        /// <remarks/>
        public byte PageNumber
        {
            get
            {
                return this.pageNumberField;
            }
            set
            {
                this.pageNumberField = value;
            }
        }

        /// <remarks/>
        public byte OutputXMLFormat
        {
            get
            {
                return this.outputXMLFormatField;
            }
            set
            {
                this.outputXMLFormatField = value;
            }
        }

        /// <remarks/>
        public object AuthenticationToken
        {
            get
            {
                return this.authenticationTokenField;
            }
            set
            {
                this.authenticationTokenField = value;
            }
        }

        /// <remarks/>
        public object HotJobs
        {
            get
            {
                return this.hotJobsField;
            }
            set
            {
                this.hotJobsField = value;
            }
        }

        /// <remarks/>
        public EnvelopeUnitPacketPayloadInputStringProximitySearch ProximitySearch
        {
            get
            {
                return this.proximitySearchField;
            }
            set
            {
                this.proximitySearchField = value;
            }
        }

        /// <remarks/>
        public object JobMatchCriteriaText
        {
            get
            {
                return this.jobMatchCriteriaTextField;
            }
            set
            {
                this.jobMatchCriteriaTextField = value;
            }
        }

        /// <remarks/>
        public object SelectedSearchLocaleId
        {
            get
            {
                return this.selectedSearchLocaleIdField;
            }
            set
            {
                this.selectedSearchLocaleIdField = value;
            }
        }

        /// <remarks/>
        public EnvelopeUnitPacketPayloadInputStringQuestions Questions
        {
            get
            {
                return this.questionsField;
            }
            set
            {
                this.questionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPayloadInputStringProximitySearch
    {

        private object distanceField;

        private object measurementField;

        private object countryField;

        private object stateField;

        private object cityField;

        private object zipCodeField;

        /// <remarks/>
        public object Distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }

        /// <remarks/>
        public object Measurement
        {
            get
            {
                return this.measurementField;
            }
            set
            {
                this.measurementField = value;
            }
        }

        /// <remarks/>
        public object Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public object State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public object City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public object zipCode
        {
            get
            {
                return this.zipCodeField;
            }
            set
            {
                this.zipCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPayloadInputStringQuestions
    {

        private EnvelopeUnitPacketPayloadInputStringQuestionsQuestion questionField;

        /// <remarks/>
        public EnvelopeUnitPacketPayloadInputStringQuestionsQuestion Question
        {
            get
            {
                return this.questionField;
            }
            set
            {
                this.questionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPayloadInputStringQuestionsQuestion
    {

        private ushort idField;

        private string valueField;

        private string sortorderField;

        private string sortField;

        /// <remarks/>
        public ushort Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Sortorder
        {
            get
            {
                return this.sortorderField;
            }
            set
            {
                this.sortorderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Sort
        {
            get
            {
                return this.sortField;
            }
            set
            {
                this.sortField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPayloadResultSet
    {

        private EnvelopeUnitPacketPayloadResultSetJob[] jobsField;

        private EnvelopeUnitPacketPayloadResultSetOtherInformation otherInformationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Job", IsNullable = false)]
        public EnvelopeUnitPacketPayloadResultSetJob[] Jobs
        {
            get
            {
                return this.jobsField;
            }
            set
            {
                this.jobsField = value;
            }
        }

        /// <remarks/>
        public EnvelopeUnitPacketPayloadResultSetOtherInformation OtherInformation
        {
            get
            {
                return this.otherInformationField;
            }
            set
            {
                this.otherInformationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPayloadResultSetJob
    {

        private EnvelopeUnitPacketPayloadResultSetJobQuestion[] questionField;

        private string hotJobField;

        private string lastUpdatedField;

        private string jobDetailLinkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Question")]
        public EnvelopeUnitPacketPayloadResultSetJobQuestion[] Question
        {
            get
            {
                return this.questionField;
            }
            set
            {
                this.questionField = value;
            }
        }

        /// <remarks/>
        public string HotJob
        {
            get
            {
                return this.hotJobField;
            }
            set
            {
                this.hotJobField = value;
            }
        }

        /// <remarks/>
        public string LastUpdated
        {
            get
            {
                return this.lastUpdatedField;
            }
            set
            {
                this.lastUpdatedField = value;
            }
        }

        /// <remarks/>
        public string JobDetailLink
        {
            get
            {
                return this.jobDetailLinkField;
            }
            set
            {
                this.jobDetailLinkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPayloadResultSetJobQuestion
    {

        private uint idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketPayloadResultSetOtherInformation
    {

        private byte totalRecordsFoundField;

        private byte maxPagesField;

        private byte startDocField;

        private byte pageNumberField;

        /// <remarks/>
        public byte TotalRecordsFound
        {
            get
            {
                return this.totalRecordsFoundField;
            }
            set
            {
                this.totalRecordsFoundField = value;
            }
        }

        /// <remarks/>
        public byte MaxPages
        {
            get
            {
                return this.maxPagesField;
            }
            set
            {
                this.maxPagesField = value;
            }
        }

        /// <remarks/>
        public byte StartDoc
        {
            get
            {
                return this.startDocField;
            }
            set
            {
                this.startDocField = value;
            }
        }

        /// <remarks/>
        public byte PageNumber
        {
            get
            {
                return this.pageNumberField;
            }
            set
            {
                this.pageNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitPacketStatus
    {

        private byte codeField;

        private string shortDescriptionField;

        private string longDescriptionField;

        /// <remarks/>
        public byte Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string ShortDescription
        {
            get
            {
                return this.shortDescriptionField;
            }
            set
            {
                this.shortDescriptionField = value;
            }
        }

        /// <remarks/>
        public string LongDescription
        {
            get
            {
                return this.longDescriptionField;
            }
            set
            {
                this.longDescriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeUnitStatus
    {

        private byte codeField;

        private string shortDescriptionField;

        private string longDescriptionField;

        /// <remarks/>
        public byte Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string ShortDescription
        {
            get
            {
                return this.shortDescriptionField;
            }
            set
            {
                this.shortDescriptionField = value;
            }
        }

        /// <remarks/>
        public string LongDescription
        {
            get
            {
                return this.longDescriptionField;
            }
            set
            {
                this.longDescriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeStatus
    {

        private byte codeField;

        private string shortDescriptionField;

        private string longDescriptionField;

        /// <remarks/>
        public byte Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string ShortDescription
        {
            get
            {
                return this.shortDescriptionField;
            }
            set
            {
                this.shortDescriptionField = value;
            }
        }

        /// <remarks/>
        public string LongDescription
        {
            get
            {
                return this.longDescriptionField;
            }
            set
            {
                this.longDescriptionField = value;
            }
        }
    }


}