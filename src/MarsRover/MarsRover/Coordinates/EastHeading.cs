namespace MarsRover.Coordinates
{
  public class EastHeading : IHeading
  {
    public string Head => "E";

    public IHeading Previous { get; set; }

    public IHeading Next { get; set; }

    public (int x, int y) ChangeCoordinate(int x, int y)
    {
      return (x + 1, y);
    }
  }
}
