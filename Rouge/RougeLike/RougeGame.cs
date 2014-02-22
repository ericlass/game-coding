using System;
using OkuBase;
using OkuBase.Settings;
using OkuBase.Graphics;
using OkuBase.Geometry;

namespace RougeLike
{
  public class RougeGame : OkuGame
  {
    private const string VertexShaderSource =
      "void main()\n" +
      "{\n" +
      "  gl_Position    = gl_ModelViewProjectionMatrix * gl_Vertex;\n" +
      "  gl_TexCoord[0] = gl_MultiTexCoord0;\n" +
      "}\n";

    private const string BlackPixelShaderSource =
      "uniform sampler2D tex;\n" +
      "\n" +
      "void main()\n" +
      "{\n" +
      "  vec4 texCol = texture2D(tex, gl_TexCoord[0].xy);\n" +
      "  gl_FragColor = vec4(0, 0, 0, texCol.a);\n" +
      "}";

    private const string ColorPixelShaderSource =
      "uniform sampler2D tex;\n" +
      "\n" +
      "void main()\n" +
      "{\n" +
      "  vec4 texCol = texture2D(tex, gl_TexCoord[0].xy);\n" +
      "  gl_FragColor = texCol;\n" +
      "}";

    private const int ScreenWidth = 1280;
    private const int ScreenHeight = 720;

    private RenderTarget _target = null;
    private ShaderProgram _blackShader = null;
    private ShaderProgram _colorShader = null;

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

      Shader vertexShader = new Shader(VertexShaderSource, ShaderType.VertexShader);
      Shader blackShader = new Shader(BlackPixelShaderSource, ShaderType.PixelShader);
      _blackShader = OkuManager.Instance.Graphics.NewShaderProgram(vertexShader, blackShader);

      Shader colorShader = new Shader(ColorPixelShaderSource, ShaderType.PixelShader);
      _colorShader = OkuManager.Instance.Graphics.NewShaderProgram(vertexShader, colorShader);

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
      OkuManager.Instance.Graphics.UseShaderProgram(_blackShader);
      OkuManager.Instance.Graphics.BackgroundColor = Color.White;
            
      //OkuManager.Instance.Graphics.Viewport.SetValues(ScreenWidth * -0.25f + center.X, ScreenWidth * 0.25f + center.X, ScreenHeight * -0.25f + center.Y, ScreenHeight * 0.25f + center.Y);

      long freq, tick1, tick2;
      OkuBase.Platform.Kernel32.QueryPerformanceFrequency(out freq);
      OkuBase.Platform.Kernel32.QueryPerformanceCounter(out tick1);
      
      GameData.Instance.ActiveScene.Render();

      OkuBase.Platform.Kernel32.QueryPerformanceCounter(out tick2);
      float time = (tick2 - tick1) / (float)freq;
      System.Diagnostics.Debug.WriteLine("Render: " + time.ToString());
      
      OkuManager.Instance.Graphics.SetRenderTarget(null);
      OkuManager.Instance.Graphics.UseShaderProgram(null);
      
      //OkuManager.Instance.Graphics.Viewport.SetValues(ScreenWidth * -0.5f, ScreenWidth * 0.5f, ScreenHeight * -0.5f, ScreenHeight * 0.5f);
      OkuManager.Instance.Graphics.DrawScreenAlignedQuad(_target);
    }
    
  }
}
