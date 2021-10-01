using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstGame
{
  public partial class Form1 : Form
  {
    #region Private memeber variables
    private readonly GameEngine _gameEngine;
    private  Panel _mapPanel;
    private RichTextBox _healthStats;
    private int healthPoints = 100;
    #endregion

    public Form1()
    {
      InitializeComponent();
      //KeyPreview = true;
      //KeyDown += HandleMoveCharacterEvent;
      //KeyPress += Form1_KeyPress;
      _gameEngine = new GameEngine();
      _gameEngine.PlayerMoved += _gameEngine_PlayerMoved;
      InitialiseGame();
    }

    private void InitialiseGame()
    {
      Tile[,] mapTile = _gameEngine.Map.TileArray;
      _mapPanel = DrawGameMap2(mapTile);
      Controls.Add(_mapPanel);


      // Create two buttons to use as the accept and cancel buttons.
      Button button1 = new Button();
      Button button2 = new Button();

      // Set the text of button1 to "OK".
      button1.Text = "OK";
      // Set the position of the button on the form.
      button1.Location = new Point(10, 10);
      // Set the text of button2 to "Cancel".
      button2.Text = "Cancel";
      // Set the position of the button based on the location of button1.
      button2.Location
         = new Point(button1.Left, button1.Height + button1.Top + 10);

      // Display a help button on the form.
      HelpButton = true;
      this.Controls.Add(button1);
      this.Controls.Add(button2);


      GroupBox playerStatsPanel = new GroupBox();
      playerStatsPanel.Visible = true;
      playerStatsPanel.BackColor = Color.White;
      playerStatsPanel.Size = new Size(500, 100);
      playerStatsPanel.Location = new Point(100, 400);
      playerStatsPanel.Text = "Player stats";
      var healthBar = new ProgressBar();
      healthBar.Location = new Point(305, 420);
      healthBar.Size = new Size(80, 60);
      healthBar.Visible = true;
      healthBar.Value = healthPoints * 100;
      healthBar.Minimum = 0;
      healthBar.Maximum = 100;
      healthBar.Step = 1;
      healthBar.BackColor = Color.White;
      healthBar.ForeColor = Color.Green;

      playerStatsPanel.Controls.Add(_healthStats);

      Controls.Add(healthBar);
      Controls.Add(_healthStats);
      Controls.Add(playerStatsPanel);
    }

    private Panel DrawGameMap(Tile[,] mapTile)
    {
      _mapPanel = new FlowLayoutPanel();
      //_mapPanel.FlowDirection = FlowDirection.LeftToRight;
      _mapPanel.BackColor = Color.WhiteSmoke;
      _mapPanel.Location = new Point(200, 10);
      _mapPanel.Size = new Size(500, 480);

      for (int i = 0; i < mapTile.GetLength(0); i++)
      {
        for (int j = 0; j < mapTile.GetLength(1); j++)
        {
          Tile cell = mapTile[i, j];
          var b = new Button();
          if (cell != null)
            b.Click += cell.HandleClick;

          b.Text = cell?.Symbol ?? ".";
          b.Size = new Size(30, 25);
          if (cell?.GetType() == typeof(Obstacle))
          {
            b.BackColor = Color.Black;
            b.ForeColor = Color.White;
          }
          else if (cell?.GetType() == typeof(Hero))
          {
            UpdateHeroStats(cell);
          }

          _mapPanel.Controls.Add(b);
          Console.WriteLine($"Character at ({i}, {j}) is {b.Text}");
        }
      }

      return _mapPanel;
    }


    private Panel DrawGameMap2(Tile[,] mapTile)
    {
      const int ScreenWidth = 480;
      const int ScreenHeight = 360;
      _mapPanel = new Panel();
      _mapPanel.BackColor = Color.White;
      _mapPanel.Size = new Size(ScreenWidth, ScreenHeight);
      _mapPanel.Location = new Point(100, 10);

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

          _mapPanel.Controls.Add(b);
          cellPosX += cellW;
        }

        cellPosY += cellY;
        cellPosX = centerX;
      }
      return _mapPanel;
    }


      #region Utility methods
      private void UpdateHeroStats(Tile hero)
    {
      if (_healthStats == null)
      {
        _healthStats = new RichTextBox();
        //_healthStats.ForeColor = Color.Red;
        _healthStats.Location = new Point(105, 420);
        _healthStats.Size = new Size(180, 60);
      }
      var heroObject = (Hero)hero;
      _healthStats.Text = heroObject.ToString();
      healthPoints = heroObject.HP / heroObject.MaxHP;
    }
    #endregion


    #region Event handlers
    /// <summary>
    /// Reference: https://stackoverflow.com/questions/3172731/forms-not-responding-to-keydown-events
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="keyData"></param>
    /// <returns></returns>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Up)
      {
        // Handle key at form level.
        // Do not send event to focused control by returning true.
        _gameEngine.MovePlayer(Character.MovementEnum.Up);
        return true;
      }
      else if (keyData == Keys.Down)
      {
        _gameEngine.MovePlayer(Character.MovementEnum.Down);
        return true;
      }
      else if (keyData == Keys.Left)
      {
        _gameEngine.MovePlayer(Character.MovementEnum.Left);
        return true;
      }
      else if (keyData == Keys.Right)
      {
        _gameEngine.MovePlayer(Character.MovementEnum.Right);
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void _gameEngine_PlayerMoved(object sender, PlayerMovedEventArgs e)
    {
      if(_mapPanel != null)
      {
        Controls.Remove(_mapPanel);
        _mapPanel.Dispose();
      }
      _mapPanel = null;
      _mapPanel = DrawGameMap2(_gameEngine.Map.TileArray);
      Controls.Add(_mapPanel);
      //MessageBox.Show("Move success","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    //private void HandleMoveCharacterEvent(object sender, KeyEventArgs e)
    //{
    //  MessageBox.Show($"{e.KeyCode} key pressed");
    //}

    //void Form1_KeyPress(object sender, KeyPressEventArgs e)
    //{

    //  MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' pressed.");

    //  switch (e.KeyChar)
    //  {
    //    case (char)49:
    //    case (char)52:
    //    case (char)55:
    //      MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' consumed.");
    //      e.Handled = true;
    //      break;

    //  }
    //}
    #endregion
  }
}
