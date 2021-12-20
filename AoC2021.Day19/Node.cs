namespace AoC2021.Day19
{
    public class Node
    {
        public int Id { get; }
        public List<Node> Edges { get; set; } = new();

        public Node(int id)
        {
            Id = id;
        }

        public void Join(Node other)
        {
            Edges.Add(other);
            other.Edges.Add(this);
        }

        public void TraverseGraph(Action<Node, Node> visitor)
        {
            var seen = new HashSet<Node> { this };
            var queue = new Queue<Node>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var next in current.Edges)
                {
                    if (seen.Contains(next))
                    {
                        continue;
                    }

                    seen.Add(next);
                    visitor(current, next);
                    queue.Enqueue(next);
                }
            }
        }
    }
}
