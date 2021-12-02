using System.Text.RegularExpressions;

var input = File.ReadAllLines(args[0]);
var position = 0;
var depth = 0;
var matcher = new Regex(@"^([a-z]+) (\d+)$");
foreach (var instruction in input)
{
    var match = matcher.Match(instruction);
    if (!match.Success)
    {
        throw new FormatException();
    }

    var verb = match.Groups[1].Value;
    var value = int.Parse(match.Groups[2].Value);
    switch (verb)
    {
        case "forward":
            position += value;
            break;

        case "up":
            depth -= value;
            break;

        case "down":
            depth += value;
            break;
    }
}

Console.WriteLine($"Part 1: {depth * position}");
depth = 0;
position = 0;
var aim = 0;
foreach (var instruction in input)
{
    var match = matcher.Match(instruction);
    if (!match.Success)
    {
        throw new FormatException();
    }

    var verb = match.Groups[1].Value;
    var value = int.Parse(match.Groups[2].Value);
    switch (verb)
    {
        case "forward":
            position += value;
            depth += value * aim;
            break;

        case "up":
            aim -= value;
            break;

        case "down":
            aim += value;
            break;
    }
}

Console.WriteLine($"Part 2: {position * depth}");
