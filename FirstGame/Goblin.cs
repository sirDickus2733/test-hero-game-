using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
  public class Goblin: Enemy
  {
    #region Constants
    const string GOBLIN_SYMBOL = "G";
    const int GOBLIN_HP = 10;
    const int GOBLIN_DAMAGE = 1;
    #endregion

    #region Constructors
    public Goblin(int x, int y):base(x, y, GOBLIN_DAMAGE, GOBLIN_HP, GOBLIN_SYMBOL)
    {

    }
    #endregion

    public override MovementEnum ReturnMove(MovementEnum movement = MovementEnum.NoMovement)
    {
      short pos = (short)_random.Next(1, 5);
      return MovementEnum.NoMovement; // todo:
    }
  }
}
