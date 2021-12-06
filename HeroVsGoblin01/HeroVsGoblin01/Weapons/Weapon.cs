using HeroVsGoblin01.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsGoblin01.Weapons
{
  public class Weapon : Item
  {

    public Weapon(string symbol, int x = -1, int y = -1) : base(x, y, symbol)
    {
      _kind = TileType.Weapon;
    }


    #region Properties
    protected int _damage;
    protected int range;
    protected int _durability;

    public int Damage
    {
      get => _damage;
    }


    public virtual int Range { get => range; }


    

    public int Durability
    {
      get { return _durability; }
    }

    protected int _cost;

    public int Cost
    {
      get { return _cost; }
      set { _cost = value; }
    }


    protected string _weaponType;

    public string WeaponType
    {
      get { return _weaponType; }
      set { _weaponType = value; }
    }

    #endregion


  }
}
