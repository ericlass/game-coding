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
      settings.Graphics.BackgroundColor = Color.White;

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
      GameData.Instance.ActiveScene.Update(dt);
      //System.Threading.Thread.Sleep(20);
    }
    
    public override void Render()
    {
      Vector2f center = Oku.Graphics.Viewport.Center;

      OkuManager.Instance.Graphics.SetRenderTarget(_target);
      
      //OkuManager.Instance.Graphics.Viewport.SetValues(ScreenWidth * -0.25f + center.X, ScreenWidth * 0.25f + center.X, ScreenHeight * -0.25f + center.Y, ScreenHeight * 0.25f + center.Y);
      GameData.Instance.ActiveScene.Render();
      
      OkuManager.Instance.Graphics.SetRenderTarget(null);
      
      //OkuManager.Instance.Graphics.Viewport.SetValues(ScreenWidth * -0.5f, ScreenWidth * 0.5f, ScreenHeight * -0.5f, ScreenHeight * 0.5f);
      OkuManager.Instance.Graphics.DrawScreenAlignedQuad(_target);
    }
    
  }
}
