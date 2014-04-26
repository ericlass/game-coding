using System;
using OkuBase;
using OkuBase.Settings;
using OkuBase.Graphics;
using OkuBase.Geometry;
using OkuBase.Platform;

namespace RougeLike
{
  public class RougeGame : OkuGame
  {
    #region Shaders

    private const string VertexShaderSource =
      "void main()\n" +
      "{\n" +
      "  gl_Position    = gl_ModelViewProjectionMatrix * gl_Vertex;\n" +
      "  gl_TexCoord[0] = gl_MultiTexCoord0;\n" +
      "}\n";

    private const string SilhouettePixelShaderSource =
      "uniform sampler2D tex;\n" +
      "\n" +
      "void main()\n" +
      "{\n" +
      "  vec4 texCol = texture2D(tex, gl_TexCoord[0].xy);\n" +
      "  gl_FragColor = vec4(0, 0, 0, texCol.a);\n" +
      "}";

    private const string ShadowPixelShaderSource =
      "uniform vec2 lightDir;\n" +
      "uniform sampler2D tex;\n" +
      "\n" +
      "const int samples = 100;\n" +
      "\n" +
      "void main()\n" +
      "{\n" +
      "	float stepSize = 2.0 / 512.0;\n" +
      "	vec2 lp = normalize(lightDir);\n" +
      "	vec2 texCoord = gl_TexCoord[0].xy;\n" +
      "	float baseColor = texture2D(tex, texCoord).r;\n" +
      "	float color = baseColor;\n" +
      "\n" +
      "	float dist = stepSize;\n" +
      "	for (int i = 0; i < samples; i++)\n" +
      "	{\n" +
      "		vec2 tc = texCoord - (lp * dist);\n" +
      "		tc.x = clamp(tc.x, 0.0, 1.0);\n" +
      "		tc.y = clamp(tc.y, 0.0, 1.0);\n" +
      "		float col = texture2D(tex, tc).r;\n" +
      "		color *= col;\n" +
      "		dist += stepSize;\n" +
      "	}\n" +
      "\n" +
      "	vec4 invColor = vec4(1.0 - baseColor, 1.0 - baseColor, 1.0 - baseColor, 1.0);\n" +
      "	color += invColor;\n" +
      "\n" +
      "	gl_FragColor = vec4(color, color, color, 1.0);\n" +
      "}";

    private const string BlurPixelShaderSource =
      "uniform sampler2D tex;\n" +
      "\n" +
      "void main()\n" +
      "{\n" +
      "	float div = 1.0 / 600;\n" +
      "	vec2 texCoord = gl_TexCoord[0].xy;\n" +
      "	texCoord.x -= div;\n" +
      "	texCoord.y -= div;\n" +
      "	\n" +
      "	vec4 color = vec4(0.0, 0.0, 0.0, 0.0);\n" +
      "	for (int y = 0; y < 3; y++)\n" +
      "	{\n" +
      "		for (int x = 0; x < 3; x++)\n" +
      "		{\n" +
      "			color += texture2D(tex, texCoord);\n" +
      "			texCoord.x += div;\n" +
      "		}\n" +
      "		texCoord.y += div;\n" +
      "		texCoord.x -= div * 3;\n" +
      "	}\n" +
      "\n" +
      "    gl_FragColor = color / 9;\n" +
      "}";

    private const string ColorPixelShaderSource =
      "uniform sampler2D tex;\n" +
      "\n" +
      "void main()\n" +
      "{\n" +
      "  vec4 texCol = texture2D(tex, gl_TexCoord[0].xy);\n" +
      "  gl_FragColor = texCol;\n" +
      "}";

    #endregion

    private const int ScreenWidth = 1280;
    private const int ScreenHeight = 720;

    private int _wheelDelta = 0;
    private RenderTarget _renderTarget = null;

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
      Oku.Input.OnMouseWheel += Input_OnMouseWheel;

      _renderTarget = OkuManager.Instance.Graphics.NewRenderTarget(ScreenWidth, ScreenHeight);

      //GameData.Instance.Scenes = SceneFactory.Instance.LoadScene("testscene.json");
      GameData.Instance.Scenes = SceneFactory.Instance.GenerateScene();
      GameData.Instance.ActiveScene = GameData.Instance.Scenes[0];
    }

    private void Input_OnMouseWheel(int delta)
    {
      _wheelDelta += delta;
    }
    
    public override void Update(float dt)
    {
      GameData.Instance.ActiveScene.Update(dt);
      GameData.Instance.EventQueue.ProcessEvents();

      if (Oku.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.F3))
        GameData.Instance.DebugDraw = !GameData.Instance.DebugDraw;

      if (_wheelDelta != 0)
      {
        LightObject light = GameData.Instance.ActiveScene.GameObjects.GetObjectById("light02") as LightObject;
        if (light != null)
          light.Direction = Vector2f.Rotate(light.Direction, _wheelDelta / 100.0f);
      }

      _wheelDelta = 0;
    }
    
    public override void Render()
    {
      Vector2f center = Oku.Graphics.Viewport.Center;

      OkuManager.Instance.Graphics.SetRenderTarget(_renderTarget);
      
      GameData.Instance.ActiveScene.Render();

      OkuManager.Instance.Graphics.SetRenderTarget(null);
      OkuManager.Instance.Graphics.DrawScreenAlignedQuad(_renderTarget);
    }
    
  }
}
