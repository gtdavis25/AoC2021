namespace AoC2021.Day16
{
    public class PacketReader
    {
        private BitStream _stream;
        private int _bitsRead;

        public PacketReader(BitStream stream)
        {
            _stream = stream;
        }

        public Packet ReadPacket()
        {
            var version = (int)ReadBits(3);
            var typeId = (int)ReadBits(3);
            if (typeId == 4)
            {
                var value = 0L;
                for (bool hasNext = true; hasNext;)
                {
                    var next = ReadBits(5);
                    value <<= 4;
                    value |= next & 15;
                    hasNext = (next & (1 << 4)) > 0;
                }

                return new LiteralPacket(version, typeId, value);
            }

            var subPackets = new List<Packet>();
            var lengthType = ReadBits(1);
            if (lengthType == 0)
            {
                var length = ReadBits(15);
                var start = _bitsRead;
                while (_bitsRead - start < length)
                {
                    subPackets.Add(ReadPacket());
                }
            }
            else
            {
                var numPackets = ReadBits(11);
                for (int i = 0; i < numPackets; i++)
                {
                    subPackets.Add(ReadPacket());
                }
            }

            return new OperatorPacket(version, typeId, subPackets);
        }

        private long ReadBits(int numBits)
        {
            var value = _stream.ReadBits(numBits);
            _bitsRead += numBits;
            return value;
        }
    }
}
