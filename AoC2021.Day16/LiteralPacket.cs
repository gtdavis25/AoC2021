namespace AoC2021.Day16
{
    public class LiteralPacket : Packet
    {
        public long Value { get; }

        public LiteralPacket(int version, int typeId, long value) : base(version, typeId)
        {
            Value = value;
        }

        public override long GetValue() => Value;
    }
}
