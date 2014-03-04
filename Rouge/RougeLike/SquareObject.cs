using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;

namespace RougeLike
{
  public class SquareObject : GameObjectBase
  {
    private int _width = 10;
    private int _height = 10;
    private Color _color = Color.Red;

    public override string ObjectType
    {
      get { return "square"; }
    }

    public override void Init()
    {
    }

    public override void Update(float dt)
    {
    }

    public override void Render()
    {
      float halfWidth = _width * 0.5f;
      float halfHeight = _height * 0.5f;
      OkuManager.Instance.Graphics.DrawRectangle(-halfWidth, halfWidth, -halfHeight, halfHeight, _color);
    }

    public override void Finish()
    {
    }

    protected override StringPairMap DoSave()
    {
      StringPairMap result = new StringPairMap();
      result.Add("width", _width.ToString());
      result.Add("height", _height.ToString());
      result.Add("color", _color.ToString());
      return result;
    }

    protected override void DoLoad(StringPairMap data)
    {
      _width = int.Parse(data["width"]);
      _height = int.Parse(data["height"]);
      _color = Color.Parse(data["color"]);
    }
  }
}
