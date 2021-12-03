using AoC2021.Day3;

const int WordLength = 12;

int ParseBinary(string s)
{
    int value = 0;
    foreach (var ch in s)
    {
        value <<= 1;
        if (ch == '1')
        {
            value += 1;
        }
    }

    return value;
}

int GetBit(int value, int position)
{
    if (position < 0 || WordLength <= position)
    {
        throw new ArgumentOutOfRangeException(nameof(position));
    }

    return (value & (1 << (WordLength - position - 1))) != 0 ? 1 : 0;
}

int SelectBit(IEnumerable<int> numbers, int position, BitCriteria criteria)
{
    if (position < 0 || WordLength <= position)
    {
        throw new ArgumentOutOfRangeException(nameof(position));
    }

    var frequencies = new int[2];
    foreach (var number in numbers)
    {
        frequencies[GetBit(number, position)]++;
    }

    if (frequencies[0] > frequencies[1])
    {
        return criteria == BitCriteria.MostCommon ? 0 : 1;
    }
    else
    {
        return criteria == BitCriteria.MostCommon ? 1 : 0;
    }
}

int SelectValue(List<int> numbers, BitCriteria criteria)
{
    for (int i = 0; i < WordLength; i++)
    {
        var selected = SelectBit(numbers, i, criteria);
        numbers = numbers.Where(n => GetBit(n, i) == selected).ToList();
        if (numbers.Count == 1)
        {
            return numbers[0];
        }
    }

    throw new Exception("No such number");
}

var numbers = File.ReadAllLines(args[0]).Select(ParseBinary).ToList();
int gamma = 0, epsilon = 0;
for (int i = 0; i < WordLength; i++)
{
    gamma = (gamma << 1) + SelectBit(numbers, i, BitCriteria.MostCommon);
    epsilon = (epsilon << 1) + SelectBit(numbers, i, BitCriteria.LeastCommon);
}

Console.WriteLine($"Part 1: {gamma * epsilon}");
var oxygen = SelectValue(numbers, BitCriteria.MostCommon);
var carbon = SelectValue(numbers, BitCriteria.LeastCommon);
Console.WriteLine($"Part 2: {oxygen * carbon}");
