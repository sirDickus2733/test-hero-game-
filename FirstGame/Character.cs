using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
  public abstract class Character:Tile
  {

    #region Constructor(s)
    public Character(int xValue, int yValue, string symbol) : base(xValue, yValue, symbol)
    {
      _vision = new Tile[4];
    }
    #endregion

    #region Properties
    protected int _hp;
    /// <summary>
    /// A numerical representation of a character's health. aka hit points
    /// Reference: https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Video_game_health_bar.svg/220px-Video_game_health_bar.svg.png
    /// </summary>
    public int HP
    {
      get { return _hp; }
      set { _hp = value; }
    }


    protected int _maxHP;
    public int MaxHP
    {
      get { return _maxHP; }
      set { _maxHP = value; }
    }


    protected int _damage;
    public int Damage
    {
      get { return _damage; }
      set { _damage = value; }
    }


    private Tile[] _vision;
    /// <summary>
    /// Represents characters that are north, south, east, west of the character during its turn
    /// </summary>
    public Tile[] Vision
    {

      get { return _vision; }
      set { _vision = value; }
    } 
    #endregion

    public enum MovementEnum
    {
      NoMovement=0,
      Up,
      Down,
      Left,
      Right
    }


    #region Abstract/Virtual methods
    public abstract MovementEnum ReturnMove(MovementEnum movement = 0);

    public virtual void Attack(Character target) { }


    public virtual bool CheckRange(Character target)
    {
      return DistanceTo(target) == 1;
    }

    /// <summary>
    /// Check the aboslute distance between a character and its target
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    private int DistanceTo(Character target)
    {
      return 1; // TODO
    }

    public void Move(MovementEnum move)
    {
      switch (move)
      {
        case MovementEnum.NoMovement:
          break;
        case MovementEnum.Up:
          _x -= 1;
          break;
        case MovementEnum.Down:
          _x += 1;
          break;
        case MovementEnum.Left:
          _y -= 1;
          break;
        case MovementEnum.Right:
          _y += 1;
          break;
        default:
          break;
      }
    }
    
    public bool IsDead() => HP == 0;
    #endregion
  }
}
