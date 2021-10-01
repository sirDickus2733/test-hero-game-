using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
  public class Hero : Character
  {
    #region Constants
    const int HERO_DAMAGE = 2;
    const string HERO_SYMBOL = "H";
    #endregion


    #region Constructors
    public Hero(int xValue, int yValue, int hp) : base(xValue, yValue, HERO_SYMBOL)
    {
      HP = hp;
      MaxHP = hp;
      Damage = HERO_DAMAGE;
    }
    #endregion


    #region Override methods
    public override MovementEnum ReturnMove(MovementEnum movement)
    {
      switch (movement)
      {
        // Movement only valid if tile in the direction is empty
        case MovementEnum.Up:
          return Vision[0]?.GetType() == null ? movement : MovementEnum.NoMovement;
        case MovementEnum.Down:
          return Vision[1]?.GetType() == null? movement : MovementEnum.NoMovement;
        case MovementEnum.Left:
          return Vision[2]?.GetType() == null ? movement : MovementEnum.NoMovement;
        case MovementEnum.Right:
          return Vision[3]?.GetType() == null ? movement : MovementEnum.NoMovement;
        default:
          return movement;
      }
    }

    public override string ToString()
    {
      var stats = new StringBuilder();
      stats.AppendLine("Player Stats:");
      stats.AppendLine($"HP: {HP} / {MaxHP}");
      stats.AppendLine($"DAMAGE: {Damage}");
      stats.AppendLine($"[{X}, {Y}]");
      stats.AppendLine($"{GetNeighbours()}");
      return stats.ToString().Trim() ;
    }
    #endregion


    #region Utility methods
    private string GetNeighbours()
    {
      var vision = new StringBuilder();
      vision.AppendLine($"North: ({Vision[0]?.X}, {Vision[0]?.Y}) ");
      vision.AppendLine($"South: ({Vision[1]?.X}, {Vision[1]?.Y}) ");
      vision.AppendLine($"West: ({Vision[2]?.X}, {Vision[2]?.Y})  ");
      vision.AppendLine($"East: ({Vision[3]?.X}, {Vision[3]?.Y})  ");
      return vision.ToString();
    }
    #endregion
  }
}
