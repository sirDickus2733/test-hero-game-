using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsGoblin01.Weapons
{
  public class RangeWeapon: Weapon
  {
    public RangeWeapon(string symbol, Types t) : base(symbol)
    {
      switch (t)
      {
        case Types.Riffle:
          _durability = 13;
          _damage = 5;
          _cost = 7;
          _weaponType = t.ToString();
          break;
        case Types.LongBow:
          _durability = 4;
          _damage = 4;
          _cost = 6;
          _weaponType = t.ToString();
          break;
        default:
          break;
      }
    }


    #region Properties
    public override int Range
    {
      get
      {
        return 1;
      }
    }
    #endregion


    #region Structures

    public enum Types
    {
      Riffle,
      LongBow
    }
    #endregion
  }
}
