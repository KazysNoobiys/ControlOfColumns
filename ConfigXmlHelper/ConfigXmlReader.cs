using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigXmlHelper
{
    public class ConfigXmlReader
    {
        private  Dictionary<string, bool> _productEnabled;
        private readonly  Dictionary<string, bool> _productRequired;
        private string _path;

        public ConfigXmlReader(string path)
        {
            _path = path;
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(_path);
            _productEnabled = new Dictionary<string, bool>();
            _productRequired = new Dictionary<string, bool>();

            if (xmlDocument.DocumentElement != null)
                foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
                {
                    string name = node["name"]?.InnerText;
                    bool required = Convert.ToBoolean(node["required"]?.InnerText);
                    bool enabled = Convert.ToBoolean(node["enabled"]?.InnerText);
                    if (name != null) _productEnabled.Add(name, enabled);
                    if (name != null) _productRequired.Add(name, required);
                }
            else
            {
                throw new NullReferenceException("Нет корневого элемента");
            }
        }

        public Dictionary<string, bool> ProductEnabled
        {
            get { return _productEnabled; }
            set { _productEnabled = value; }
        }

        public Dictionary<string, bool> ProductRequired => _productRequired;

        public void Save()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(_path);
            if (xmlDocument.DocumentElement != null)
                foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
                {
                    string name = node["name"]?.InnerText;
                    bool enabled = _productEnabled[name];
                    node["enabled"].InnerText = Convert.ToString(enabled);
                }
            else
            {
                throw new NullReferenceException("Нет корневого элемента");
            }
            xmlDocument.Save(_path);
        }
    }
}
