using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using Newtonsoft.Json;

namespace OkuEngine.Rendering
{
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public interface IRenderable : IStoreable
  {
    void Update(float dt);
    void Render(Scene scene);
    Rectangle2f GetBoundingBox();
    Circle GetBoundingCircle();
  }
}
