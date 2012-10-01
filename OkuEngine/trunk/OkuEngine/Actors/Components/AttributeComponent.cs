using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Attributes;

namespace OkuEngine.Actors.Components
{
  public class AttributeComponent : ActorComponent
  {
    public const int ComponentId = ActorComponentIds.ParameterId;
    public const string ComponentName = "attributes";

    private List<AttributeDefinition> _attrDefinitions = null;

    public override int GetComponentId()
    {
      return ComponentId;
    }

    public override bool Load(XmlNode node)
    {
      throw new NotImplementedException();
    }

    public override bool Save(XmlWriter writer)
    {
      throw new NotImplementedException();
    }

    public override ActorComponent Copy()
    {
      throw new NotImplementedException();
    }

  }
}
