using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS7Starter.Settings.InstitutionInformation
{
    public class EnvironmentParam
    {
        private string _key;
        private string _value;

        /// <summary>
        /// キー名称の取得・設定
        /// </summary>
        [System.Xml.Serialization.XmlAttribute]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>
        /// 値の取得・設定
        /// </summary>
        [System.Xml.Serialization.XmlAttribute]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
