using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using OkuBase.Geometry;
using OkuBase.Utils;

namespace RougeLike
{
  public class GrassObject : GameObjectBase
  {
    private float _width = 16.0f;
    private float _height = 8.0f;
    private float _thickness = 2.0f;
    private Color _color = Color.Green;
    private int _numberOfBlades = 6;

    private float time = 0;

    public float Width
    {
      get { return _width; }
      set { _width = value; }
    }

    public float Height
    {
      get { return _height; }
      set { _height = value; }
    }

    public float Thickness
    {
      get { return _thickness; }
      set { _thickness = value; }
    }

    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

    public int NumberOfBlades
    {
      get { return _numberOfBlades; }
      set { _numberOfBlades = value; }
    }

    public override string ObjectType
    {
      get { return "grass"; }
    }

    public override void Init()
    {
    }

    public override void Update(float dt)
    {
      time += dt * 2;
    }

    public override void Render()
    {
      float numLines = 3;
      float xStep = _width / (_numberOfBlades - 1);
      float yStep = _height / numLines;

      PerlinNoise noise = new PerlinNoise();

      for (int i = 0; i < _numberOfBlades; i++)
      {
        float x = -(_width / 2) + (xStep * i);
        //x += noise.Noise(Position.X + x, Position.Y + _height, 3, 200) * 20;
        float y = 0;

        float curve = (float)Math.Sin(Position.X + (x / 20) + time);
        curve += noise.Noise(x, Position.Y, 3, 200) * 2;
        curve *= 0.6f;

        for (int j = 0; j < numLines; j++)
        {
          float nx = x + (curve * j);
          float ny = y + yStep;
          Oku.Graphics.DrawLine(x, y, nx, ny, _thickness, _color);

          x = nx;
          y = ny;
        }
      }
    }

    public override void Finish()
    {
    }

    protected override StringPairMap DoSave()
    {
      StringPairMap result = new StringPairMap();
      result.Add("width", _width.ToString());
      result.Add("height", _height.ToString());
      result.Add("thickness", _thickness.ToString());
      result.Add("color", _color.ToString());
      result.Add("numblades", _numberOfBlades.ToString());
      return result;
    }

    protected override void DoLoad(StringPairMap data)
    {
      if (data.ContainsKey("width"))
        _width = Converter.StrToFloat(data["width"]);

      if (data.ContainsKey("height"))
        _height = Converter.StrToFloat(data["height"]);

      if (data.ContainsKey("thickness"))
        _thickness = Converter.StrToFloat(data["thickness"]);

      if (data.ContainsKey("color"))
        _color = Color.Parse(data["color"]);

      if (data.ContainsKey("numblades"))
        _numberOfBlades = int.Parse(data["numblades"]);
    }
  }
}
