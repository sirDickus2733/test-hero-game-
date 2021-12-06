using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsGoblin01.Weapons
{
  public class MeleeWeapon : Weapon
  {

    public MeleeWeapon(string symbol, Types t) : base(symbol)
    {
      switch (t)  
      {
        case Types.Dagger:
          _durability = 10;
          _damage = 3;
          _cost = 3;
          _weaponType = t.ToString();
          break;
        case Types.LongSword:
          _durability = 6;
          _damage = 4;
          _cost = 5;
          _weaponType = t.ToString();
          break;
        default:
          break;
      }
    }


    public MeleeWeapon(string symbol, Types t, int x, int y) : base(symbol, x, y)
    {
      switch (t)
      {
        case Types.Dagger:
          _durability = 10;
          _damage = 3;
          _cost = 3;
          _weaponType = t.ToString();
          break;
        case Types.LongSword:
          _durability = 6;
          _damage = 4;
          _cost = 5;
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
      Dagger,
      LongSword
    }
    #endregion
  }
}
