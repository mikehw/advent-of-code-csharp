#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Common;
namespace AdventOfCode.Twenty15;

public class Day4 : ISolution
{
    public int Year => 2015;
    public int Day => 4;

    public async Task<string> SolvePart1(string input)
    {
        string hash;
        int i = 0;
        do
        {
            i++;
            var str = input + i;
            byte[] byteArray = Encoding.ASCII.GetBytes(str);
            MemoryStream stream = new MemoryStream(byteArray);
            var md5 = await MD5.Create().ComputeHashAsync(stream);
            hash = BitConverter.ToString(md5).Replace("-", "");
        } while (!hash.StartsWith("00000"));
        return i.ToString();
    }

    public async Task<string> SolvePart2(string input)
    {
        string hash;
        int i = 0;
        do
        {
            i++;
            var str = input + i;
            byte[] byteArray = Encoding.ASCII.GetBytes(str);
            MemoryStream stream = new MemoryStream(byteArray);
            var md5 = await MD5.Create().ComputeHashAsync(stream);
            hash = BitConverter.ToString(md5).Replace("-", "");
        } while (!hash.StartsWith("000000"));
        return i.ToString();
    }
}