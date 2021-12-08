namespace MarsRover.Coordinates
{
  internal static class Headings
  {
    private static bool _isArranged = false;

    private static IHeading _north = new NorthHeading();

    private static IHeading _east = new EastHeading();

    private static IHeading _south = new SouthHeading();

    private static IHeading _west = new WestHeading();

    private static void ArrangeLinks()
    {
      _north.Previous = _west;
      _north.Next = _east;

      _east.Previous = _north;
      _east.Next = _south;

      _south.Previous = _east;
      _south.Next = _west;

      _west.Previous = _south;
      _west.Next = _north;
    }

    public static IHeading GetHeading(string heading)
    {
      if (!_isArranged)
      {
        ArrangeLinks();
        _isArranged = true;
      }

      return heading switch
      {
        "N" => _north,
        "E" => _east,
        "S" => _south,
        "W" => _west,
        _ => throw new NotSupportedException($"{heading} letter is not supported"),
      };
    }
  }
}
