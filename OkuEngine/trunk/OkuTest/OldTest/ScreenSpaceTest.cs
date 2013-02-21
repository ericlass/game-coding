using System;
using System.Collections.Generic;
using System.Text;
using OkuEngine;

namespace OkuTest
{
  public class ScreenSpaceTest : OkuGame
  {
    ImageContent _earth = null;
    ImageContent _yin = null;

    /*public void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = Color.Black;
      renderParams.Fullscreen = false;
      renderParams.Width = 1024;
      renderParams.Height = 786;
    }*/

    public override void Initialize()
    {
      _earth = new ImageContent(".\\content\\earth.png");
      _yin = new ImageContent(".\\content\\yinyang.png");
    }

    public override void Update(float dt)
    {
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Left))
        OkuData.Instance.SceneManager.ActiveScene.Viewport.Left += 100 * dt;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Right))
        OkuData.Instance.SceneManager.ActiveScene.Viewport.Left -= 100 * dt;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Up))
        OkuData.Instance.SceneManager.ActiveScene.Viewport.Top -= 100 * dt;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Down))
        OkuData.Instance.SceneManager.ActiveScene.Viewport.Top += 100;
    }

    public override void Render(int pass)
    {
      OkuManagers.Renderer.DrawImage(_yin, Vector2f.Zero);

      OkuManagers.Renderer.BeginScreenSpace();
      OkuManagers.Renderer.DrawImage(_earth, new Vector2f(50, 50));
      OkuManagers.Renderer.EndScreenSpace();
    }

  }
}
