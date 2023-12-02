using AdventOfCode.Common;

namespace Tests.Twenty15;

public class Day5
{
    private readonly ISolution _instance = new AdventOfCode.Twenty15.Day5();
    
    [Test]
    public async Task Test1()
    {
        var result = await _instance.SolvePart1("ugknbfddgicrmopn");
        Assert.That(result, Is.EqualTo("1"));
        result = await _instance.SolvePart1("jchzalrnumimnmhp");
        Assert.That(result, Is.EqualTo("0"));
    }
    
    [Test]
    public async Task Test2()
    {
        var result = await _instance.SolvePart2("qjhvhtzxzqqjkmpb");
        Assert.That(result, Is.EqualTo("1"));
        result = await _instance.SolvePart2("xxyxx");
        Assert.That(result, Is.EqualTo("1"));
        result = await _instance.SolvePart2("uurcxstgmygtbstg");
        Assert.That(result, Is.EqualTo("0"));
        result = await _instance.SolvePart2("ieodomkazucvgmuy");
        Assert.That(result, Is.EqualTo("0"));
        result = await _instance.SolvePart2("aaa");
        Assert.That(result, Is.EqualTo("0"));
    }
}