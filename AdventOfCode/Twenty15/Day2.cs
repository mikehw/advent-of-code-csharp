#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using AdventOfCode.Common;
namespace AdventOfCode.Twenty15;

public class Day2 : ISolution
{
    public int Year => 2015;
    public int Day => 2;

    public async Task<string> SolvePart1(string input)
    {
        long total = 0;
        var pieces = input.Split("\n");
        foreach (var item in pieces)
        {
            if (string.IsNullOrEmpty(item)) continue;
            var sides = item.Split("x").Select(x => long.Parse(x)).ToList();
            sides.Sort();
            var l = sides[0];
            var w = sides[1];
            var h = sides[2];
            var area = 2 * l * w + 2 * w * h + 2 * h * l + l * w;
            total += area;
        }

        return $"{total}";
    }

    public async Task<string> SolvePart2(string input)
    {
        long total = 0;
        var pieces = input.Split("\n");
        foreach (var item in pieces)
        {
            if (string.IsNullOrEmpty(item)) continue;
            var sides = item.Split("x").Select(x => long.Parse(x)).ToList();
            sides.Sort();
            var l = sides[0];
            var w = sides[1];
            var h = sides[2];
            var distance = 2 * l + 2 * w + l * w * h;
            total += distance;
        }

        return $"{total}";
    }
}