using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike.Objects
{
  public class BackgroundObject : GameObjectBase
  {
    private string _imageName = null;
    private ImageBase _image = null;

    public string ImageName
    {
      get { return _imageName; }
      set { _imageName = value; }
    }

    public override string ObjectType
    {
      get { return "background"; }
    }

    public override void Init()
    {
      _image = GameData.Instance.ActiveScene.Content.GetImage(_imageName);
      RenderDescription.Image = _image;

      this.Scale = new Vector2f(32, 16);
    }

    public override void Update(float dt)
    {
    }

    public override void Finish()
    {
    }

    protected override StringPairMap DoSave()
    {
      return null;
    }

    protected override void DoLoad(StringPairMap data)
    {
    }
  }
}
