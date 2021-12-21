namespace AoC2021.Day21
{
    public readonly struct GameResult
    {
        public long Player1Wins { get; init; }
        public long Player2Wins { get; init; }

        public GameResult(long player1Wins, long player2Wins)
        {
            Player1Wins = player1Wins;
            Player2Wins = player2Wins;
        }

        public static GameResult operator +(GameResult result1, GameResult result2)
        {
            return new GameResult(result1.Player1Wins + result2.Player1Wins, result1.Player2Wins + result2.Player2Wins);
        }
    }
}
