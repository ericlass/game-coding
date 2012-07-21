using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public class RootNode : SceneNode
  {
    public RootNode() : base(-1, "Root", Matrix3.Identity)
    {
      _props.Tint = Color.Red;
      //TODO: Create one child for each render pass
    }

    public override bool AddChild(SceneNode node)
    {
      //TODO: Add node depending on its render pass to one of the nodes created in the constructor
      return base.AddChild(node);
    }

    public override bool RenderChildren(Scene scene)
    {
      //TODO: Render sorted by render pass
      return base.RenderChildren(scene);
    }

  }
}
