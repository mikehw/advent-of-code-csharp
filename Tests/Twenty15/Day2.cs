using AdventOfCode.Common;

namespace Tests.Twenty15;

public class Day2
{
    private readonly ISolution _instance = new AdventOfCode.Twenty15.Day2();
    
    [Test]
    public async Task Test1()
    {
        var result = await _instance.SolvePart1("2x3x4");
        Assert.That(result, Is.EqualTo("58"));
    }
    
    [Test]
    public async Task Test2()
    {
        var result = await _instance.SolvePart2("2x3x4");
        Assert.That(result, Is.EqualTo("34"));
    }
}