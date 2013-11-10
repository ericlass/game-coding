using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Collections;
using OkuBase.Audio;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Settings;
using OkuBase.Timer;
using OkuBase.Input;

namespace OkuBaseTest
{
  public class FirstTestGame : OkuGame
  {
    private Image _image = null;
    private float _angle = 0.0f;
    private Vector2f _position = Vector2f.Zero;
    private Color _tint = Color.White;
    private Source _source = null;
    private RenderTarget _target = null;

    private int _counter = 0;
    private int _intervalId = 0;

    private Mesh _text = null;

    private Shader _ps = null;
    private Shader _vs = null;
    private ShaderProgram _program = null;

    private bool _consoleVisible = false;
    private OnScreenConsole _console = null;

    private const String _vertexShader =
      "varying vec2 texCoord;\n" +
      "\n" +
      "void main( void )\n" +
      "{\n" +
      "  gl_Position = ftransform();\n" +
      "  texCoord = gl_MultiTexCoord0.xy;\n" +
      "  gl_FrontColor = gl_Color;\n" +
      "}";

    private const String _pixelShader =
      "varying vec2 texCoord;\n" +
      "uniform sampler2D texture;\n" +
      "uniform vec4 mycolor;\n" +
      "\n" +
      "void main ( void )\n" +
      "{\n" +
      "  float dist = 1.0 - (5.0 * (pow(texCoord.x - 0.5, 2.0) + pow(texCoord.y - 0.5, 2.0)));\n" +
      "  vec4 tex = texture2D(texture, texCoord);\n" +
      "  gl_FragColor = tex * mycolor * dist;\n" +
      //"  gl_FragColor = gl_Color;\n" +
      "}";

    public override OkuSettings Configure()
    {
      OkuSettings result = base.Configure();

      result.Graphics.BackgroundColor = Color.Black;
      result.Graphics.TextureFilter = TextureFilter.NearestNeighbor;

      result.Audio.DriverName = "openal";

      return result;
    }

    public override void Initialize()
    {
      ImageData data = ImageData.FromFile("pilz.png");
      _image = Oku.Graphics.NewImage(data);

      SpriteFont font = new SpriteFont("Calibri", 12.0f, FontStyle.Regular, true);
      _text = font.GetStringMesh("Hello World!", 0, 600, Color.White);

      Sound sound = Sound.FromFile("sinus.wav");
      _source = Oku.Audio.NewSource(sound);

      _target = Oku.Graphics.NewRenderTarget(512, 384);

      _vs = new Shader(_vertexShader, ShaderType.VertexShader);
      _ps = new Shader(_pixelShader, ShaderType.PixelShader);

      _program = Oku.Graphics.NewShaderProgram(_vs, _ps);
      Oku.Graphics.UseShaderProgram(_program);
      Oku.Graphics.SetShaderFloat(_program, "mycolor", 1.0f, 1.0f, 1.0f, 1.0f);
      Oku.Graphics.SetShaderTexture(_program, "texture", _target);
      Oku.Graphics.UseShaderProgram(null);

      Oku.Input.OnKeyPressed += new KeyEventDelegate(KeyPressed);
      Oku.Input.OnMouseReleased +=new MouseEventDelegate(MouseReleased);

      _console = new OnScreenConsole();
    }

    private void OnInterval(int id, object data)
    {
      Random rand = new Random();
      _position = new Vector2f(rand.Next(-350, 350), rand.Next(-250, 250));

      _counter -= 1;
      if (_counter <= 0)
        Oku.Timer.ClearInterval(_intervalId);
    }

    private void OnTimer(int id, object data)
    {
      _tint = Color.RandomColor(new Random());
    }

    public override void Update(float dt)
    {
      if (!_consoleVisible)
      {
        _angle -= 180 * dt;
      }
    }

    public override void Render()
    {
      Oku.Graphics.SetRenderTarget(_target);
      Oku.Graphics.BackgroundColor = Color.Magenta;
      Oku.Graphics.Clear();

      Oku.Graphics.DrawImage(_image, _position.X, _position.Y, _angle, 1, 1, _tint);
      Oku.Graphics.DrawPoint(0, 0, 1, Color.Red);
      
      Oku.Graphics.SetRenderTarget(null);
      Oku.Graphics.BackgroundColor = Color.Black;
      Oku.Graphics.Clear();

      Oku.Graphics.DrawScreenAlignedQuad(_target, Color.White);
      //Oku.Graphics.DrawImage(_target, 0, 0);
      //Oku.Graphics.UseShaderProgram(_program);
      //Oku.Graphics.DrawScreenAlignedQuad(null, Color.Red);
      //Oku.Graphics.UseShaderProgram(null);
      Oku.Graphics.BeginScreenSpace();
      Oku.Graphics.DrawMesh(_text);
      Oku.Graphics.EndScreenSpace();

      if (_consoleVisible)
        _console.Draw();
    }

    public void KeyPressed(Keys key)
    {
      if (_consoleVisible && (key != Keys.Oem5))
        return;

      if (key == Keys.Space && _counter <= 0)
      {
        _counter = 5;
        _intervalId = Oku.Timer.SetInterval(1000, new TimerEventDelegate(OnInterval));
      }
      if (key == Keys.T)
      {
        Oku.Timer.SetTimer(1000, new TimerEventDelegate(OnTimer));
      }
      if (key == Keys.S)
      {
        Oku.Audio.Play(_source);
      }
      if (key == Keys.Oem5)
      {
        _consoleVisible = !_consoleVisible;
        _console.Active = _consoleVisible;
      }
    }

    public void MouseReleased(MouseButton button)
    {
      if (button == MouseButton.Left)
      {
        _position = Oku.Graphics.ScreenToWorld(Oku.Input.Mouse.X, Oku.Input.Mouse.Y);
        Oku.Graphics.Title = _position.ToString();
      }
    }

  }
}
