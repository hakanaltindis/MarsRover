using MarsRover.Coordinates;
using System.Text;

namespace MarsRover
{
  public class PlateauRover
  {
    private readonly StringBuilder _outputBuilder;

    public PlateauRover()
    {
      _outputBuilder = new StringBuilder();
    }

    public void Rove(string[] linesOfCommands)
    {
      if (linesOfCommands == null || linesOfCommands.Length == 0)
        return;

      var plateau = GetPlateau(linesOfCommands.First());

      for (int i = 1; i < linesOfCommands.Length - 1; i += 2)
      {
        var lineOfRover = linesOfCommands[i];
        var lineOfCommands = linesOfCommands[i + 1];

        var rover = GetRover(lineOfRover);
        rover.Move(lineOfCommands, plateau);
        _outputBuilder.AppendLine(rover.Output());
      }
    }

    public override string ToString()
    {
      return _outputBuilder.ToString();
    }

    private Rover GetRover(string line)
    {
      var splitted = line.Split(' ');
      if (splitted.Length != 3)
        throw new InvalidOperationException($"Number of arguments must be 3");

      if (!int.TryParse(splitted[0], out int x))
        throw new InvalidCastException($"The '{splitted[0]}' cannot be coverted to interger");

      if (!int.TryParse(splitted[1], out int y))
        throw new InvalidCastException($"The '{splitted[1]}' cannot be coverted to interger");

      return new Rover(x, y, Headings.GetHeading(splitted[2]));
    }

    private Plateau GetPlateau(string line)
    {
      var splitted = line.Split(' ');
      if (splitted.Length != 2)
        throw new InvalidOperationException($"Number of arguments must be 2");

      if (!int.TryParse(splitted[0], out int x))
        throw new InvalidCastException($"The '{splitted[0]}' cannot be coverted to interger");

      if (!int.TryParse(splitted[1], out int y))
        throw new InvalidCastException($"The '{splitted[1]}' cannot be coverted to interger");

      return new Plateau(x, y);
    }
  }
}
