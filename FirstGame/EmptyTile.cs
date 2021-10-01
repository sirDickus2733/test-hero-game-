using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
  /// <summary>
  /// Represent a mere empty tile on the game map
  /// </summary>
  public class EmptyTile: Tile
  {
    public EmptyTile(int xValue, int yValue) : base(xValue, yValue)
    {

    }
  }
}
