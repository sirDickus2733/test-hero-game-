using System;
using HeroVsGoblin01.Characters;
using HeroVsGoblin01.Common;
using HeroVsGoblin01.Utils;
using Serilog;

namespace HeroVsGoblin01.Game
{
  public class GameEngine
  {
    #region Member variables
    private readonly Map _map; 
    #endregion

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

    public bool MoveHero(Character.MovementEnum direction)
    {
      var canMove = _map.Hero.ReturnMove(direction);
      if (canMove == Character.MovementEnum.NoMovement)
      {
        Log.Debug($"Hero {_map.Hero} Unable to move {direction}. Target cell is occupied");
        MediaManager.PlayInvalidMoveSound();
        return false;
      }
      var oldX = _map.Hero.X;
      var oldY = _map.Hero.Y;
      _map.Hero.Move(direction);
      var newX = _map.Hero.X;
      var newY = _map.Hero.Y;

      // pickup gold or weapon if any
      var foundItem = _map.GetItemAtPosition(newX, newY);
      if (foundItem != null)
      {
        _map.Hero.Pickup(foundItem);
      }

      _map.TileArray[oldX, oldY] = null;
      _map.TileArray[newX, newY] = _map.Hero;
      _map.UpdateVision(_map.Hero);

        RaisePlayerMovedEvent(new PlayerMovedEventArgs
      {
        OldX = oldX,
        OldY = oldY,
        NewX = newX,
        NewY = newY
      });
      MediaManager.PlayValidMoveSound();
      return true;
    }
    #endregion

    #region Events
    /// <summary>
    /// Event fired after a player move is completed
    /// </summary>
    public event EventHandler<PlayerMovedEventArgs> PlayerMoved;

    private void RaisePlayerMovedEvent(PlayerMovedEventArgs args)
    {
      PlayerMoved?.Invoke(this, args);
    }
    #endregion
  }
}
