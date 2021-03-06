using HeroVsGoblin01.Common;
using HeroVsGoblin01.Weapons;

namespace HeroVsGoblin01.Characters
{
  /// <summary>
  /// Represents any movable or immovable object  found on the game map
  /// </summary>
  public abstract class Character : Tile
  {
    /// <summary>
    /// Maximum number of neighbors this character is aware of
    /// </summary>
    const short NUMBER_OF_NEIGHBORS = 4;

    #region Constructor(s)
    public Character(int xValue, int yValue, string symbol) : base(xValue, yValue, symbol)
    {
      _vision = new Tile[NUMBER_OF_NEIGHBORS];

    
    }
    #endregion

    #region Properties
    protected int _goldPurse = 0;
    public int GoldPurse
    {
      get { return _goldPurse; }
      set { _goldPurse = value; }
    }


    protected Weapon _weapon;
    public Weapon Weapons
    {
      get { return _weapon; }
    }

    protected int _hp;
    /// <summary>
    /// A numerical representation of a character's health. aka hit points
    /// Reference: https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Video_game_health_bar.svg/220px-Video_game_health_bar.svg.png
    /// </summary>
    public int HP
    {
      get { return _hp; }
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

    #region Nested Types
    public enum MovementEnum
    {
      NoMovement = 0,
      Up,
      Down,
      Left,
      Right
    }
    #endregion

    #region Abstract/Virtual methods
    /// <summary>
    /// Checks if a proposed move is valid.
    /// A move can only be allowed if the next cell is unoccupied
    /// </summary>
    /// <param name="movement"></param>
    /// <returns></returns>
    public virtual MovementEnum ReturnMove(MovementEnum movement = 0)
    {
      switch (movement)
      {
        case MovementEnum.Up:
          return IsMoveAllowed(Vision[0]) ? movement : MovementEnum.NoMovement;
        case MovementEnum.Down:
          return IsMoveAllowed(Vision[1]) ? movement : MovementEnum.NoMovement;
        case MovementEnum.Left:
          return IsMoveAllowed(Vision[2]) ? movement : MovementEnum.NoMovement;
        case MovementEnum.Right:
          return IsMoveAllowed(Vision[3]) ? movement : MovementEnum.NoMovement;
        default:
          return movement;
      }
    }

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

    public bool IsDead() => HP == 0;
    #endregion

    private void Equip(Weapon w)
    {
      _weapon = w;
    }
    
    #region Public methods
    
    public void Pickup(Item item)
    {
      if (item.Type == TileType.Weapon)
        Equip((Weapon)item);
      else if ( item.Type == TileType.Gold )
      {
        var golObj = (Gold)item;
        _goldPurse += golObj.Amount;
      }
    }

    public void Loot()
    {
      // TODO: take gold and weapons from victim
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
    #endregion


    #region Private Methods
    private bool IsMoveAllowed(Tile obstacleObj)
    {
      return obstacleObj == null || obstacleObj.Type == TileType.Gold || obstacleObj.Type == TileType.Weapon;
    }
    #endregion
  }
}
