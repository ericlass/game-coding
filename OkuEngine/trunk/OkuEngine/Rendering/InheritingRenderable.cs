using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;

namespace OkuEngine
{
  /// <summary>
  /// Can be used to define a renderable hierarchie.
  /// The values of the children add and override the values of the parents.
  /// Is used for actor states.
  /// </summary>
  public class InheritingRenderable
  {
    private IRenderable _renderable = null;
    private InheritingRenderable _parent = null;

    /// <summary>
    /// Creates a new InheritingRenderable.
    /// </summary>
    public InheritingRenderable()
    {
    }

    /// <summary>
    /// Creates a new InheritingRenderable with the given parent.
    /// </summary>
    /// <param name="parent"></param>
    public InheritingRenderable(InheritingRenderable parent)
    {
      _parent = parent;
    }

    /// <summary>
    /// Gets or sets the renderable. If null and the parent is not null,
    /// the renderable of the parent is used recursivley.
    /// </summary>
    public IRenderable Renderable
    {
      get { return _renderable; }
      set { _renderable = value; }
    }

    /// <summary>
    /// Gets or sets the parent of the InheritingRenderable.
    /// </summary>
    public InheritingRenderable Parent
    {
      get { return _parent; }
      set { _parent = value; }
    }

    /// <summary>
    /// Gets the bounding box of the renderable taking into account the hierarchy.
    /// </summary>
    /// <returns>The bounding box derived from the renderable.</returns>
    public AABB InheritedAABB()
    {
      if (_renderable != null)
        return _renderable.GetBoundingBox();
      else
        if (_parent != null)
          return _parent.InheritedAABB();

      return default(AABB);
    }

    /// <summary>
    /// Updates the renderable.
    /// </summary>
    /// <param name="dt">The time passed since the last frame in fractional seconds.</param>
    public void Update(float dt)
    {
      if (_renderable != null)
        _renderable.Update(dt);
    }

    /// <summary>
    /// Renders the renderable. If no renderable is set and the parent
    /// is not null, the parent is rendered recursively.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if something was rendered, false if no renderable and parent is set.</returns>
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
