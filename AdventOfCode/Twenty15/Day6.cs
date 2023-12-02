#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Common;
namespace AdventOfCode.Twenty15;

public class Day6 : ISolution
{
    public int Year => 2015;
    public int Day => 6;
    
    public async Task<string> SolvePart1(string input)
    {
        var grid = new bool[1000, 1000];
        var commands = input.Split("\n").Where(c => !string.IsNullOrEmpty(c));
        foreach (var command in commands)
        {
            var pieces = command.Split(" ");
            if (pieces[0] == "turn")
            {
                var fill = pieces[1] == "on" ? true : false;
                var start = pieces[2].Split(",");
                var end = pieces[4].Split(",");
                var startX = int.Parse(start[0]);
                var startY = int.Parse(start[1]);
                var endX = int.Parse(end[0]);
                var endY = int.Parse(end[1]);
                for (var x = startX; x <= endX; x++)
                {
                    for (var y = startY; y <= endY; y++)
                    {
                        grid[x, y] = fill;
                    }
                }
            }
            else if (pieces[0] == "toggle")
            {
                var start = pieces[1].Split(",");
                var end = pieces[3].Split(",");
                var startX = int.Parse(start[0]);
                var startY = int.Parse(start[1]);
                var endX = int.Parse(end[0]);
                var endY = int.Parse(end[1]);
                for (var x = startX; x <= endX; x++)
                {
                    for (var y = startY; y <= endY; y++)
                    {
                        grid[x, y] = !grid[x, y];
                    }
                }
            }
        }

        var count = 0;
        foreach (var b in grid)
        {
            if (b)
            {
                count++;
            }
        }
        return count.ToString();
    }

    public async Task<string> SolvePart2(string input)
    {
        var grid = new int[1000, 1000];
        var commands = input.Split("\n").Where(c => !string.IsNullOrEmpty(c));
        foreach (var command in commands)
        {
            var pieces = command.Split(" ");
            if (pieces[0] == "turn")
            {
                var fill = pieces[1] == "on" ? 1 : -1;
                var start = pieces[2].Split(",");
                var end = pieces[4].Split(",");
                var startX = int.Parse(start[0]);
                var startY = int.Parse(start[1]);
                var endX = int.Parse(end[0]);
                var endY = int.Parse(end[1]);
                for (var x = startX; x <= endX; x++)
                {
                    for (var y = startY; y <= endY; y++)
                    {
                        grid[x, y] = int.Max(grid[x, y] + fill, 0);
                    }
                }
            }
            else if (pieces[0] == "toggle")
            {
                var start = pieces[1].Split(",");
                var end = pieces[3].Split(",");
                var startX = int.Parse(start[0]);
                var startY = int.Parse(start[1]);
                var endX = int.Parse(end[0]);
                var endY = int.Parse(end[1]);
                for (var x = startX; x <= endX; x++)
                {
                    for (var y = startY; y <= endY; y++)
                    {
                        grid[x, y] = grid[x, y] + 2;
                    }
                }
            }
        }

        var count = 0;
        foreach (var b in grid)
        {
            count += b;
        }
        return count.ToString();
    }
}