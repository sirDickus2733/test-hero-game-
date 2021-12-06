using HeroVsGoblin01.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsGoblin01.Common
{
  public class CommonFuctions
  {
    public static Weapon RandomWeapon()
    {
      var randomWeaponIdx = new Random().Next(0, 4);
      switch (randomWeaponIdx)
      {
        case 0:
          return new MeleeWeapon("D", MeleeWeapon.Types.Dagger);
        case 1:
          return new MeleeWeapon("|", MeleeWeapon.Types.LongSword);
        case 2:
          return new RangeWeapon("R", RangeWeapon.Types.Riffle);
        case 3:
          return new RangeWeapon("B", RangeWeapon.Types.LongBow);
        default:
          return null;
      }
    }


    public static Weapon RandomWeapon(int x, int y)
    {
      var randomWeaponIdx = new Random().Next(0, 4);
      switch (randomWeaponIdx)
      {
        case 0:
          return new MeleeWeapon("D", MeleeWeapon.Types.Dagger, x, y);
        case 1:
          return new MeleeWeapon("|", MeleeWeapon.Types.LongSword, x, y);
        case 2:
          return new RangeWeapon("R", RangeWeapon.Types.Riffle, x, y);
        case 3:
          return new RangeWeapon("B", RangeWeapon.Types.LongBow, x, y);
        default:
          return null;
      }
    }
  }
}
