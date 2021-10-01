using HeroVsGoblin01.Characters;
using HeroVsGoblin01.Game;
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
    #endregion


    #region Game 
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

  }
}
