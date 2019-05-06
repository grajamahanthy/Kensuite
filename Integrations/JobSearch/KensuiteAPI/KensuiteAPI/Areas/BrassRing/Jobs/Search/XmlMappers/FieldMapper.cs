using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KensuiteAPI.Areas.BrassRing.Jobs.Search.XmlMappers
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class FieldMap
    {

        private ushort clientIdField;

        private FieldMapFilterQuestion[] searchFilterField;

        private FieldMapKeywordQuestion[] searchKeywordField;

        private FieldMapResultQuestion[] searchResultField;

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
        [System.Xml.Serialization.XmlArrayItemAttribute("FilterQuestion", IsNullable = false)]
        public FieldMapFilterQuestion[] SearchFilter
        {
            get
            {
                return this.searchFilterField;
            }
            set
            {
                this.searchFilterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("KeywordQuestion", IsNullable = false)]
        public FieldMapKeywordQuestion[] SearchKeyword
        {
            get
            {
                return this.searchKeywordField;
            }
            set
            {
                this.searchKeywordField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ResultQuestion", IsNullable = false)]
        public FieldMapResultQuestion[] SearchResult
        {
            get
            {
                return this.searchResultField;
            }
            set
            {
                this.searchResultField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FieldMapFilterQuestion
    {

        private uint idField;

        private string titleField;

        /// <remarks/>
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
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FieldMapKeywordQuestion
    {

        private uint idField;

        private string titleField;

        private string typeField;

        private string watermarkField;

        private string isSearchAllField;

        /// <remarks/>
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
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string Watermark
        {
            get
            {
                return this.watermarkField;
            }
            set
            {
                this.watermarkField = value;
            }
        }

        /// <remarks/>
        public string IsSearchAll
        {
            get
            {
                return this.isSearchAllField;
            }
            set
            {
                this.isSearchAllField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FieldMapResultQuestion
    {

        private uint idField;

        private string titleField;

        /// <remarks/>
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
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    }


}

