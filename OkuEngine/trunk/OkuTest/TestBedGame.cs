using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OkuEngine;

namespace OkuTest
{
  public class TestBedGame : OkuGame
  {
    private ImageInstance _smiley = null;
    private float _rotation = 0.0f;
    private Vector _pos1 = new Vector(100, 100);

    private PolygonInstance _poly = null;
    private SoundInstance _sound = null;
    private MeshInstance _mesh = null;
    private SpriteFont _font = null;
    private MeshInstance _text = null;

    public override void Initialize()
    {
      OkuDrivers.Renderer.ClearColor = Color.White;

      ImageContent content = new ImageContent(".\\content\\smiley.png");
      _smiley = new ImageInstance(content);
      _smiley.TintColor = Color.Green;

      Vector[] verts = new Vector[50];
      Color[] colors = new Color[verts.Length];
      Random rand = new Random();
      int width = OkuData.Globals.Get<int>(OkuConstants.VarScreenWidth);
      int height = OkuData.Globals.Get<int>(OkuConstants.VarScreenHeight);
      for (int i = 0; i < verts.Length; i++)
      {
        verts[i] = new Vector((float)(rand.NextDouble()) * width, (float)(rand.NextDouble()) * height);
        colors[i] = Color.RandomColor(rand);
      }
      VertexContent polyContent = new VertexContent(verts, colors);
      _poly = new PolygonInstance(polyContent);
      _poly.Interpretation = VertexInterpretation.PolygonClosed;
      _poly.LineWidth = 3;
      _poly.LineColor = new Color(0, 0, 1);

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
        int x = (i * 50) + 50;
        int y = ((i % 2) * 50) + 200;

        verts[i] = new Vector(x, y);
        colors[i] = Color.RandomColor(rand);
        texCoords[i] = new Vector((float)i / numVerts, (i % 2));
      }
      polyContent = new VertexContent(verts, texCoords, colors);
      _mesh = new MeshInstance(polyContent);
      _mesh.Mode = MeshMode.TriangleStrip;

      ImageContent car = new ImageContent(".\\content\\car.png");

      _mesh.Texture = car;

      _font = new SpriteFont("Arial", 12, System.Drawing.FontStyle.Regular, true);
      _text = _font.GetStringMesh(
        "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore\n" +
        "aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren,\n" +
        "no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr,\n" +
        "sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et\n" +
        "accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit\n" +
        "amet.", 50, 500, Color.Black);
    }

    public override void Update(float dt)
    {
      _rotation += dt * 90;

      if (OkuDrivers.Input.Mouse.ButtonPressed(MouseButton.Left))
        _sound.Play();
    }

    public override void Render()
    {
      _poly.Draw();

      OkuDrivers.Renderer.DrawPoints(_poly.Content.Positions, _poly.Content.Colors, 10);

      _smiley.Draw(_pos1, _rotation);
      _mesh.Draw();

      _text.Draw();
    }

  }
}
