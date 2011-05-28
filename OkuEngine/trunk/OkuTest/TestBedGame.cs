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

    public override void Initialize()
    {
      OkuDrivers.Renderer.ClearColor = Color.White;

      ImageContent content = new ImageContent(".\\content\\smiley.png");
      _smiley = new ImageInstance(content);
      _smiley.TintColor = Color.Green;

      VertexList verts = new VertexList();
      Random rand = new Random();
      int width = OkuData.Globals.Get<int>(OkuConstants.VarScreenWidth);
      int height = OkuData.Globals.Get<int>(OkuConstants.VarScreenHeight);
      for (int i = 0; i < 50; i++)
      {
        Vertex vert = new Vertex();
        vert.Position.X = (float)(rand.NextDouble()) * width;
        vert.Position.Y = (float)(rand.NextDouble()) * height;
        vert.Color = Color.RandomColor(rand);
        verts.Add(vert);
      }
      PolygonContent polyContent = new PolygonContent(verts);
      _poly = new PolygonInstance(polyContent);
      _poly.Interpretation = VertexInterpretation.PolygonClosed;
      _poly.LineWidth = 3;
      _poly.LineColor = new Color(0, 0, 1);

      //SoundContent sound = new SoundContent(".\\content\\sinus.wav");
      //SoundContent sound = new SoundContent("D:\\Musik\\Meshuggah\\I\\Meshuggah - I.wav");
      SoundContent sound = new SoundContent("D:\\Temp\\sinus_mono.wav");

      _sound = new SoundInstance(sound);
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
      _smiley.Draw(_pos1, _rotation);
    }

  }
}
