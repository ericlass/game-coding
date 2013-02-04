using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.States;
using OkuEngine.Geometry;

namespace OkuEngine.Actors
{
  class ShapeStateComponent : IStateComponent
  {
    private StateBase _owner = null;
    private Polygon _shape = null;

    public StateBase Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public string ComponentName
    {
      get { return Actor.ActorStateShapeComponentName; }
    }

    public Polygon Shape
    {
      get { return _shape; }
    }

    public IStateComponent Copy()
    {
      ShapeStateComponent result = new ShapeStateComponent();
      result._shape = _shape.Copy();
      return result;
    }

    public bool Load(XmlNode node)
    {
      _shape = new Polygon();
      return _shape.Load(node);
    }

    public bool Save(XmlWriter writer)
    {
      return _shape.Save(writer);
    }

  }
}
