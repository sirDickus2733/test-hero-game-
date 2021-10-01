using HeroVsGoblin01.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroVsGoblin01.Game
{
  public class Map : Tile
  {
    #region Hero HP
    const int HERO_HP = 10;
    #endregion

    #region Constructors
    public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numberOfEnemies)
    {
      random = new Random();
      _height = random.Next(minHeight, maxHeight);
      _width = random.Next(minWidth, maxWidth);
      _tileArray = new Tile[_width, _height];
      _enemies = new Enemy[numberOfEnemies];
      Create();
      UpdateVision();
    }
    #endregion


    #region Private member variables
    private int _height;
    private int _width;
    private Hero _hero;
    private Enemy[] _enemies;
    private Tile[,] _tileArray;  // Create a 2d tile array
    private Random random;
    #endregion

    #region Public accessors
    public Hero Hero { get => _hero; }
    public Enemy[] Enemies { get => _enemies; }
    public int Height { get => _height; }
    public int Width { get => _width; }
    public Tile[,] TileArray { get => _tileArray; }
    #endregion


    #region Private methods
    private void Create()
    {
      CreateTileMapBorders();
      Create(TileType.Hero);
      for (int i = 0; i < _enemies.Length; i++)
      {
        var enemy = Create(TileType.Enemy);
        _enemies[i] = (Enemy)enemy;
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
      // north
      _hero.Vision[0] = _tileArray[_hero.X-1, _hero.Y];
      // south
      _hero.Vision[1] = _tileArray[_hero.X+1, _hero.Y];
      //west
      _hero.Vision[2] = _tileArray[_hero.X, _hero.Y-1];
      //east
      _hero.Vision[3] = _tileArray[_hero.X, _hero.Y + 1];

      // TODO: repeat for enemies
    }


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

      // TODO: repeat for enemies
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
          _hero = new Hero(position.Item1, position.Item2, HERO_HP);
          _tileArray[position.Item1, position.Item2] = _hero;
          return _hero;

        case TileType.Enemy:
          var enemy = new Goblin(position.Item1, position.Item2);
          _tileArray[position.Item1, position.Item2] = enemy;
          return enemy;

        // rest will be implemented later(i think)
        case TileType.Gold:
          break;
        case TileType.Weapon:
          break;
        default:
          break;
      }
      return null;
    }


    #endregion

    #region Helper methods
    /// <summary>
    /// Returns a random generated position on the map if its not occupied
    /// </summary>
    /// <returns></returns>
    private Tuple<int, int> GetNextAvailablePosition()
    {
      var posX = random.Next(1, Width - 1);  // make sure not to select a tile on the border
      var posY = random.Next(1, Height - 1);
      bool isAvailable = _tileArray[posX, posY] == null;
      while (!isAvailable)
      {
        posX = random.Next(1, Width - 1);  // make sure not to select a tile on the border
        posY = random.Next(1, Height - 1);
        isAvailable = _tileArray[posX, posY] == null;
      }

      return Tuple.Create(posX, posY);
    }
    #endregion
  }
}
