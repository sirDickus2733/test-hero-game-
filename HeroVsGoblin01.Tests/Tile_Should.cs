using HeroVsGoblin01.Common;
using System;
using Xunit;

namespace HeroVsGoblin01.Tests
{
  class DummyTile : Tile
  {
    public DummyTile(int xValue, int yValue, string symbol = "_") : base(xValue, yValue, symbol)
    {
    }
  }

  public class Tile_Should
  {
    [Fact]
    public void InitialisePositionAndSymbol_ON_Construction()
    {
      int posX = 9;
      int posY = 11;
      string symbol = "m";
      var t = new DummyTile(posX, posY, symbol);

      Assert.Equal(t.X, posX);
      Assert.Equal(t.Y, posY);
    }

    [Fact]
    public void KnowSurroundingCellPositions()
    {
      //ARRANGE
      int posX = 5;
      int posY = 5;
      string symbol = "k";
      var expectedNorth = "4,5";
      var expectedSouth = "6,5";

      var expectedWest = "5,4";
      var expectedEast = "5,6";


      // ACT
      var t = new DummyTile(posX, posY, symbol);

      
      Assert.Equal(expectedNorth, t.North);
      Assert.Equal(expectedSouth, t.South);

      Assert.Equal(expectedWest, t.West);
      Assert.Equal(expectedEast, t.East);
    }
  }
}
