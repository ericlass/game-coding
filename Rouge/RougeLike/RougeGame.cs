using System;
using OkuBase;
using OkuBase.Settings;
using OkuBase.Graphics;
using OkuBase.Geometry;
using OkuBase.Platform;
using System.Windows.Forms;
using RougeLike.Objects;
using RougeLike.States;

namespace RougeLike
{
  public class RougeGame : OkuGame
  {
    //TODO: I think this should go into GameData
    private enum GameState
    {
      None,
      Playing
    }

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

    private RenderTarget _renderTarget = null;
    private GameState _currentStatet = GameState.None;
    private float _zoom = 1.0f;

    public override OkuSettings Configure()
    {
      OkuSettings settings = base.Configure();

      settings.Graphics.Width = ScreenWidth;
      settings.Graphics.Height = ScreenHeight;
      settings.Graphics.TextureFilter = TextureFilter.NearestNeighbor;
      settings.Graphics.BackgroundColor = Color.Magenta;

      settings.Audio.DriverName = "openal";

      return settings;
    }
    
    public override void Initialize()
    {
      _renderTarget = OkuManager.Instance.Graphics.NewRenderTarget(ScreenWidth, ScreenHeight);

      GameData.Instance.Scenes = SceneFactory.Instance.GenerateScene();
      GameData.Instance.ActiveScene = GameData.Instance.Scenes[0];

      _currentStatet = GameState.Playing;
    }

    public override void Update(float dt)
    {
      if (_currentStatet == GameState.Playing)
      {
        if (GameData.Instance.DebugMode)
        {
          float speed = 500 * _zoom;
          if (Oku.Input.Keyboard.KeyIsDown(Keys.ControlKey))
            speed = 1500 * _zoom;

          speed *= dt;
          Vector2f center = Oku.Graphics.Viewport.Center;

          if (Oku.Input.Keyboard.KeyIsDown(Keys.Left))
            center.X -= speed;

          if (Oku.Input.Keyboard.KeyIsDown(Keys.Right))
            center.X += speed;

          if (Oku.Input.Keyboard.KeyIsDown(Keys.Up))
            center.Y += speed;

          if (Oku.Input.Keyboard.KeyIsDown(Keys.Down))
            center.Y -= speed;

          Oku.Graphics.Viewport.Center = center;

          if (Oku.Input.Keyboard.KeyPressed(Keys.Add))
          {
            _zoom *= 2;
            Oku.Graphics.Viewport.Center = Oku.Graphics.Viewport.Center * 2;
          }
          if (Oku.Input.Keyboard.KeyPressed(Keys.Subtract))
          {
            _zoom /= 2;
            Oku.Graphics.Viewport.Center = Oku.Graphics.Viewport.Center / 2;
          }
        }        
        else
        {
          Oku.Graphics.Viewport.Center = GameData.Instance.ActiveScene.GameObjects.GetObjectById("player").Position;
          TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

          Rectangle2f mapRect = tilemap.GetMapRect();
          if (Oku.Graphics.Viewport.Left < mapRect.Min.X)
            Oku.Graphics.Viewport.Left = mapRect.Min.X;
          if (Oku.Graphics.Viewport.Right > mapRect.Max.X)
            Oku.Graphics.Viewport.Right = mapRect.Max.X;
          if (Oku.Graphics.Viewport.Bottom < mapRect.Min.Y)
            Oku.Graphics.Viewport.Bottom = mapRect.Min.Y;
          if (Oku.Graphics.Viewport.Top > mapRect.Max.Y)
            Oku.Graphics.Viewport.Top = mapRect.Max.Y;
        }

        GameData.Instance.ActiveScene.Update(dt);

        if (Oku.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.F3))
        {
          GameData.Instance.DebugMode = !GameData.Instance.DebugMode;
          if (GameData.Instance.DebugMode)
            _zoom = 1.0f;
        }
      }      
    }
    
    public override void Render()
    {
      if (_currentStatet == GameState.Playing)
      {
        Vector2f center = Oku.Graphics.Viewport.Center;

        OkuManager.Instance.Graphics.SetRenderTarget(_renderTarget);
        
        if (GameData.Instance.DebugMode)
          OkuManager.Instance.Graphics.ApplyAndPushTransform(Vector2f.Zero, new Vector2f(_zoom, _zoom), 0);

        GameData.Instance.ActiveScene.Render();

        if (GameData.Instance.DebugMode)
          OkuManager.Instance.Graphics.PopTransform();

        OkuManager.Instance.Graphics.SetRenderTarget(null);
        OkuManager.Instance.Graphics.DrawScreenAlignedQuad(_renderTarget);
      }      
    }
    
  }
}
