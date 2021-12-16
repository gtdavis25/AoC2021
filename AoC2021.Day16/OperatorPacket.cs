namespace AoC2021.Day16
{
    public class OperatorPacket : Packet
    {
        public List<Packet> SubPackets { get; }

        public OperatorPacket(int version, int typeId, IEnumerable<Packet> subPackets) : base(version, typeId)
        {
            SubPackets = subPackets.ToList();
        }

        public override long GetValue()
        {
            switch (TypeId)
            {
                case 0:
                    return SubPackets.Sum(p => p.GetValue());

                case 1:
                    return SubPackets.Aggregate(1L, (product, packet) => product * packet.GetValue());

                case 2:
                    return SubPackets.Min(p => p.GetValue());

                case 3:
                    return SubPackets.Max(p => p.GetValue());

                case 5:
                    return SubPackets[0].GetValue() > SubPackets[1].GetValue() ? 1 : 0;

                case 6:
                    return SubPackets[0].GetValue() < SubPackets[1].GetValue() ? 1 : 0;

                case 7:
                    return SubPackets[0].GetValue() == SubPackets[1].GetValue() ? 1 : 0;

                default:
                    throw new Exception($"Invalid operator Type ID: {TypeId}");
            }
        }
    }
}
