#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using AdventOfCode.Common;
namespace AdventOfCode.Twenty23;

public class Day1 : ISolution
{
    public int Year => 2023;
    public int Day => 1;

    public async Task<string> SolvePart1(string input)
    {
        var lines = input.Split("\n").Where(s => !string.IsNullOrEmpty(s));
        var sum = lines.Sum(l => int.Parse($"{l.First(c => char.IsNumber(c))}{l.Last(c => char.IsNumber(c))}"));
        return $"{sum}";
    }

    public async Task<string> SolvePart2(string input)
    {
        var lines = input.Split("\n").Where(s => !string.IsNullOrEmpty(s));
        var sum = lines.Sum(l => GetNumber(l));
        return $"{sum}";
    }

    private static int GetNumber(string line)
    {
        string[] numbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var firstIndex = line.Length;
        var lastIndex = -1;
        for (var index = 0; index < line.Length; index++)
        {
            var c = line[index];
            if (char.IsNumber(c) && firstIndex == line.Length)
            {
                firstIndex = index;
                lastIndex = index;
            }
            else if (char.IsNumber(c))
            {
                lastIndex = index;
            }
        }
        
        var firstValue = firstIndex < line.Length ? int.Parse(line[firstIndex].ToString()) : 0;
        var lastValue = lastIndex > -1 ? int.Parse(line[lastIndex].ToString()): 0;

        for (var v = 0; v < numbers.Length; v++)
        {
            var number = numbers[v];
            var index = line.IndexOf(number, StringComparison.InvariantCulture);
            if (index == -1)
            {
                continue;
            }
            if (index < firstIndex)
            {
                firstValue = v;
                firstIndex = index;
            }
            
            index = line.LastIndexOf(number, StringComparison.InvariantCulture);
            if (index > lastIndex)
            {
                lastValue = v;
                lastIndex = index;
            }
        }
        
        return int.Parse($"{firstValue}{lastValue}");
    }
}