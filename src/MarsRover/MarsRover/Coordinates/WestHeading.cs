namespace MarsRover.Coordinates
{
  public class WestHeading : IHeading
  {
    public string Head => "W";

    public IHeading Previous { get; set; }

    public IHeading Next { get; set; }

    public (int x, int y) ChangeCoordinate(int x, int y)
    {
      return (x - 1, y);
    }
  }
}
