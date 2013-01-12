using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Scenes
{
  public abstract class SceneObject : StoreableEntity
  {
    private SceneNode _sceneNode = null;

    /// <summary>
    /// Gets or sets the scene node this object belongs to. SHOULD BE REMOVED!
    /// </summary>
    public SceneNode SceneNode
    {
      get { return _sceneNode; }
      set { _sceneNode = value; }
    }

    public abstract AABB BoundingBox { get; }
    public abstract Vector2f[] Shape { get; }
    public abstract bool IsStatic { get; }
    public abstract void Render(Scene scene);

  }
}
