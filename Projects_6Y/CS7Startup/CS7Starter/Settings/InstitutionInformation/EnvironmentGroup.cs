using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS7Starter.Settings.InstitutionInformation
{
    public class EnvironmentGroup
    {
        private string _name;
        private List<EnvironmentParam> _enviromentParamList = new List<EnvironmentParam>();

        /// <summary>
        /// グループ名称の取得・設定
        /// </summary>
        [System.Xml.Serialization.XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// パラメータ情報一覧の取得・設定
        /// </summary>
        [System.Xml.Serialization.XmlArray]
        public List<EnvironmentParam> EnviromentParamList
        {
            get { return _enviromentParamList; }
            set { _enviromentParamList = value; }
        }
    }
}
