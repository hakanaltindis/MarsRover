// See https://aka.ms/new-console-template for more information

using MarsRover;

var inputFilePath = "input.txt";

if (args.Length > 1)
{
  Console.WriteLine($"More than one arguments is not supported.");
  Environment.Exit(0);
}
else if (args.Length == 1)
{
  inputFilePath = args[0];
}

if (!File.Exists(inputFilePath))
{
  Console.WriteLine($"The {inputFilePath} is not found");
  Environment.Exit(0);
}

var lines = File.ReadAllLines(inputFilePath);

var rover = new PlateauRover();
rover.Rove(lines);

File.WriteAllText("output.txt", rover.ToString());
