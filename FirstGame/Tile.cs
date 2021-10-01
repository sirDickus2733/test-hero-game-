using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstGame
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

    public Tile(int xValue, int yValue, string symbol="_")
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
      get => _x;
    }

    public string North
    {
      get => $"North({X-1}, {Y})";
    }

    public string South
    {
      get => $"South({X+1}, {Y})";
    }

    public string West
    {
      get => $"West({X}, {Y - 1})";
    }


    public string East
    {
      get => $"East({X}, {Y + 1})";
    }

    public int Y
    {
      get => _y;
    }

    public enum TileType
    {
      Hero=0,
      Enemy,
      Gold,
      Weapon
    }
    #endregion


    #region Events
    public void HandleClick(object sender, EventArgs e)
    {
      var note = $"I was clicked.\n {this.ToString()} --------------------";
      MessageBox.Show($"My {North},{West}, {South}, and {East}");
      //MessageBox.Show(note, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    #endregion
  }
}
