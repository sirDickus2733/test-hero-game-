using HeroVsGoblin01.Characters;
using HeroVsGoblin01.Common;
using HeroVsGoblin01.Game;
using System.Drawing;
using System.Windows.Forms;

namespace HeroVsGoblin01
{
  public partial class MainScreen : Form
  {
    #region Private members
    private readonly GameEngine _gameEngine;
    private int _playerHealthPoints; 
    #endregion

    public MainScreen()
    {
      InitializeComponent();
      _gameEngine = new GameEngine();
      StartGame();
      _gameEngine.PlayerMoved += HandlePlayerMovedEvent;
      HandleKeyBoardEvents();
    }

    #region Game events
    private void HandleKeyBoardEvents()
    {
      //KeyPreview = true;
      //KeyDown += HandleMoveCharacterEvent;
      //KeyPress += Form1_KeyPress;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Up)
      {
        // Handle key at form level.
        // Do not send event to focused control by returning true.
        _gameEngine.MoveHero(Character.MovementEnum.Up);
        return true;
      }
      else if (keyData == Keys.Down)
      {
        _gameEngine.MoveHero(Character.MovementEnum.Down);
        return true;
      }
      else if (keyData == Keys.Left)
      {
        _gameEngine.MoveHero(Character.MovementEnum.Left);
        return true;
      }
      else if (keyData == Keys.Right)
      {
        _gameEngine.MoveHero(Character.MovementEnum.Right);
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void HandlePlayerMovedEvent(object sender, Common.PlayerMovedEventArgs e)
    {
      if (_gameMap != null)
      {
        Controls.Remove(_gameMap);
        _gameMap.Dispose();
      }
      _gameMap = null;
      _gameMap = DrawGameMap(_gameEngine.Map.TileArray);
      Controls.Add(_gameMap);
    }
    #endregion

    #region Game init
    private void StartGame()
    {
      _gameMap = DrawGameMap(_gameEngine.Map.TileArray);
      Controls.Add(_gameMap);


      // Create two buttons to use as the accept and cancel buttons.
      Button button1 = new Button();
      Button button2 = new Button();

      // Set the text of button1 to "OK".
      button1.Text = "Restart";
      // Set the position of the button on the form.
      button1.Location = new Point(10, 10);
      // Set the text of button2 to "Cancel".
      button2.Text = "Settings";
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
      healthBar.Size = new Size(280, 80);
      healthBar.Visible = true;
      healthBar.Value = _playerHealthPoints * 100;
      healthBar.Minimum = 0;
      healthBar.Maximum = 100;
      healthBar.Step = 1;
      healthBar.BackColor = Color.White;
      healthBar.ForeColor = Color.Green;

      playerStatsPanel.Controls.Add(_playerHealthStats);

      Controls.Add(healthBar);
      Controls.Add(_playerHealthStats);
      Controls.Add(playerStatsPanel);
    }
    #endregion
  }
}
