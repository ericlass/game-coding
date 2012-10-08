using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.Scenes;

namespace OkuEngine
{
  public class InheritingRenderable
  {
    private IRenderable _renderable = null;
    private InheritingRenderable _parent = null;

    public InheritingRenderable()
    {
    }

    public InheritingRenderable(InheritingRenderable parent)
    {
      _parent = parent;
    }

    public InheritingRenderable Parent
    {
      get { return _parent; }
      set { _parent = value; }
    }

    public void Update(float dt)
    {
      if (_renderable != null)
        _renderable.Update(dt);
    }

    public bool RenderInherited(Scene scene)
    {
      if (_renderable != null)
      {
        _renderable.Render(scene);
        return true;
      }
      else if (_parent != null)
        return _parent.RenderInherited(scene);

      return false;
    }

  }
}
