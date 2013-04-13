using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a hierarchical transform component where the tranform is 
  /// relative to the transform of a parent actor.
  /// </summary>
  public class HierarchicalTransformComponent : TransformComponent
  {
    private int _parentId = 0;

    private Actor _parent = null;

    /// <summary>
    /// Gets or sets the id of the parent actor.
    /// </summary>
    [JsonPropertyAttribute]
    public int ParentId
    {
      get { return _parentId; }
      set { _parentId = value; }
    }

    /// <summary>
    /// Gets the world space matrix of the transform.
    /// </summary>
    /// <returns>The world space matrix of the transform</returns>
    public override Matrix3 GetWorldSpaceMatrix()
    {
      Matrix3 result = _transform.AsMatrix();

      TransformComponent comp = _parent.GetComponent<TransformComponent>(TransformComponent.ComponentName);
      if (comp != null)
        result = comp.GetWorldSpaceMatrix() * result;

      return result;
    }

    public override bool AfterLoad()
    {
      _parent = OkuData.Instance.Actors[_parentId];
      if (_parent == null)
        return false;
      return base.AfterLoad();
    }

  }
}
