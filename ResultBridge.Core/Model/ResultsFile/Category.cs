using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ResultBridge.Core.Model.ResultsFile
{
    [XmlRoot(elementName: "category")]
    public class category
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        public category()
        {
        }

        public category(string name)
        {
            Name = name;
        }
    }
}
