using System;

namespace HeroVsGoblin01.Characters
{
  public abstract class Enemy : Character
  {
    #region Protected memebers
    protected Random _random; 
    #endregion

    #region Constructor(s)
    public Enemy(int xValue, int yValue, 
      int damage, int hp,
      string symbol) : base(xValue, yValue, symbol)
    {
      _hp = hp;
      _maxHP = hp;
      _damage = damage;
      _random = new Random();
    }
    #endregion

    #region Overrides
    public override string ToString()
    {
      return $"{GetType().Name} at [{X},{Y}](Amount {Damage})";
    }
    #endregion
  }
}
