using Collector.Database;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Collector.Import
{
    public class TosecImporter
    {
        private BlobEntity ReadBlob(XmlNode node)
        {
            var result = new BlobEntity();

            if (node.Attributes != null)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    switch (attribute.Name)
                    {
                        case "name":
                            result.Name = attribute.Value;
                            break;
                        case "size":
                            result.Size = ulong.Parse(attribute.Value);
                            break;
                        case "crc":
                            result.Hashes.Add("crc32", attribute.Value);
                            break;
                        case "md5":
                            result.Hashes.Add("md5", attribute.Value);
                            break;
                        case "sha1":
                            result.Hashes.Add("sha1", attribute.Value);
                            break;
                        default:
                            throw new NotSupportedException($"Rom: attribute {attribute.Name} not supported.");
                    }
                }
            }

            return result;
        }

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
                    case "category":
                        // ignored for now
                        break;
                    case "rom":
                        result.Blobs.Add(ReadBlob(childNode));
                        break;
                    default:
                        throw new NotSupportedException($"Game: Child node {childNode.Name} is not supported");
                }
            }

            return result;
        }

        public IEnumerable<DumpEntity> Import(string filename)
        {
            var result = new List<DumpEntity>();
            try
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(filename);

                XmlNodeList? nodes = xmlDocument.SelectNodes("/datafile/game");
                
                if (nodes is not null)
                {
                    foreach (XmlNode dumpNode in nodes)
                    {
                        result.Add(ReadDump(dumpNode));
                    }
                }
            }
            catch (Exception exception)
            {
                // return meaningful message to caller
                Console.WriteLine(exception.Message);
            }

            return result;
        }
    }
}

