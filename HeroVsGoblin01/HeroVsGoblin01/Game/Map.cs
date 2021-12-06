using HeroVsGoblin01.Characters;
using HeroVsGoblin01.Common;
using HeroVsGoblin01.Weapons;
using System;

namespace HeroVsGoblin01.Game
{
  public class Map : Tile
  {
    #region Constructors
    public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numberOfEnemies, int numGold = 3, int numWeapons = 2)
    {
      _random = new Random();
      _numGold = numGold;
      _numWeapons = numWeapons;

      _height = _random.Next(minHeight, maxHeight);
      _width = _random.Next(minWidth, maxWidth);
      _tileArray = new Tile[_width, _height];
      _enemies = new Enemy[numberOfEnemies];
      _items = new Item[numWeapons + numGold];
      Create();
      UpdateVision();

      // TODO 1: On create, include weapons and Leader enemy type
      // TODO 2: Intergrate shopping

    }
    #endregion

    #region Private member variables
    private int _height;
    private int _width;
    private int _numGold;
    private int _numWeapons;
    private Hero _hero;
    private Tile[] _enemies;
    private Item[] _items; // For gold,weapons etc
    private Tile[,] _tileArray;  // Create a 2d tile array
    private Random _random;
    #endregion

    #region Public accessors
    public Hero Hero { get => _hero; }
    public Tile[] Enemies { get => _enemies; }
    public int MapHeight { get => _height; }
    public int MapWidth { get => _width; }
    public Tile[,] TileArray { get => _tileArray; }
    public Item[] Items { get => _items; }
    #endregion

    #region Private methods
    private void Create()
    {
      CreateTileMapBorders();
      CreateItems();
      Create(TileType.Hero);

      // Next, create enemies at random positionso on the map
      for (int i = 0; i < _enemies.Length; i++)
      {
        var enemy = Create(TileType.Enemy);
        _enemies[i] = enemy;
      }
      
    }

    private void CreateItems()
    {
      // Add weapons to items array
      for (int i = 0; i < _numWeapons; i++)
      {
        var position = GetNextAvailablePosition();
        var weaponObj = CommonFuctions.RandomWeapon(position.Item1, position.Item2);
        _items[i] = weaponObj;
        _tileArray[position.Item1, position.Item2] = weaponObj;
      }

      // Add gold to items array
      for (int i = _numWeapons; i < _items.Length; i++)
      {
        var position = GetNextAvailablePosition();
        var goldObj = new Gold(position.Item1, position.Item2);
        _items[i] = goldObj;
        _tileArray[position.Item1, position.Item2] = goldObj;
      }
    }

    private void CreateTileMapBorders()
    {
      for (int i = 0; i < _tileArray.GetLength(0); i++)
      {
        for (int j = 0; j < _tileArray.GetLength(1); j++)
        {
          // Check if we are on the edges then just put obstacles
          bool isFirstRowOrLast = i == 0 || i == _width - 1;
          bool isFirstColumnOrLast = j == 0 || j == _height - 1;
          if (isFirstRowOrLast || isFirstColumnOrLast)
          {
            _tileArray[i, j] = new Obstacle(i, j);
            continue;
          }
        }
      }
    }


    /// <summary>
    /// // Update each characters vision array with surroundig characters
    /// </summary>
    private void UpdateVision()
    {
      UpdateVision(_hero);
      // TODO: do same for enemies
    }


    /// <summary>
    /// Used to update vision after a character moves to a different cell
    /// </summary>
    /// <param name="c"></param>
    public void UpdateVision(Character c)
    {
      // north
      c.Vision[0] = _tileArray[c.X - 1, c.Y];
      // south
      c.Vision[1] = _tileArray[c.X + 1, c.Y];
      //west
      c.Vision[2] = _tileArray[c.X, c.Y - 1];
      //east
      c.Vision[3] = _tileArray[c.X, c.Y + 1];
    }


    /// <summary>
    /// Creates a tile, then position it on the map
    /// </summary>
    /// <param name="type">Type of tile to create</param>
    /// <returns></returns>
    private Tile Create(TileType type)
    {
      var position = GetNextAvailablePosition();
      switch (type)
      {
        case TileType.Hero:
          _hero = new Hero(position.Item1, position.Item2);
          _tileArray[position.Item1, position.Item2] = _hero;
          return _hero;

        case TileType.Enemy:
          var diceRoll = _random.Next(0, 3);
          Enemy enemy;
          if (diceRoll == 0)
          {
            enemy = new Goblin(position.Item1, position.Item2);
          }
          else if (diceRoll == 1)
          {
            enemy = new Mage(position.Item1, position.Item2);
          }
          else
          {
            enemy = new Leader(position.Item1, position.Item2);
          }

          _tileArray[position.Item1, position.Item2] = enemy;
          return enemy;
        case TileType.Gold:
          break;

        default:
          break;
      }
      return null;
    }


    public Item GetItemAtPosition(int x, int y)
    {
      Item result = null;
      for (int i = 0; i < _items.Length; i++)
      {
        var tmp = _items[i];
        if (tmp != null && tmp.X == x && tmp.Y == y)
        {
          result = _items[i];
          _items[i] = null; // set item to null and return item
          break;
        }
      }
      return result;
    }
    #endregion

    #region Helper methods
    /// <summary>
    /// Returns a random generated position on the map if its not occupied
    /// </summary>
    /// <returns></returns>
    private Tuple<int, int> GetNextAvailablePosition()
    {
      var posX = _random.Next(1, MapWidth - 1);  // make sure not to select a tile on the border
      var posY = _random.Next(1, MapHeight - 1);
      bool isAvailable = _tileArray[posX, posY] == null;
      while (!isAvailable)
      {
        posX = _random.Next(1, MapWidth - 1);
        posY = _random.Next(1, MapHeight - 1);
        isAvailable = _tileArray[posX, posY] == null;
      }
      return Tuple.Create(posX, posY);
    }
    #endregion
  }
}
