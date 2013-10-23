using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThinGL;

namespace ThinGLTest
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void btnInit_Click(object sender, EventArgs e)
    {
      Gl.InitGL(pnlCanvas, 2, 0);
      btnInit.Enabled = false;
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      Gl.Shutdown();
    }
  }
}
