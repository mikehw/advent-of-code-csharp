#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Common;
namespace AdventOfCode.Twenty15;

public class Day7 : ISolution
{
    public int Year => 2015;
    public int Day => 7;


    public class Wire {
        public string? Name {get;set;}
        public string? InputOperation {get; set;}
        public ushort? InputValue { get; set; }
        public List<Wire>? InputWires {get; set;}
        public ushort? CalculatedValue { get; set; }
    }

    public async Task<string> SolvePart1(string input)
    {
        var wires = BuildWires(input);
        // Find the wire a in the dictionary
        var wireA = wires["a"];
        // Do a depth first search on all of A's input wires until they all have a calculated value
        return $"{GetWireSolution(wireA)}";
    }

    private Dictionary<string, Wire> BuildWires(string input)
    {
        Dictionary<string, Wire> wires = new Dictionary<string, Wire>();
        foreach (var command in input.Split("\n").Where(s => !string.IsNullOrEmpty(s)))
        {
            var pieces = command.Split("->").Select(p => p.Trim()).ToArray();
            var outputWireName = pieces[1];
            var inCommand = pieces[0];
            var outputWire = wires.GetValueOrDefault(outputWireName, new Wire() { Name = outputWireName });
            wires[outputWireName] = outputWire;
            if (ushort.TryParse(inCommand, out ushort result))
            {
                outputWire.InputValue = result;
                outputWire.CalculatedValue = result;
            }
            else
            {
                var inCommandPieces = inCommand.Split(" ");
                if (inCommandPieces.Length == 1)
                {
                    outputWire.InputOperation = "EQ";
                    var inputWireName = inCommandPieces[0];
                    var inputWire = GetWireByName(wires, inputWireName);
                    outputWire.InputWires = new List<Wire> { inputWire };
                }
                else if (inCommandPieces[0] == "NOT")
                {
                    outputWire.InputOperation = "NOT";
                    var inputWireName = inCommandPieces[1];
                    var inputWire = GetWireByName(wires, inputWireName);
                    outputWire.InputWires = new List<Wire> { inputWire };
                }
                else if (inCommandPieces[1] == "LSHIFT" || inCommandPieces[1] == "RSHIFT")
                {
                    outputWire.InputOperation = inCommandPieces[1];
                    outputWire.InputValue = ushort.Parse(inCommandPieces[2]);
                    var inputWireName = inCommandPieces[0];
                    var inputWire = GetWireByName(wires, inputWireName);
                    outputWire.InputWires = new List<Wire> { inputWire };
                }
                else
                {
                    outputWire.InputOperation = inCommandPieces[1];
                    var inputWireName1 = inCommandPieces[0];
                    var inputWire1 = GetWireByName(wires, inputWireName1);
                    var inputWireName2 = inCommandPieces[2];
                    var inputWire2 = GetWireByName(wires, inputWireName2);
                    outputWire.InputWires = new List<Wire> { inputWire1, inputWire2 };
                }
            }
        }

        return wires;
    }

    private Wire GetWireByName(Dictionary<string, Wire> wires, string inputName)
    {
        if (wires.TryGetValue(inputName, out var wire))
        {
            return wire;
        }

        if (ushort.TryParse(inputName, out ushort value))
        {
            return new Wire()
            {
                CalculatedValue = value
            };
        }
        var newWire = new Wire()
        {
            Name = inputName
        };
        wires.Add(inputName, newWire);
        return newWire;
    }

    private ushort GetWireSolution(Wire wire)
    {
        if (wire.CalculatedValue.HasValue)
        {
            return wire.CalculatedValue.Value;
        }

        if (wire.InputOperation == "EQ")
        {
            var inputWire = wire.InputWires?[0] ?? throw new InvalidOperationException();
            wire.CalculatedValue = GetWireSolution(inputWire);
            return wire.CalculatedValue.Value;
        }
        
        if (wire.InputOperation == "NOT")
        {
            var inputWire = wire.InputWires?[0] ?? throw new InvalidOperationException();
            var inputWireSolution = GetWireSolution(inputWire);
            wire.CalculatedValue = (ushort)~inputWireSolution;
            return wire.CalculatedValue.Value;
        }

        if (wire.InputOperation == "LSHIFT")
        {
            var inputWire = wire.InputWires?[0] ?? throw new InvalidOperationException();
            var inputWireSolution = GetWireSolution(inputWire);
            Debug.Assert(wire.InputValue != null, "inputWire.InputValue != null");
            wire.CalculatedValue = (ushort)(inputWireSolution << wire.InputValue.Value); 
            return wire.CalculatedValue.Value;
        }
        
        if (wire.InputOperation == "RSHIFT")
        {
            var inputWire = wire.InputWires?[0] ?? throw new InvalidOperationException();
            var inputWireSolution = GetWireSolution(inputWire);
            Debug.Assert(wire.InputValue != null, "inputWire.InputValue != null");
            wire.CalculatedValue = (ushort)(inputWireSolution >> wire.InputValue.Value); 
            return wire.CalculatedValue.Value;
        }
        
        if (wire.InputOperation == "OR")
        {
            var inputWire1 = wire.InputWires?[0] ?? throw new InvalidOperationException();
            var inputWireSolution1 = GetWireSolution(inputWire1);
            var inputWire2 = wire.InputWires?[1] ?? throw new InvalidOperationException();
            var inputWireSolution2 = GetWireSolution(inputWire2);
            wire.CalculatedValue = (ushort)(inputWireSolution1 | inputWireSolution2); 
            return wire.CalculatedValue.Value;
        }
        
        if (wire.InputOperation == "AND")
        {
            var inputWire1 = wire.InputWires?[0] ?? throw new InvalidOperationException();
            var inputWireSolution1 = GetWireSolution(inputWire1);
            var inputWire2 = wire.InputWires?[1] ?? throw new InvalidOperationException();
            var inputWireSolution2 = GetWireSolution(inputWire2);
            wire.CalculatedValue = (ushort)(inputWireSolution1 & inputWireSolution2);  
            return wire.CalculatedValue.Value;
        }

        Console.WriteLine(wire);
        throw new InvalidOperationException();
    }

    public async Task<string> SolvePart2(string input)
    {
        var wires = BuildWires(input);
        var wireA = wires["a"];
        var aValue = GetWireSolution(wireA);
        wires = BuildWires(input);
        wires["b"].CalculatedValue = aValue;
        wireA = wires["a"];
        return $"{GetWireSolution(wireA)}";
    }
}