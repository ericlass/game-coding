using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public class RootNode : SceneNode
  {
    public RootNode() : base(-1, "Root", RenderPass.None, Color.Red, Matrix3.Indentity)
    {
      //TODO: Create one child for each render pass
    }

    public override bool AddChild(ISceneNode node)
    {
      //TODO: Add node depending on its render pass to one of the nodes created in the constructor
      return base.AddChild(node);
    }

  }
}
