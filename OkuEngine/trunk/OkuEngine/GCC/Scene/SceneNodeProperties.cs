using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public class SceneNodeProperties
  {
    public int ActorId { get; set; }
    public string Name { get; set; }
    public Matrix3 Matrix { get; set; }
    public AABB Area { get; set; }
    public RenderPass RenderPass { get; set; }
    public Material Material { get; set; }
    public bool HasAlpha { get; set; }

    public SceneNodeProperties()
    {
      Matrix = Matrix3.Indentity;
      RenderPass = RenderPass.None;
      HasAlpha = false;
      Material = new Material();
    }

  }
}
