namespace MarsRover.Coordinates
{
  public class SouthHeading : IHeading
  {
    public string Head => "S";

    public IHeading Previous { get; set; }

    public IHeading Next { get; set; }

    public (int x, int y) ChangeCoordinate(int x, int y)
    {
      return (x, y - 1);
    }
  }
}
