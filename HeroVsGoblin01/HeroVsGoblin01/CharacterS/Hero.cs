using HeroVsGoblin01.Properties;
using System.Text;

namespace HeroVsGoblin01.Characters
{
  public class Hero : Character
  {
    #region Constructors
    public Hero(int xValue, int yValue, int hp=-1) : base(xValue, yValue, Settings.Default.HeroSymbol)
    {
      if (hp <= -1)
      { hp = Settings.Default.HeroHp; }

      _hp = hp;
      _maxHP = hp;
      _damage = Settings.Default.HeroDamage;
      _kind = TileType.Hero;
    }
    #endregion


    #region Override methods
    public override string ToString()
    {
      var stats = new StringBuilder();
      stats.AppendLine($"HP: {HP} / {MaxHP}");
      //stats.AppendLine($"DAMAGE: {Damage}");
      if(_weapon == null)
      {
        stats.AppendLine($"Current Weapon: Bare Hands");
        stats.AppendLine($"Weapon Range: 1");
        stats.AppendLine($"Gold: {GoldPurse}");
      }
      else
      {
        stats.AppendLine($"Current Weapon: {_weapon.WeaponType}");
        stats.AppendLine($"Weapon Range: {_weapon.Range}");
        stats.AppendLine($"Weapon Damage: {_weapon.Damage} ");
        stats.AppendLine($"Durability: {_weapon.Durability} ");
        stats.AppendLine($"Gold: {GoldPurse}"); 
      }
      return stats.ToString().Trim();
    }
    #endregion
  }
}
