using AdventOfCode.Common;

namespace Tests.Twenty15;

public class Day8
{
    private readonly ISolution _instance = new AdventOfCode.Twenty15.Day8();
    
    [Test]
    public async Task Test2()
    {
        var result = await _instance.SolvePart2("\"\"");
        Assert.That(result, Is.EqualTo("4"));
        result = await _instance.SolvePart2("\"\"\"abc\"\"aaa\\\"aaa\"\"\\x27\"");
        Assert.That(result, Is.EqualTo("19"));
        
        result = await _instance.SolvePart2("\"\\\\\"");
        // Before "\\" - 4
        // Becomes "\"\\\\\""
        //         1234567890 - 10
        Assert.That(result, Is.EqualTo("6"));
    }
}