using System;
using OkuBase.Geometry;

namespace OkuEngine.Components
{
  public interface IRenderComponent : IComponent
  {
    Mesh GetMesh();
  }
}
