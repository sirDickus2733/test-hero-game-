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
    Button _buyWeaponBtn;

    #endregion

    public MainScreen()
    {
      InitializeComponent();
      _gameEngine = new GameEngine();
      StartGame();
      _gameEngine.PlayerMoved += HandlePlayerMovedEvent;
      EnableBuyButton();
    }

    #region Game events

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

    private void HandlePlayerMovedEvent(object sender, PlayerMovedEventArgs e)
    {
      if (_gameMap != null)
      {
        Controls.Remove(_gameMap);
        _gameMap.Dispose();
      }
      _gameMap = null;  // TODO: OPTIMISE TO STOP FLASHING WHEN HERO MOVES
      _gameMap = DrawGameMap(_gameEngine.Map.TileArray);
      Controls.Add(_gameMap);
      EnableBuyButton();
    }


    private void EnableBuyButton()
    {
      _buyWeaponBtn.Enabled = _gameEngine.Shop.CanBuy(0);
    }
    #endregion

    #region Game init
    private void StartGame()
    {
      _gameMap = DrawGameMap(_gameEngine.Map.TileArray);
      Controls.Add(_gameMap);


      _buyWeaponBtn = new Button();
      _buyWeaponBtn.Text = _gameEngine.Shop?.DisplayWeapon(0);
      _buyWeaponBtn.Size = new Size(150, 30);
      _buyWeaponBtn.Location = new Point(600, 10);
      Controls.Add(_buyWeaponBtn);


      GroupBox playerStatsPanel = new GroupBox();
      playerStatsPanel.Visible = true;
      playerStatsPanel.BackColor = Color.White;
      playerStatsPanel.Size = new Size(500, 140);
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
