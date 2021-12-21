namespace AoC2021.Day21
{
    public class Die
    {
        private int _counter;

        public int RollCount { get; private set; }

        public int Roll()
        {
            RollCount++;
            return _counter++ % 100 + 1;
        }
    }
}
