using AdventOfCode.Common;

namespace Tests.Twenty15;

public class Day4
{
    private readonly ISolution _instance = new AdventOfCode.Twenty15.Day4();
    
    [Test]
    public async Task Test1()
    {
        var result = await _instance.SolvePart1("abcdef");
        Assert.That(result, Is.EqualTo("609043"));
    }
    
    [Test]
    public async Task Test2()
    {
        Assert.True(true);
    }
}