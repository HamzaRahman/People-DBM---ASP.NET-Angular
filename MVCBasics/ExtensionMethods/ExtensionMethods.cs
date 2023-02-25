using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PeopleDB.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string ToXml(this object source, bool indent = false)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(source.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = indent;
            settings.OmitXmlDeclaration = true;
            using (var stringWriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(writer, source, emptyNamespaces);
                }
                return stringWriter.ToString();
            }
        }
    }
}
