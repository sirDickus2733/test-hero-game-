using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsGoblin01.Utils
{
  public class MediaManager
  {

    public static void PlayInvalidMoveSound()
    {
      try
      {
        using (var s = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Battery Critical.wav"))
        {
          s.Play();
        }
      }
      catch (Exception exception)
      {
        Log.Error(exception, "Failed to play invalid move sound");
      }
    }


    public static void PlayValidMoveSound()
    {
      try
      {
        using (var s = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Balloon.wav"))
        {
          s.Play();
        }
      }
      catch (Exception exception)
      {
        Log.Error(exception, "Failed to play valid move sound");
      }
    }
  }
}
