using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
  public abstract class Enemy : Character
  {
    protected Random _random;

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

    public override MovementEnum ReturnMove(MovementEnum movement = MovementEnum.NoMovement)
    {
      throw new NotImplementedException();
    }


    #region Overrides
    public override string ToString()
    {
      return $"{GetType().Name} at [{X},{Y}](Amount {Damage})";
    }
    #endregion
  }
}
