var input = File.ReadAllLines(args[0]).Select(int.Parse).ToArray();
var count = 0;
for (int i = 1; i < input.Length; i++)
{
    if (input[i] > input[i - 1])
    {
        count++;
    }
}

Console.WriteLine($"Part 1: {count}");
var windows = new int[input.Length - 2];
for (int i = 0; i < windows.Length; i++)
{
    for (int j = 0; j < 3; j++)
    {
        windows[i] += input[i + j];
    }
}

count = 0;
for (int i = 1; i < windows.Length; i++)
{
    if (windows[i] > windows[i - 1])
    {
        count++;
    }
}

Console.WriteLine($"Part 2: {count}");
