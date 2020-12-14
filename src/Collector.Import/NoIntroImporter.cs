using Collector.Database;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Collector.Import
{
    public class NoIntroImporter
    {

        private DumpEntity ReadDump(XmlNode node)
        {
            var result = new DumpEntity();

            if (node.Attributes != null)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    switch (attribute.Name)
                    {
                        case "name":
                            result.Code = attribute.Value;
                            break;
                        default:
                            throw new NotSupportedException($"Game: Attribute {attribute.Name} is not supported");
                    }
                }
            }

            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case "description":
                        result.Name = childNode.InnerText;
                        break;
                    case "publisher":
                        // ignored for now
                        break;
                    case "year":
                        // ignored for now
                        break;
                    case "part":
                        //result.Blobs.Add(ReadBlob(childNode));
                        break;
                    default:
                        throw new NotSupportedException($"Game: Child node {childNode.Name} is not supported");
                }
            }


            return result;
        }


        public List<DumpEntity> Import(string filename)
        {
            var document = new XmlDocument();
            document.Load(filename);
            var result = new List<DumpEntity>();

            XmlNodeList? nodes = document.SelectNodes("/datafile/game");

            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    ReadDump(node);
                }
            }

            return result;
        }

    }
}
