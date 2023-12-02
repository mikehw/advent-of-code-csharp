namespace AdventOfCode.Common;

public interface ISolution
{
    public int Year { get; }
    public int Day { get; }
    public Task<string> SolvePart1(string input);
    public Task<string> SolvePart2(string input);
}