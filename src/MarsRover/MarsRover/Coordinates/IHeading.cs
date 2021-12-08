namespace MarsRover.Coordinates
{
  public interface IHeading
  {
    string Head { get; }
    IHeading Previous { get; set; }
    IHeading Next { get; set; }

    (int x, int y) ChangeCoordinate(int x, int y);
  }
}
