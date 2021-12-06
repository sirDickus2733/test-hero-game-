using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsGoblin01.Characters
{
  public class Mage: Enemy
  {
    #region Constructors
    public Mage(int x, int y) : base(x, y, 5, 5 ,"M")
    {
      _kind = TileType.Enemy;
    }
    #endregion

    #region Overrides
    public override MovementEnum ReturnMove(MovementEnum movement = MovementEnum.NoMovement)
    {
      return MovementEnum.NoMovement; // Maggies dont move
    }
    #endregion
  }
}
