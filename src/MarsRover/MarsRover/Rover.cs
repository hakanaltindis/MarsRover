using MarsRover.Coordinates;

namespace MarsRover
{
  public class Rover
  {
    public Rover(int x, int y, IHeading heading)
    {
      X = x;
      Y = y;
      Heading = heading;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public IHeading Heading { get; set; }

    public void Move(string lineOfCommands, Plateau plateau)
    {
      var splitted = lineOfCommands.ToCharArray();

      foreach (var command in splitted)
      {
        switch (command)
        {
          case 'L':
            Heading = Heading.Previous;
            break;
          case 'R':
            Heading = Heading.Next;
            break;
          case 'M':
            (X, Y) = Heading.ChangeCoordinate(X, Y);
            Verify(plateau);
            break;
          default:
            throw new NotSupportedException($"The '{command}' command is not supported");
        }
      }
    }

    private void Verify(Plateau plateau)
    {
      if (X > plateau.MaxXAxisPoint)
        X = plateau.MaxXAxisPoint;
      else if (X < 0)
        X = 0;

      if (Y > plateau.MaxYAxisPoint)
        Y = plateau.MaxYAxisPoint;
      else if (Y < 0)
        Y = 0;
    }

    public string Output()
    {
      return $"{X} {Y} {Heading.Head}";
    }
  }
}
