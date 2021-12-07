var crabs = File
    .ReadAllText(args[0])
    .Split(',')
    .Select(int.Parse)
    .ToArray();

var min = crabs.Min();
var max = crabs.Max();
var result = Enumerable
    .Range(min, max - min + 1)
    .Min(x => crabs.Sum(crab => Math.Abs(crab - x)));

Console.WriteLine($"Part 1: {result}");

result = Enumerable
    .Range(min, max - min + 1)
    .Min(x => crabs.Sum(crab => Math.Abs(crab - x) * (Math.Abs(crab - x) + 1) / 2));

Console.WriteLine($"Part 2: {result}");
