using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsGoblin01.Common
{
  public class Gold:Item
  {
    #region Protected memebers
    private Random _random;
    #endregion

    #region Constructors
    public Gold(int x, int y, string symbol="$"):base(x, y, symbol)
    {
      _random = new Random();
      _amount = _random.Next(1, 6);
      _kind = TileType.Gold;
    } 
    #endregion

    #region Properties

    private int _amount;

    public int Amount
    {
      get { return _amount; }
    }

    #endregion
  }
}
