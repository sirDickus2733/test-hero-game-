using HeroVsGoblin01.Properties;

namespace HeroVsGoblin01.Characters
{
  public class Goblin: Enemy
  {
    #region Constructors
    public Goblin(int x, int y):base(x, y, Settings.Default.GoblinDamage, Settings.Default.GoblinHp, Settings.Default.GoblinSymbol)
    {

    }
    #endregion

    #region Overrides
    public override MovementEnum ReturnMove(MovementEnum movement = MovementEnum.NoMovement)
    {
      short pos = (short)_random.Next(1, 5);
      return MovementEnum.NoMovement; // todo:
    } 
    #endregion
  }
}
