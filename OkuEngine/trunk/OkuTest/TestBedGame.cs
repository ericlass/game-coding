using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OkuEngine;
using OkuEngine.Driver.Renderer;

namespace OkuTest
{
  public class TestBedGame : OkuGame
  {
    private ImageContent _smiley = null;
    private float _rotation = 0.0f;
    private Vector _pos1 = new Vector(0, 50);

    private PolygonInstance _poly = null;
    private SoundInstance _sound = null;
    private MeshInstance _mesh = null;
    private SpriteFont _font = null;
    private MeshInstance _text = null;
    private MeshInstance _guiText = null;
    private PixelShaderContent _shader = null;

    /*public void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = Color.White;
      renderParams.Fullscreen = false;
      renderParams.Width = 1024;
      renderParams.Height = 768;
      renderParams.Passes = 2;
    }*/

    public override void Initialize()
    {
      _smiley = new ImageContent(".\\content\\smiley.png");

      Vector[] verts = new Vector[50];
      Color[] colors = new Color[verts.Length];
      Random rand = new Random();
      int width = (int)OkuManagers.Renderer.ViewPort.Width;
      int height = (int)OkuManagers.Renderer.ViewPort.Height;
      for (int i = 0; i < verts.Length; i++)
      {
        verts[i] = new Vector((float)(rand.NextDouble() - 0.5) * width, (float)(rand.NextDouble() - 0.5) * height);
        colors[i] = Color.RandomColor(rand);
      }
      VertexContent polyContent = new VertexContent(verts, colors);
      _poly = new PolygonInstance(polyContent);
      _poly.Interpretation = VertexInterpretation.PolygonClosed;
      _poly.LineWidth = 3;
      _poly.LineColor = Color.Blue;

      SoundContent sound = new SoundContent(".\\content\\laser.wav");
      //SoundContent sound = new SoundContent("D:\\Musik\\Meshuggah\\I\\Meshuggah - I.wav");
      //SoundContent sound = new SoundContent("D:\\Temp\\sinus_mono.wav");

      _sound = new SoundInstance(sound);

      int numVerts = 10;
      verts = new Vector[numVerts];
      colors = new Color[numVerts];
      Vector[] texCoords = new Vector[numVerts];
      for (int i = 0; i < numVerts; i++)
      {
        int x = (i * 50) - 250;
        int y = ((i % 2) * 50) + 200;

        verts[i] = new Vector(x, y);
        colors[i] = Color.RandomColor(rand);
        texCoords[i] = new Vector((float)i / numVerts, (i % 2));
      }
      polyContent = new VertexContent(verts, texCoords, colors);
      _mesh = new MeshInstance(polyContent);
      _mesh.Mode = MeshMode.TriangleStrip;

      ImageContent car = new ImageContent(".\\content\\led_blue.png");

      _mesh.Texture = car;

      _font = new SpriteFont("Calibri", 12, System.Drawing.FontStyle.Regular, true);
      //_text = _font.GetStringMesh("AB\nCD", 0, 0, Color.Black);

      _guiText = _font.GetStringMesh("Ammo: 100", 3, 768, Color.Black);

      _text = _font.GetStringMesh(
        "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore\n" +
        "aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren,\n" +
        "no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr,\n" +
        "sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et\n" +
        "accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit\n" +
        "amet.", 0, 0, Color.Black);      

      //Default shader
      //_shader = new PixelShaderContent("uniform sampler2D texture;\nvarying vec2 Texcoord;\n\nvoid main( void )\n{\n  gl_FragColor = texture2D(texture, Texcoord) * gl_Color;   \n}");

      //Invert shader
      _shader = new PixelShaderContent("uniform sampler2D texture;\nvarying vec2 Texcoord;\n\nvoid main( void )\n{\n  vec4 color = texture2D(texture, Texcoord);\n  gl_FragColor = vec4(1.0 - color.r, 1.0 - color.g, 1.0 - color.b, color.a) * gl_Color;\n}");
    }

    public override void Update(float dt)
    {
      _rotation += dt * 90;

      if (OkuManagers.Input.Mouse.ButtonPressed(MouseButton.Left))
        _sound.Play();

      float speed = 200 * dt;
      Vector center = OkuManagers.Renderer.ViewPort.Center;
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Left))
        center.X -= speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Right))
        center.X += speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Up))
        center.Y -= speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Down))
        center.Y += speed;      

      speed = dt;
      Vector scale = OkuManagers.Renderer.ViewPort.Scale;
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Add))
      {
        scale.X += speed;
        scale.Y += speed;
      }
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Subtract))
      {
        scale.X -= speed;
        scale.Y -= speed;
      }

      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.NumPad0))
        scale = Vector.One;
      
      OkuManagers.Renderer.ViewPort.Center = center;
      OkuManagers.Renderer.ViewPort.Scale = scale;
    }

    public override void Render(int pass)
    {
      switch (pass)
      {
        case 0:
          _poly.Draw();

          OkuManagers.Renderer.DrawPoints(_poly.Content.Positions, _poly.Content.Colors, _poly.Content.Positions.Length, 10);

          OkuManagers.Renderer.DrawImage(_smiley, _pos1);
          _mesh.Draw();

          _text.Draw();

          Vector[] transformed = new Vector[_guiText.Vertices.Positions.Length];
          OkuManagers.Renderer.ViewPort.ScreenSpaceMatrix.Transform(_guiText.Vertices.Positions, transformed);
          OkuManagers.Renderer.DrawMesh(transformed, _guiText.Vertices.TexCoords, _guiText.Vertices.Colors, _guiText.Vertices.Positions.Length, _guiText.Mode, _guiText.Texture);
          break;

        case 1:
          //OkuDrivers.Renderer.UseShader(_shader);
          ImageContent passResult = OkuManagers.Renderer.GetPassResult(pass - 1, 0);
          //OkuDrivers.Renderer.SetShaderTexture(_shader, "texture", passResult);
          OkuManagers.Renderer.DrawScreenAlignedQuad(passResult);
          //OkuDrivers.Renderer.UseShader(null);
          //_smiley.Draw(_pos1, _rotation);
          break;
          
        default:
          break;
      }
      
    }

  }
}
