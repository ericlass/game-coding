using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public interface ISceneNode
  {
    SceneNodeProperties Properties { get; }
    void SetTransform(out Matrix3 toWorld);
    void SetTransform(out Matrix3 toWorld, out Matrix3 fromWorld);
  }
}
