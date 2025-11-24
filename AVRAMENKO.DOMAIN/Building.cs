namespace AVRAMENKODOMAIN
{
    public class Building : IEquatable<Building>
    {
        uint _id;  
        string _address;     
        HeatingSystem _heatingSystem;

        public Building()
            : this(0, "Undefined", new HeatingSystem())
        {

        }
        public Building(uint id, string address, HeatingSystem heatingSystem)
        {
            _id = id;
            _address = address;
            _heatingSystem = heatingSystem;
        }

        public uint Id
        {
            get => _id;
            set => _id = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public HeatingSystem HeatingSystem
        {
            get => _heatingSystem; 
            set => _heatingSystem = value;
        }

        public bool Equals(Building? other)
        {
            return Id == other?.Id
                && Address == other.Address
                && (HeatingSystem?.Equals(other.HeatingSystem) ?? false);
        }
    }

}
