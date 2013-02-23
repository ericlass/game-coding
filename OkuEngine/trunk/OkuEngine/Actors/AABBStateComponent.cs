﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.States;
using OkuEngine.Geometry;
using Newtonsoft.Json;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a state component that calculates a bounding box
  /// from the renderable or shape components of the same state.
  /// </summary>
  public class AABBStateComponent : IStateComponent
  {
    private StateBase _owner = null;
    private bool _aabbValid = false;
    private AABB _aabb = new AABB();

    /// <summary>
    /// Gets or sets the owning state of the component.
    /// </summary>
    public StateBase Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public string ComponentTypeName
    {
      get { return Actor.ActorStateAABBComponentName; }
    }

    /// <summary>
    /// Gets the bounding box of the state fropm the shape or the renderable.
    /// </summary>
    /// <returns>The bounding box of the state.</returns>
    public AABB GetBoundingBox()
    {
      if (!_aabbValid)
      {
        RenderableStateComponent renderable = _owner.GetComponent<RenderableStateComponent>(Actor.ActorStateRenderableComponentName);
        ShapeStateComponent shape = _owner.GetComponent<ShapeStateComponent>(Actor.ActorStateShapeComponentName);

        if (shape != null && shape.Shape != null)
        {
          _aabb = shape.Shape.GetBoundingBox();
          _aabbValid = true;
        }
        else if (renderable != null && renderable.Renderable != null)
        {
          _aabb = renderable.Renderable.GetBoundingBox();
          _aabbValid = true;
        }
      }

      return _aabb;
    }

    /// <summary>
    /// Copies the component with all of its data.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public IStateComponent Copy()
    {
      return new AABBStateComponent();
    }

    /// <summary>
    /// Merges the data of the component with the given one.
    /// </summary>
    /// <param name="other">The component to merge into this component.</param>
    /// <returns>True if the merge was successfull, else false.</returns>
    public bool Merge(IStateComponent other)
    {
      return true;
    }

    public bool Load(XmlNode node)
    {
      return true;
    }

    public bool Save(XmlWriter writer)
    {
      return true;
    }    

  }
}
