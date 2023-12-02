#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using AdventOfCode.Common;
namespace AdventOfCode.Twenty15;

public class Day8 : ISolution
{
    public int Year => 2015;
    public int Day => 8;

    public async Task<string> SolvePart1(string input)
    {
        var charArr = input.Where(c => !char.IsWhiteSpace(c));
        input = string.Join("", charArr);
        var startingLength = input.Length;
        var count = 0;
        for (var i = 0; i < input.Length; i++)
        {
            char val = input[i];
            if (val == '"')
            {
                continue;
            }
            if (val == '\\')
            {
                if (input[i + 1] == 'x')
                {
                    i += 3;
                }
                else
                {
                    i += 1;
                }
            }
            count++;
        }
        return $"{startingLength - count}";
    }

    public async Task<string> SolvePart2(string input)
    {
        var lines = input.Split("\n");
        var startingLength = input.Count(c => !char.IsWhiteSpace(c));
        var encoded = lines.Sum(l => 2 + l.Sum(c => c == '\\' || c == '\"' ? 2 : 1));
        return $"{encoded - startingLength}";
    }
}