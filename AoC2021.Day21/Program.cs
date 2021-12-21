using System.Text.RegularExpressions;

namespace AoC2021.Day21
{
    public class Program
    {
        static readonly Regex Matcher = new(@"^Player [12] starting position: (\d+)$");

        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(args[0]);
            var players = new[]
            {
                new Pawn(int.Parse(Matcher.Match(input[0]).Groups[1].Value)),
                new Pawn(int.Parse(Matcher.Match(input[1]).Groups[1].Value))
            };

            var die = new Die();
            for (int i = 0; players[0].Score < 1000 && players[1].Score < 1000; i++)
            {
                var player = players[i % 2];
                var steps = die.Roll();
                steps += die.Roll();
                steps += die.Roll();
                player.Move(steps);
            }

            var losingScore = Math.Min(players[0].Score, players[1].Score);
            Console.WriteLine($"Part 1: {losingScore * die.RollCount}");
            var squares = new int[]
            {
                int.Parse(Matcher.Match(input[0]).Groups[1].Value),
                int.Parse(Matcher.Match(input[1]).Groups[1].Value)
            };

            var game = new Game(squares);
            var result = game.GetResult();
            var max = Math.Max(result.Player1Wins, result.Player2Wins);
            Console.WriteLine($"Part 2: {max}");
        }
    }
}
