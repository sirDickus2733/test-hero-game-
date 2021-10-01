
using System.Windows.Forms;

namespace GridMap
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(500, 500);
      this.Text = "Form1";


      const int w = 10;
      const int h = 10;
      const int ScreenWidth = 480;
      const int ScreenHeight = 480;
      var panel = new Panel();
      panel.Size = new System.Drawing.Size(ScreenWidth, ScreenHeight);
      panel.Location = new System.Drawing.Point(0, 0);

      int cellW = 35; //ScreenWidth / w;
      int cellY = 35;  //ScreenHeight / h;
      int centerX = 80;
      int cellPosX = centerX;
      int cellPosY = 10;

      for (int i = 0; i < h; i++)
      {
        for (int j = 0; j < w; j++)
        {
          var b = new Button();
          b.Text = "x";
          b.Size = new System.Drawing.Size(cellW, cellY);
          b.Location = new System.Drawing.Point(cellPosX, cellPosY);
          panel.Controls.Add(b);
          cellPosX += cellW;
        }

        cellPosY += cellY;
        cellPosX = centerX;
      }

      Controls.Add(panel);


    }

    #endregion
  }
}

