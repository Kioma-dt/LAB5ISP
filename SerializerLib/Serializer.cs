using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text.Json;
using AVRAMENKODOMAIN;
namespace SerializerLib
{
    public class Serializer : ISerializer
    {
        public IEnumerable<Building> DeSerializeByLINQ(string fileName)
        {
            var doc = XDocument.Load(fileName);

            if (doc is null || doc.Root is null) {
                return Enumerable.Empty<Building>();
            }

            var result =
                from i in doc?.Root?.Elements("Building")
                select new Building
                {
                    Id = (uint)i!.Attribute("Id"),
                    Address = (string)i!.Element("Address"),

                    HeatingSystem = new HeatingSystem
                    {
                        Id = (uint)i.Element("HeatingSystem").Attribute("Id"),
                        Type = (string)i.Element("HeatingSystem").Element("Type"),
                        IsWorking = (bool)i.Element("HeatingSystem").Element("IsWorking"),
                    }
                };

            return result.ToList();

        }

        public IEnumerable<Building> DeSerializeXML(string fileName)
        {
            var xml = new XmlSerializer(typeof(List<Building>));

            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                return (IEnumerable<Building>)xml?.Deserialize(fs) ?? Enumerable.Empty<Building>();
            }
        }

        public IEnumerable<Building> DeSerializeJSON(string fileName)
        {
            var buildings = JsonSerializer
             .Deserialize<List<Building>>(
                 File.ReadAllText(fileName));

            return buildings ?? new List<Building>();
        }

        public void SerializeByLINQ(IEnumerable<Building> items, string fileName)
        {
            var doc = new XDocument(
                new XElement("Buildings",
                    from i in items
                    select new XElement("Building",
                        new XAttribute("Id", i.Id),
                        new XElement("Address", i.Address),

                        new XElement("HeatingSystem",
                            new XAttribute("Id", i.HeatingSystem.Id),
                            new XElement("Type", i.HeatingSystem.Type),
                            new XElement("IsWorking", i.HeatingSystem.IsWorking)
                        )
                    )
                )
            );

            doc.Save(fileName);
        }

        public void SerializeXML(IEnumerable<Building> items, string fileName)
        {
            var xml = new XmlSerializer(typeof(List<Building>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xml.Serialize(fs, items);
            }
        }

        public void SerializeJSON(IEnumerable<Building> items, string fileName)
        {
            var json = JsonSerializer.Serialize(items.ToList(), new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }

    }
}
