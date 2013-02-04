using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.States;
using OkuEngine.Geometry;

namespace OkuEngine.Actors
{
  public class AABBStateComponent : IStateComponent
  {
    private StateBase _owner = null;
    private bool _aabbValid = false;
    private AABB _aabb = new AABB();

    public StateBase Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public string ComponentName
    {
      get { return Actor.ActorStateAABBComponentName; }
    }

    public AABB GetBoundingBox()
    {
      if (!_aabbValid)
      {
        RenderableStateComponent renderable = _owner.GetComponent<RenderableStateComponent>(Actor.ActorStateRenderableComponentName);
        ShapeStateComponent shape = _owner.GetComponent<ShapeStateComponent>(Actor.ActorStateShapeComponentName);

        if (shape != null && shape.Shape != null)
        {
          _aabb = shape.Shape.BoundingBox;
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

    public IStateComponent Copy()
    {
      return new AABBStateComponent();
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
