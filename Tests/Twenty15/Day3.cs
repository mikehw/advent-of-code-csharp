using AdventOfCode.Common;

namespace Tests.Twenty15;

public class Day3
{
    private readonly ISolution _instance = new AdventOfCode.Twenty15.Day3();
    
    [Test]
    public async Task Test1()
    {
        var result = await _instance.SolvePart1("");
        Assert.That(result, Is.EqualTo("1"));
        result = await _instance.SolvePart1("^>v<");
        Assert.That(result, Is.EqualTo("4"));
    }
    
    [Test]
    public async Task Test2()
    {
        var result = await _instance.SolvePart2("^v^v^v^v^v");
        Assert.That(result, Is.EqualTo("11"));
    }
}