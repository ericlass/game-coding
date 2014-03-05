using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Utils;

namespace RougeLike
{
  public class LightObject : GameObjectBase
  {
    private Color _color = Color.White;
    private float _power = 1.0f;
    private float _radius = 100.0f;
    private LightType _lightType = LightType.Point;
    private Vector2f _direction = Vector2f.One;

    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

    public float Radius
    {
      get { return _radius; }
      set { _radius = value; }
    }

    public float Power
    {
      get { return _power; }
      set { _power = value; }
    }

    public LightType LightType
    {
      get { return _lightType; }
      set { _lightType = value; }
    }

    public Vector2f Direction
    {
      get { return _direction; }
      set { _direction = value; }
    }

    public override string ObjectType
    {
      get { return "light"; }
    }

    public override void Init()
    {      
    }

    public override void Update(float dt)
    {
    }

    public override void Render()
    {
      if (GameData.Instance.DebugDraw)
      {
        Oku.Graphics.DrawPoint(0, 0, 5.0f, Color.Yellow);

        if (_lightType == RougeLike.LightType.Infinit)
        {
          Vector2f end = _direction * 20.0f;
          Oku.Graphics.DrawLine(0, 0, end.X, end.Y, 2.0f, Color.Yellow);
        }
      }
    }

    public override void Finish()
    {
    }

    protected override StringPairMap DoSave()
    {
      StringPairMap result = new StringPairMap();
      
      if (!_color.Equals(Color.White))
        result.Add("color", _color.ToString());
      
      if (_radius != 100.0f)
        result.Add("radius", Converter.FloatToString(_radius));

      if (_power != 1.0f)
        result.Add("power", Converter.FloatToString(_power));

      if (_lightType != RougeLike.LightType.Point)
        result.Add("lighttype", _lightType.ToString());

      if (_direction != Vector2f.One)
        result.Add("direction", _direction.ToString());

      return result;
    }

    protected override void DoLoad(StringPairMap data)
    {
      if (data.ContainsKey("lighttype"))
        _lightType = Converter.ParseEnum<LightType>(data["lighttype"]);
      
      if (data.ContainsKey("color"))
        _color = Color.Parse(data["color"]);

      if (data.ContainsKey("radius"))
        _radius = Converter.StrToFloat(data["radius"]);

      if (data.ContainsKey("power"))
        _power = Converter.StrToFloat(data["power"]);
      
      if (data.ContainsKey("direction"))
        _direction = Vector2f.Normalize(Vector2f.Parse(data["direction"]));
    }

  }
}
