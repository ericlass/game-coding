using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Rendering;
using OkuEngine.Collision;
using Newtonsoft.Json;

namespace OkuEngine.Collision
{
  /// <summary>
  /// Defines a static piece of level geometry with collision information
  /// and an optional renderable.
  /// </summary>
  public class Brush : SceneObject
  {
    private IRenderable _renderable = null;
    private AABB _boundingBox = new AABB();
    private Vector2f[] _shape = null;

    /// <summary>
    /// Create a new brush.
    /// </summary>
    public Brush()
    {
    }

    /// <summary>
    /// Gets the bounding box of the brush.
    /// </summary>
    public override AABB BoundingBox
    {
      get { return _boundingBox; }
    }

    /// <summary>
    /// Gets or sets the renderable of the brush.
    /// </summary>
    [JsonPropertyAttribute]
    public IRenderable Renderable
    {
      get { return _renderable; }
      set { _renderable = value; }
    }

    /// <summary>
    /// Gets or sets the shape of the brush. Can be null if only AABB is specified.
    /// </summary>
    [JsonPropertyAttribute]
    public override Vector2f[] Shape
    {
      get { return _shape; }
      set { _shape = value; }
    }

    /// <summary>
    /// Gets if the brush is static or not, so it always returns true.
    /// </summary>
    public override bool IsStatic
    {
      get { return true; }
    }

    /// <summary>
    /// Renders the brushes renderable if there is any using the given scene.
    /// </summary>
    /// <param name="scene">The scene to be used.</param>
    public override void Render(Scene scene)
    {
      if (_renderable != null)
        _renderable.Render(scene);
    }

    public override bool AfterLoad()
    {
      if (_renderable != null)
      {
        if (!_renderable.AfterLoad())
          return false;
      }

      if (_shape != null)
      {
        _boundingBox = _shape.GetBoundingBox();
      }
      else
      {
        if (_renderable != null)
          _boundingBox = _renderable.GetBoundingBox();
        else
        {
          OkuManagers.Instance.Logger.LogError("Brush " + Id + " does not have a renderable or shape!");
          return false;
        }
      }

      return true;
    }

  }
}
