using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Geometry;

namespace OkuEngine.Scenes.Backdrops
{
  public abstract class Backdrop : IStoreable
  {
    public abstract Polygon[] Shapes { get; }

    public abstract void Update(float dt);
    public abstract void Render(Scene scene);

    public abstract bool Load(XmlNode node);
    public abstract bool Save(XmlWriter writer);
  }
}
