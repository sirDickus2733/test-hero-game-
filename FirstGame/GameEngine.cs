using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstGame
{
  public class GameEngine
  {
    private readonly Map _map;

    #region Constructor
    public GameEngine()
    {
      _map = new Map(8, 10, 8, 10, 3);
    }


    public GameEngine(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemies)
    {
      _map = new Map(minWidth, maxWidth, minHeight, maxHeight, enemies);
    }
    #endregion


    #region Public accessors
    public Map Map
    {
      get => _map;
    }
    #endregion

    #region Public methods

    public bool MovePlayer(Character.MovementEnum direction)
    {
      var canMove = _map.Hero.ReturnMove(direction);
      if (canMove == Character.MovementEnum.NoMovement)
      {
        MessageBox.Show($"Move {direction} request rejected");
        return false;
      }
      var oldX = _map.Hero.X;
      var oldY = _map.Hero.Y;
      _map.Hero.Move(direction);
      var newX = _map.Hero.X;
      var newY = _map.Hero.Y;

      _map.TileArray[oldX, oldY] = null;
      _map.TileArray[newX, newY] = _map.Hero;
      _map.UpdateVision(_map.Hero);

      NotifyPlayerPositionChanged(new PlayerMovedEventArgs
      {
        OldX = oldX,
        OldY = oldY,
        NewX = newX,
        NewY = newY
      }); 
      return true;
    }
    #endregion


    #region Events
    public event EventHandler<PlayerMovedEventArgs> PlayerMoved;

    private void NotifyPlayerPositionChanged(PlayerMovedEventArgs args)
    {
      PlayerMoved?.Invoke(this, args);
    }
    #endregion
  }
}
