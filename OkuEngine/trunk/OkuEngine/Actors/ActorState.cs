using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Attributes;

namespace OkuEngine.Actors
{
  public class ActorState : IStoreable
  {
    private string _name = null;
    private InheritingDictionary<string, AttributeValue> _attributes = null;
    private InheritingRenderable _renderable = null;

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public InheritingDictionary<string, AttributeValue> Attributes
    {
      get { return _attributes; }
    }

    public InheritingRenderable Renderable
    {
      get { return _renderable; }
    }

    public bool Load(XmlNode node)
    {
      throw new NotImplementedException();
    }

    public bool Save(XmlWriter writer)
    {
      throw new NotImplementedException();
    }

  }
}
