using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS7Starter.Settings.InstitutionInformation
{
    public class EnvironmentSetting
    {
        private Dictionary<string, EnvironmentGroup> _dictionary = new Dictionary<string, EnvironmentGroup>();

        public EnvironmentGroup[] EnviromentGroupList
        {
            get
            {
                return _dictionary.Values.ToArray();
            }
            set
            {
                ArrayToDictionary(value);
            }
        }

        private void ArrayToDictionary(EnvironmentGroup[] list)
        {
            _dictionary = new Dictionary<string, EnvironmentGroup>();

            foreach (EnvironmentGroup info in list)
            {
                _dictionary.Add(info.Name, info);
            }
        }

        public EnvironmentGroup GetEnvironmentGroup(string group)
        {
            if (!_dictionary.ContainsKey(group))
            {
                return null;
            }

            return _dictionary[group];
        }

        public bool SetEnviromentGroup(EnvironmentGroup environmentGroup)
        {
            // グループ名が一致していたら上書き
            if (_dictionary.ContainsKey(environmentGroup.Name))
            {
                _dictionary[environmentGroup.Name] = environmentGroup;

            }
            // グループ名が一致していなかったら追加
            else
            {
                _dictionary.Add(environmentGroup.Name, environmentGroup);
            }

            return true;
        }

        public bool SetEnviromentParameter(string group, string key, string environmentParameter)
        {
            bool isExist = false;
            List<EnvironmentParam> list = _dictionary[group].EnviromentParamList;

            foreach (EnvironmentParam param in list)
            {
                if (param.Key == key)
                {
                    param.Value = environmentParameter;
                    isExist = true;
                }
            }
            if (isExist == false)
            {
                EnvironmentParam addParam = new EnvironmentParam();
                addParam.Key = key;
                addParam.Value = environmentParameter;
                _dictionary[group].EnviromentParamList.Add(addParam);
            }

            return true;
        }
    }
}
