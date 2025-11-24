using Microsoft.Extensions.Configuration;
using AVRAMENKODOMAIN;
using SerializerLib;
namespace AVRAMENKO_453503_Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string fileName = config["Files:FileName"];
            string xmlFile = fileName + ".xml";
            string linqFile = fileName + "linq.xml";
            string jsonFile = fileName + ".json";

            var buildings = new List<Building>
            {
                new Building(13, "Dzerzinskogo 3", new HeatingSystem(2, "Individual", true)),
                new Building(323, "Belgradskay 14", new HeatingSystem(10, "Individual", false)),
                new Building(12, "Chkalova 3", new HeatingSystem(666, "General", true)),
                new Building(555, "Belgradskay 35", new HeatingSystem(35, "Individual", true)),
                new Building(52, "Sverdlova 3", new HeatingSystem(64, "Individual", false)),
                new Building(1, "Lunacharscogo 7", new HeatingSystem(454, "General", false)),
            };

            ISerializer serializer = new Serializer();

            serializer.SerializeXML(buildings, xmlFile);
            serializer.SerializeByLINQ(buildings, linqFile);
            serializer.SerializeJSON(buildings, jsonFile);

            var xmlRead = serializer.DeSerializeXML(xmlFile).ToList();
            var linqRead = serializer.DeSerializeByLINQ(linqFile).ToList();
            var jsonRead = serializer.DeSerializeJSON(jsonFile).ToList();

            bool xmlEquals = AreListsEqual(buildings, xmlRead);
            bool linqEquals = AreListsEqual(buildings, linqRead);
            bool jsonEquals = AreListsEqual(buildings, jsonRead);

            Console.WriteLine($"XML equals: {xmlEquals}");
            Console.WriteLine($"LINQ-XML equals: {linqEquals}");
            Console.WriteLine($"JSON equals: {jsonEquals}");
        }
        static bool AreListsEqual(List<Building> first, List<Building> second)
        {
            if (first.Count != second.Count) return false;
            for (int i = 0; i < first.Count; i++)
            {
                if (!first[i].Equals(second[i])) return false;
            }
            return true;
        }
    }
}
