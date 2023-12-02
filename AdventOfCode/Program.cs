using AdventOfCode.Common;
using Microsoft.Extensions.DependencyInjection;

// Register the solution classes
var services = new ServiceCollection();
// Scan the assembly for all ISolution implementations
services.Scan(scan => scan
    .FromAssemblyOf<ISolution>()
    .AddClasses(classes => classes.AssignableTo<ISolution>())
    .AsImplementedInterfaces()
    .WithTransientLifetime());

var provider = services.BuildServiceProvider();

var year = int.Parse(args[0]);
var day = int.Parse(args[1]);
var input = args.Length > 2 ? args[2] : string.Empty;

var contest = provider.GetServices<ISolution>().First(s => s.Year == year && s.Day == day);

// Get the solution for the given year and day
Console.WriteLine(await contest.GetAnswer(input));