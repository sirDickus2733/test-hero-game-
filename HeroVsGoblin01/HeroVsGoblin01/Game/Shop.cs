using HeroVsGoblin01.Characters;
using HeroVsGoblin01.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsGoblin01.Game
{

  public class Shop
  {
    #region Protected memebers
    private Random _random;
    private Weapon[] _weapons;
    private Character _buyer;
    #endregion

    #region Constuctor(s)
    public Shop(Character b)
    {
      _buyer = b;
      _random = new Random();
      _weapons = new Weapon[3];
      for (int i = 0; i < 3; i++)
      {
        _weapons[i] = RandomWeapon();
      }
    } 
    #endregion

    private Weapon RandomWeapon()
    {
      // Not really the best implementation i think
      var randomWeaponIdx = _random.Next(0, 4);
      switch (randomWeaponIdx)  
      {
        case 0:
          return new MeleeWeapon("D", MeleeWeapon.Types.Dagger);
        case 1:
          return new MeleeWeapon("L", MeleeWeapon.Types.LongSword);
        case 2:
          return new RangeWeapon("R", RangeWeapon.Types.Riffle);
        case 3:
          return new RangeWeapon("R", RangeWeapon.Types.LongBow);
        default:
          return null;
      }
    }


    public void Buy(int num)
    {
      var bought = _weapons[num];
      // todo: decrease gold from buyer
      _weapons[num] = RandomWeapon();
    }

    public string DisplayWeapon(int num)
    {
      var selectedWeapon = _weapons[num];
      return $"Buy {selectedWeapon.WeaponType} ({selectedWeapon.Cost} Gold)";
    }

  }
}
