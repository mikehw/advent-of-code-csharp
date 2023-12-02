#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using AdventOfCode.Common;
namespace AdventOfCode.Twenty15;

public class Day3 : ISolution
{
    public int Year => 2015;
    public int Day => 3;

    public async Task<string> SolvePart1(string input)
    {
        HashSet<(int, int)> housesVisited = new();
        var x = 0;
        var y = 0;
        housesVisited.Add((x, y));
        foreach (var c in input)
        {
            if (c == '^')
            {
                y++;
            }
            else if (c == '>')
            {
                x++;
            }
            else if (c == '<')
            {
                x--;
            } 
            else if (c == 'v')
            {
                y--;
            }
            housesVisited.Add((x, y));
        }
        return housesVisited.Count.ToString();
    }

    public async Task<string> SolvePart2(string input)
    {
        HashSet<(int, int)> housesVisited = new();
        var x1 = 0;
        var y1 = 0;
        var x2 = 0;
        var y2 = 0;
        housesVisited.Add((x1, y1));
        for (var index = 0; index < input.Length; index++)
        {
            var c = input[index];
            if (index % 2 == 0)
            {
                switch (c)
                {
                    case '^':
                        y1++;
                        break;
                    case '>':
                        x1++;
                        break;
                    case '<':
                        x1--;
                        break;
                    case 'v':
                        y1--;
                        break;
                }
                housesVisited.Add((x1, y1));
            }
            else
            {
                switch (c)
                {
                    case '^':
                        y2++;
                        break;
                    case '>':
                        x2++;
                        break;
                    case '<':
                        x2--;
                        break;
                    case 'v':
                        y2--;
                        break;
                }
                housesVisited.Add((x2, y2));
            }
        }

        return housesVisited.Count.ToString();
    }
}