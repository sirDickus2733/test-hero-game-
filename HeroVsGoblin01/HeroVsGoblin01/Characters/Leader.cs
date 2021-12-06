using HeroVsGoblin01.Common;
using HeroVsGoblin01.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsGoblin01.Characters
{
  public class Leader: Enemy
  {
    public Leader(int x, int y) : base(x, y, Settings.Default.LeaderDamage, Settings.Default.LeaderHp, "L")
    {
      _kind = TileType.Enemy;
      _weapon = new Weapons.MeleeWeapon("s", HeroVsGoblin01.Weapons.MeleeWeapon.Types.LongSword);

      // TODO: implement attacking

    }

    #region Properties
    private Tile _target;

    public Tile Target
    {
      get { return _target; }
      set { _target = value; }
    }

    #endregion


    #region Overrides
    public override MovementEnum ReturnMove(MovementEnum movement = MovementEnum.NoMovement)
    {
      // Todo: move towards the target by any means possible - try until theres a valid move???? What if all directions are blocked?
      return base.ReturnMove(movement);
    }
    #endregion
  }
}
