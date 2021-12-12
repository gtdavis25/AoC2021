namespace AoC2021.Day12
{
    public class Cave
    {
        public string Name { get; set; }
        public bool IsSmall { get; }
        public List<Cave> Neighbours { get; } = new();

        public Cave(string name)
        {
            Name = name;
            IsSmall = name == name.ToLower();
        }

        public void Join(Cave other)
        {
            Neighbours.Add(other);
            other.Neighbours.Add(this);
        }
    }
}
