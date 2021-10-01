using System;

namespace HeroVsGoblin01.Common
{
  public class PlayerMovedEventArgs : EventArgs
  {
    public PlayerMovedEventArgs()
    {
    }

    public PlayerMovedEventArgs(int oldx, int oldy, int newx, int newy)
    {
      OldX = oldx;
      OldY = oldy;
      NewX = newx;
      NewY = newy;
    }

    public int OldX { get; set; }
    public int OldY { get; set; }
    public int NewX { get; set; }
    public int NewY { get; set; }
  }
}
