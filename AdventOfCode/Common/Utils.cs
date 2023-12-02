using Microsoft.Extensions.Configuration;

namespace AdventOfCode.Common;

public static class Utils
{
    private static readonly IConfiguration Configuration = new ConfigurationBuilder()
        .AddJsonFile("./appsettings.json", false, true)
        .Build();

    private static async Task<string> FetchInput(int year, int day)
    {
        // Check if the file exists in the cache
        var cachePath = $"{Environment.CurrentDirectory}/.cache/{year}/{day}.txt";
        if (File.Exists(cachePath))
        {
            return await File.ReadAllTextAsync(cachePath);
        }
        
        // Fetch the file at https://adventofcode.com/{year}/day/{day}/input
        var client = new HttpClient();
        var sessionCookie = Configuration["AdventOfCodeSession"];
        Console.WriteLine("SessionCookie: " + sessionCookie);
        client.DefaultRequestHeaders.Add("Cookie", $"session={sessionCookie}");
        var result = await client.GetAsync($"https://adventofcode.com/{year}/day/{day}/input");
        var content = await result.Content.ReadAsStringAsync();
        if (!result.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to fetch input: {result.StatusCode} - {content}");
        }
        
        // Cache to file for future runs
        FileInfo file = new FileInfo(cachePath);
        file.Directory?.Create();
        await File.WriteAllTextAsync(file.FullName, content);

        return content;
    }

    public static async Task<string> GetAnswer(this ISolution solution, string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            input = await FetchInput(solution.Year, solution.Day);
        }
        string solution1;
        try
        {
            solution1 = await solution.SolvePart1(input);
        }
        catch (Exception ex)
        {
            solution1 = $"Exception: ${ex}";
        }

        string solution2;
        try
        {
            solution2 = await solution.SolvePart2(input);
        }
        catch (Exception ex)
        {
            solution2 = $"Exception: ${ex}";
        }

        return $"{solution1}\n{solution2}";
    }
}