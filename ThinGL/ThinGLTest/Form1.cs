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
      Gl.InitGL(pnlCanvas, 4, 3);

      Gl.glClearColor(0.0f, 0.0f, 0.75f, 1.0f);

      Gl.glViewport(0, 0, pnlCanvas.Width, pnlCanvas.Height);

      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      Gl.glOrtho(pnlCanvas.Width * -0.5, pnlCanvas.Width * 0.5, pnlCanvas.Height * -0.5, pnlCanvas.Height * 0.5, -1, 1);

      btnInit.Enabled = false;
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      Gl.Shutdown();
    }

    private void btnRender_Click(object sender, EventArgs e)
    {
      Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();

      uint[] buffers = new uint[2];
      GlExt.GenBuffers(2, ref buffers);

      Gl.Present();
    }

  }
}
