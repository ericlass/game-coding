using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.States;
using OkuEngine.Attributes;

namespace OkuEngine.Actors
{
  public class AttributeStateComponent : IStateComponent
  {
    private StateBase _owner = null;
    private AttributeMap _attributes = null;

    public StateBase Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public string ComponentName
    {
      get { return Actor.ActorStateAttributeComponentName; }
    }

    public AttributeMap Attributes
    {
      get { return _attributes; }
    }

    public IStateComponent Copy()
    {
      AttributeStateComponent result = new AttributeStateComponent();
      result._attributes = _attributes.Copy();
      return result;
    }

    public bool Load(XmlNode node)
    {
      _attributes = new AttributeMap();
      return _attributes.Load(node);
    }

    public bool Save(XmlWriter writer)
    {
      return _attributes.Save(writer);
    }

  }
}
