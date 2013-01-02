using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Geometry;

namespace OkuEngine.Scenes.Backdrops
{
  public class ImageBackdrop : Backdrop
  {
    private Polygon[] _shapes = null;

    public override Polygon[] Shapes
    {
      get { return _shapes; }
    }

    public override void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public override void Render(Scene scene)
    {
      throw new NotImplementedException();
    }

    public override bool Load(XmlNode node)
    {
      throw new NotImplementedException();
    }

    public override bool Save(XmlWriter writer)
    {
      throw new NotImplementedException();
    }
  }
}
