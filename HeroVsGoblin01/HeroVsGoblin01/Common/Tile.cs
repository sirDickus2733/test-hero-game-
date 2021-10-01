using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using System.Windows.Forms;

namespace HeroVsGoblin01.Common
{
  /// <summary>
  /// An abstract/base class for all game objects.
  /// Can only be inherited
  /// New instances cannot be created from this class e.g. var myObj = new Tile(), will throw an error
  /// </summary>
  public abstract class Tile
  {
    #region Constructor(s)
    public Tile()
    {

    }

    public Tile(int xValue, int yValue, string symbol = "_")
    {
      _x = xValue;
      _y = yValue;
      _symbol = symbol;
    }
    #endregion

    /// <summary>
    /// Protected memebrs can only be accesses from this class or from a child class
    /// </summary>
    #region Protected members
    protected int _x;
    protected int _y;
    protected string _symbol;
    #endregion

    #region Public members
    public string Symbol
    {
      get => _symbol;
    }

    public int X
    {
      get => _x;  // Vertical position - due to buggy grid mapping
    }

    public int Y
    {
      get => _y;  // horizontal position
    }

    public string North
    {
      get => $"{X - 1},{Y}";
    }

    public string South
    {
      get => $"{X + 1},{Y}";
    }

    public string West
    {
      get => $"{X},{Y - 1}";
    }


    public string East
    {
      get => $"{X},{Y + 1}";
    }

    public enum TileType
    {
      Hero = 0,
      Enemy,
      Gold,
      Weapon
    }
    #endregion

    #region Events
    public void HandleClick(object sender, EventArgs e)
    {
      Log.Debug("Cell click avent handled. Source: {A}", this);
      PrintNeighbours();
    }

    public string PrintNeighbours()
    {
      var n = $"Showing neighbours for cell [{X}, {Y}]: North={North}, West={West}, South={South}, and East={East}";
      Log.Debug(n);
      return n;
    }
    #endregion
  }
}
