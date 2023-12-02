#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using AdventOfCode.Common;
namespace AdventOfCode.Twenty15;

public class Day1 : ISolution
{
    public int Year => 2015;
    public int Day => 1;

    public async Task<string> SolvePart1(string input)
    {
        return $"{input.Count(x => x == '(') - input.Count(x => x == ')')}";
    }

    public async Task<string> SolvePart2(string input)
    {
        var floor = 0;
        for (var i = 0; i < input.Length; i++)
            switch (input[i])
            {
                case '(':
                    floor++;
                    break;
                case ')':
                {
                    floor--;
                    if (floor < 0) return $"{i + 1}";
                    break;
                }
            }

        return "";
    }
}