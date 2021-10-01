using System;
using System.Collections.Generic;
using System.Text;

namespace lesson01
{
  /// <summary>
  /// A statement is a single line of execution in a program(see example below)
  /// </summary>
  class Statements
  {
    public void Run()
    {
      // declaration statement
      int gamePoints;
      
      // assignment statement
      gamePoints = 0;

      // expression statement
      int healthPoints = 10 / 50 * 100;

      Console.WriteLine(string.Format("My game points are: {0}", gamePoints));
      Console.WriteLine(string.Format("My health points are: {0}", healthPoints));

    }
  }
}
