namespace AoC2021.Day16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllText(args[0]).Trim();
            var stream = new BitStream(input);
            var reader = new PacketReader(stream);
            var packet = reader.ReadPacket();
            var sum = 0;
            Visit(packet, p => sum += p.Version);
            Console.WriteLine($"Part 1: {sum}");
            Console.WriteLine($"Part 2: {packet.GetValue()}");
        }

        public static void Visit(Packet packet, Action<Packet> visitor)
        {
            visitor(packet);
            if (packet is OperatorPacket op)
            {
                op.SubPackets.ForEach(subPacket => Visit(subPacket, visitor));
            }
        }
    }
}
