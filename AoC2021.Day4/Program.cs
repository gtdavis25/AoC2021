using System.Text.RegularExpressions;

namespace AoC2021.Day4
{
    public class Program
    {
        static readonly Regex Matcher = new(@"\d+");

        public static void Main(string[] args)
        {
            var numbers = new List<int>();
            var boards = new List<Board>();
            using (var reader = new StreamReader(args[0]))
            {
                var line = reader.ReadLine();
                numbers.AddRange(line!.Split(',').Select(int.Parse));
                reader.ReadLine();
                var rows = new List<List<int>>();
                while (true)
                {
                    line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        var cells = rows.Select(row => row.ToArray()).ToArray();
                        boards.Add(new Board(cells));
                        rows.Clear();
                    }

                    if (line == null)
                    {
                        break;
                    }

                    if (line == string.Empty)
                    {
                        continue;
                    }

                    var row = Matcher
                        .Matches(line)
                        .Select(match => int.Parse(match.Value))
                        .ToList();

                    rows.Add(row);
                }
            }

            var won = false;
            int? winningScore = null;
            int? losingScore = null;
            foreach (var n in numbers)
            {
                if (boards.Count == 0)
                {
                    break;
                }

                var completedBoards = new List<Board>();
                foreach (var board in boards)
                {
                    board.Draw(n);
                    if (board.IsComplete())
                    {
                        if (!won)
                        {
                            won = true;
                            winningScore = board.Sum * n;
                        }

                        if (boards.Count == 1)
                        {
                            losingScore = board.Sum * n;
                        }

                        completedBoards.Add(board);
                    }
                }

                foreach (var completed in completedBoards)
                {
                    boards.Remove(completed);
                }
            }

            Console.WriteLine($"Part 1: {winningScore}");
            Console.WriteLine($"Part 2: {losingScore}");
        }
    }
}
