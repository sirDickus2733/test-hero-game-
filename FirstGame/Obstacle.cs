using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
  /// <summary>
  /// Borders the game map with obstacles that no characters can move past
  /// </summary>
  public class Obstacle:Tile
  {
    const string OBSTACLE_SYMBOL = "X";

    #region Constructor(s)
    public Obstacle(int xValue, int yValue):base(xValue, yValue, OBSTACLE_SYMBOL)
    {

    }
    #endregion
  }
}
