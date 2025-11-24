using AVRAMENKODOMAIN;
namespace SerializerLib
{
    public interface ISerializer
    {
        IEnumerable<Building> DeSerializeByLINQ(string fileName);
        IEnumerable<Building> DeSerializeXML(string fileName);
        IEnumerable<Building> DeSerializeJSON(string fileName);

        void SerializeByLINQ(IEnumerable<Building> items, string fileName);
        void SerializeXML(IEnumerable<Building> items, string fileName);
        void SerializeJSON(IEnumerable<Building> items, string fileName);
    }
}
