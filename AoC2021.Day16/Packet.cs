namespace AoC2021.Day16
{
    public abstract class Packet
    {
        public int Version { get; set; }
        public int TypeId { get; set; }

        public Packet(int version, int typeId)
        {
            Version = version;
            TypeId = typeId;
        }

        public abstract long GetValue();
    }
}
