using HeroVsGoblin01.Properties;
using System.Text;

namespace HeroVsGoblin01.Game
{
  public class Hero : Character
  {
    #region Constructors
    public Hero(int xValue, int yValue, int hp) : base(xValue, yValue, Settings.Default.HeroSymbol)
    {
      HP = hp;
      MaxHP = hp;
      Damage = Settings.Default.HeroDamage;
    }
    #endregion


    #region Override methods
    public override string ToString()
    {
      var stats = new StringBuilder();
      stats.AppendLine("Player Stats");
      stats.AppendLine($"HP: {HP} / {MaxHP}");
      stats.AppendLine($"DAMAGE: {Damage}");
      stats.AppendLine($"[{X}, {Y}]");
      return stats.ToString().Trim() ;
    }
    #endregion
  }
}
