using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Geometry;
using Newtonsoft.Json;

namespace OkuEngine.Scenes.Backdrops
{
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public abstract class Backdrop : IStoreable
  {
    [JsonPropertyAttribute]
    public abstract Polygon[] Shapes { get; set; }

    public abstract void Update(float dt);
    public abstract void Render(Scene scene);

    public abstract bool AfterLoad();

    public abstract float Width { get; set; }
    public abstract float Height { get; set; }
  }
}
