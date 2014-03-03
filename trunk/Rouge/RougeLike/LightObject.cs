using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace RougeLike
{
  public class LightObject : GameObjectBase
  {
    public Color _color = Color.White;
    public float _power = 1.0f;
    public float _radius = 100.0f;

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
      }
    }

    public override void Finish()
    {
    }

    protected override StringPairMap DoSave()
    {
      StringPairMap result = new StringPairMap();
      result.Add("color", _color.ToString());
      result.Add("radius", _radius.ToString());
      result.Add("power", _power.ToString());
      return result;
    }

    protected override void DoLoad(StringPairMap data)
    {
      Color col = Color.Black;
      if (!Color.TryParse(data["color"], out col))
        _color = col;
      else
        throw new OkuBase.OkuException("Could not parse color '" + data["color"] + "'");

      _radius = float.Parse(data["radius"]);
      //_power = float.Parse(data["power"]);
    }

  }
}
