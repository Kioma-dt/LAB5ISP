namespace AVRAMENKODOMAIN
{
    public class HeatingSystem : IEquatable<HeatingSystem>
    {
        uint _id;
        string _type;
        bool _isWorking;

        public HeatingSystem()
            : this(0, "Individual", true)
        {

        }
        public HeatingSystem(uint id, string type, bool isWorking)
        {
            _id = id;
            _type = type;
            _isWorking = isWorking;
        }

        public uint Id
        {
            get => _id; 
            set => _id = value;
        }

        public string Type
        {
            get => _type; 
            set => _type = value;

        }

        public bool IsWorking
        {
            get => _isWorking; 
            set => _isWorking = value;
        }

        public bool Equals(HeatingSystem? other)
        {
            return (_id == other?.Id
                && _type == other?.Type
                && _isWorking == other?.IsWorking);
        }
    }

}
