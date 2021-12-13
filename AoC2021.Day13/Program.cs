namespace AoC2021.Day13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dots = new List<Point>();
            var folds = new List<Fold>();
            using (var reader = new StreamReader(args[0]))
            {
                for (var line = reader.ReadLine(); !string.IsNullOrEmpty(line); line = reader.ReadLine())
                {
                    dots.Add(Point.Parse(line));
                }

                for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    folds.Add(new Fold(line));
                }
            }

            var paper = new Paper(dots);
            paper.ApplyFold(folds[0]);
            Console.WriteLine($"Part 1: {paper.Dots.Count()}");
            foreach (var fold in folds.Skip(1))
            {
                paper.ApplyFold(fold);
            }

            Console.WriteLine("Part 2:");
            Console.WriteLine($"{paper.ToString()}");
        }
    }
}
