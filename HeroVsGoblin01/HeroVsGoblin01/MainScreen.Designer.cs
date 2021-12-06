
using HeroVsGoblin01.Characters;
using HeroVsGoblin01.Common;
using System.Drawing;
using System.Windows.Forms;

namespace HeroVsGoblin01
{
  partial class MainScreen
  {
    private Panel _gameMap;
    private RichTextBox _playerHealthStats;

    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(Properties.Settings.Default.ScreenWidth, Properties.Settings.Default.ScreenHeight);
      this.Text = Properties.Settings.Default.AppName;
    }

    #endregion

    #region Custom Screen Designs
    private Panel DrawGameMap(Tile[,] mapTile)
    {
      const int ScreenWidth = 480;
      const int ScreenHeight = 360;
      _gameMap = new Panel();
      _gameMap.BackColor = Color.White;
      _gameMap.Size = new Size(ScreenWidth, ScreenHeight);
      _gameMap.Location = new Point(100, 10);

      int cellW = 40;  // Fix this for now..
      int cellY = 40;
      int centerX = 80;
      int cellPosX = centerX;
      int cellPosY = 10;

      for (int i = 0; i < mapTile.GetLength(0); i++)
      {
        for (int j = 0; j < mapTile.GetLength(1); j++)
        {
          Tile cell = mapTile[i, j];
          var b = new Button();
          if (cell != null)
            b.Click += cell.HandleClick;

          b.Text = cell?.Symbol ?? ".";
          if(Properties.Settings.Default.ShowCellCoordinates)
            b.Text = $"{b.Text}({i},{j})";

          b.Size = new Size(cellW, cellY);
          b.Location = new Point(cellPosX, cellPosY);

          if (cell?.GetType() == typeof(Obstacle))
          {
            b.BackColor = Color.Black;
            b.ForeColor = Color.White;
          }
          else if (cell?.GetType() == typeof(Hero))
          {
            b.BackColor = Color.Green;
            b.ForeColor = Color.White;
            UpdateHeroStats(cell);
          }
          else if (cell?.GetType() == typeof(Goblin))
          {
            b.BackColor = Color.Orange;
            b.ForeColor = Color.White;
          }
          else if (cell?.GetType() == typeof(Leader))
          {
            b.BackColor = Color.Red;
            b.ForeColor = Color.White;
          }
          else if (cell?.GetType() == typeof(Weapons.Weapon))
          {
            b.BackColor = Color.Yellow;
            b.ForeColor = Color.White;
          }

          _gameMap.Controls.Add(b);
          cellPosX += cellW;
        }

        cellPosY += cellY;
        cellPosX = centerX;
      }
      return _gameMap;
    }



    private void UpdateHeroStats(Tile hero)
    {
      if (_playerHealthStats == null)
      {
        _playerHealthStats = new RichTextBox();
        _playerHealthStats.Location = new Point(105, 420);
        _playerHealthStats.Size = new Size(180, 80);
      }
      var heroObject = (Hero)hero;
      _playerHealthStats.Text = heroObject.ToString();
      _playerHealthPoints = heroObject.HP / heroObject.MaxHP;
    }
    #endregion
  }
}

