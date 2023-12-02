#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Common;
namespace AdventOfCode.Twenty15;

public class Day5 : ISolution
{
    public int Year => 2015;
    public int Day => 5;

    private bool IsNicePart1(string name)
    {
        // It contains at least three vowels (aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
        // It contains at least one letter that appears twice in a row, like xx, abcdde (dd), or aabbccdd (aa, bb, cc, or dd).
        // It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
        if (name.Contains("ab") || name.Contains("cd") || name.Contains("pq") || name.Contains("xy"))
        {
            return false;
        }

        var vowels = new List<char>
        {
            'a', 'e', 'i', 'o', 'u'
        };
        if (name.Count(c => vowels.Contains(c)) < 3)
        {
            return false;
        }
        char? prior = null;
        foreach (var c in name)
        {
            if (prior.HasValue && c == prior.Value)
            {
                return true;
            }
            prior = c;
        }
        return false;
    }
    
    public async Task<string> SolvePart1(string input)
    {
        var names = input.Split("\n");
        return names.Count(IsNicePart1).ToString();
    }

    private bool IsNicePart2(string name)
    {
        // It contains a pair of any two letters that appears at least twice in the string without overlapping, like xyxy (xy) or aabcdefgaa (aa), but not like aaa (aa, but it overlaps).
        // It contains at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi (efe), or even aaa.
        var found = false;
        for (var i = 0; i < name.Length-1; i++)
        {
            var check = name.Substring(i, 2);
            for (var j = i+2; j < name.Length-1; j++)
            {
                if (check == name.Substring(j, 2))
                {
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            return false;
        }

        for (var i = 0; i < name.Length - 2; i++)
        {
            if (name[i] == name[i + 2])
            {
                return true;
            }
        }
        
        return false;
    }
    
    public async Task<string> SolvePart2(string input)
    {
        var names = input.Split("\n");
        return names.Count(IsNicePart2).ToString();
    }
}