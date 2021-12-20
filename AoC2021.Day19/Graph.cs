namespace AoC2021.Day19
{
    public class Graph
    {
        public List<Node> Nodes { get; set; } = new();

        public Node GetNode(int id)
        {
            if (!Nodes.Any(node => node.Id == id))
            {
                Nodes.Add(new Node(id));
            }

            return Nodes.First(node => node.Id == id);
        }
    }
}
