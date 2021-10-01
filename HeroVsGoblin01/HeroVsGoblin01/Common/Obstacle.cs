using HeroVsGoblin01.Properties;

namespace HeroVsGoblin01.Common
{
  /// <summary>
  /// Borders the game map with obstacles that no characters can move past
  /// </summary>
  public class Obstacle:Tile
  {
    #region Constructor(s)
    public Obstacle(int xValue, int yValue):base(xValue, yValue, Settings.Default.ObstacleSymbol)
    {
    }
    #endregion
  }
}
