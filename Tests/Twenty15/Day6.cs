using AdventOfCode.Common;

namespace Tests.Twenty15;

public class Day6
{
    private readonly ISolution _instance = new AdventOfCode.Twenty15.Day6();
    
    [Test]
    public async Task Test1()
    {
        var result = await _instance.SolvePart1("toggle 0,0 through 999,0");
        Assert.That(result, Is.EqualTo("1000"));
        result = await _instance.SolvePart1("turn off 499,499 through 500,500");
        Assert.That(result, Is.EqualTo("0"));
    }
    
    [Test]
    public async Task Test2()
    {
        var result = await _instance.SolvePart2("toggle 0,0 through 999,999");
        Assert.That(result, Is.EqualTo("2000000"));
        result = await _instance.SolvePart2("turn on 0,0 through 0,0");
        Assert.That(result, Is.EqualTo("1"));
    }
}