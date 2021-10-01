using Serilog;
using System;
using System.Windows.Forms;

namespace HeroVsGoblin01
{
  static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      SetupLogging();
      Application.Run(new MainScreen());
    }




    #region Log Configuration
    private static void SetupLogging()
    {
      Log.Logger = new LoggerConfiguration()
     .MinimumLevel.Debug()
     .WriteTo.Console()
     .CreateLogger();
    }
    #endregion
  }
}
