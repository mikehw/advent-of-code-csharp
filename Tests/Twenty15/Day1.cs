using AdventOfCode.Common;

namespace Tests.Twenty15;

public class Day1
{
    private readonly ISolution _instance = new AdventOfCode.Twenty15.Day1();

    [Test]
    public async Task Test1()
    {
        var result = await _instance.SolvePart1("(((");
        Assert.That(result, Is.EqualTo("3"));
    }
    
    [Test]
    public async Task Test2()
    {
        var result = await _instance.SolvePart2("((())))");
        Assert.That(result, Is.EqualTo("7"));
    }
}