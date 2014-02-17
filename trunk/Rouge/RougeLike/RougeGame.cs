using System;
using OkuBase;
using OkuBase.Settings;
using OkuBase.Graphics;
using OkuBase.Geometry;

namespace RougeLike
{
  public class RougeGame : OkuGame
  {
    private const int ScreenWidth = 1280;
    private const int ScreenHeight = 720;

    private RenderTarget _target = null;

    public override OkuSettings Configure()
    {
      OkuSettings settings = base.Configure();

      settings.Graphics.Width = ScreenWidth;
      settings.Graphics.Height = ScreenHeight;
      settings.Graphics.TextureFilter = TextureFilter.NearestNeighbor;
      settings.Graphics.BackgroundColor = new Color(111, 161, 231);
      //settings.Graphics.BackgroundColor = Color.Magenta;

      settings.Audio.DriverName = "null";

      return settings;
    }
    
    public override void Initialize()
    {
      _target = OkuManager.Instance.Graphics.NewRenderTarget(ScreenWidth, ScreenHeight);

      //GameData.Instance.Scenes = SceneFactory.Instance.GetHardCodedScene();
      GameData.Instance.Scenes = SceneFactory.Instance.LoadScene("testscene.json");
      GameData.Instance.ActiveScene = GameData.Instance.Scenes[0];
    }
    
    public override void Update(float dt)
    {
      //long freq, tick1, tick2;
      //OkuBase.Platform.Kernel32.QueryPerformanceFrequency(out freq);
      //OkuBase.Platform.Kernel32.QueryPerformanceCounter(out tick1);

      GameData.Instance.ActiveScene.Update(dt);

      //OkuBase.Platform.Kernel32.QueryPerformanceCounter(out tick2);
      //float time = (tick2 - tick1) / (float)freq;
      //System.Diagnostics.Debug.WriteLine("Update: " + time.ToString());
    }
    
    public override void Render()
    {
      Vector2f center = Oku.Graphics.Viewport.Center;

      OkuManager.Instance.Graphics.SetRenderTarget(_target);
      
      //OkuManager.Instance.Graphics.Viewport.SetValues(ScreenWidth * -0.25f + center.X, ScreenWidth * 0.25f + center.X, ScreenHeight * -0.25f + center.Y, ScreenHeight * 0.25f + center.Y);

      long freq, tick1, tick2;
      OkuBase.Platform.Kernel32.QueryPerformanceFrequency(out freq);
      OkuBase.Platform.Kernel32.QueryPerformanceCounter(out tick1);
      
      GameData.Instance.ActiveScene.Render();

      OkuBase.Platform.Kernel32.QueryPerformanceCounter(out tick2);
      float time = (tick2 - tick1) / (float)freq;
      System.Diagnostics.Debug.WriteLine("Render: " + time.ToString());
      
      OkuManager.Instance.Graphics.SetRenderTarget(null);
      
      //OkuManager.Instance.Graphics.Viewport.SetValues(ScreenWidth * -0.5f, ScreenWidth * 0.5f, ScreenHeight * -0.5f, ScreenHeight * 0.5f);
      OkuManager.Instance.Graphics.DrawScreenAlignedQuad(_target);
    }
    
  }
}
