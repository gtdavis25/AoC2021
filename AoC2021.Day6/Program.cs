var fish = new long[9];

var ages = File
    .ReadAllText(args[0])
    .Split(',')
    .Select(int.Parse);

foreach (var age in ages)
{
    fish[age]++;
}

long[] NextState(long[] fish)
{
    return new long[]
    {
        fish[1],
        fish[2],
        fish[3],
        fish[4],
        fish[5],
        fish[6],
        fish[0] + fish[7],
        fish[8],
        fish[0]
    };
}

for (int i = 0; i < 80; i++)
{
    fish = NextState(fish);
}

Console.WriteLine($"Part 1: {fish.Sum()}");
for (int i = 80; i < 256; i++)
{
    fish = NextState(fish);
}

Console.WriteLine($"Part 2: {fish.Sum()}");
