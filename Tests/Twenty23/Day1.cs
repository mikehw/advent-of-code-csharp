using AdventOfCode.Common;

namespace Tests.Twenty23;

public class Day1
{
    private readonly ISolution _instance = new AdventOfCode.Twenty23.Day1();

    // [Test]
    // public async Task Test1()
    // {
    //     var result = await _instance.SolvePart1("(((");
    //     Assert.That(result, Is.EqualTo("3"));
    // }
    
    [Test]
    public async Task Test1()
    {
        var input =
            "two1nine\neightwo1three\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen";
        var result = await _instance.SolvePart2(input);
        Assert.That(result, Is.EqualTo("281"));
        input = "sevenine\neighthree";
        result = await _instance.SolvePart2(input);
        Assert.That(result, Is.EqualTo("162"));
        input = "eightzgqzr3eight";
        result = await _instance.SolvePart2(input);
        Assert.That(result, Is.EqualTo("88"));
    }
    
    [Test]
    public async Task Test2()
    {
        var input = "eightzgqzr3eight";
        var result = await _instance.SolvePart2(input);
        Assert.That(result, Is.EqualTo("88"));
    }
    
    [Test]
    public async Task Test3()
    {
        var input = "9sbxg";
        var result = await _instance.SolvePart2(input);
        Assert.That(result, Is.EqualTo("99"));
    }
}