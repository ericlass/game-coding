using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Attributes;

namespace OkuEngine.Actors.Components
{
  public class ParameterComponent : ActorComponent
  {
    public const int ComponentId = ActorComponentIds.ParameterId;
    public const string ComponentName = "parameters";

    private AttributeMap _parameters = new AttributeMap();

    public override int GetComponentId()
    {
      return ComponentId;
    }

    public override bool Load(XmlNode node)
    {
      return _parameters.Load(node);
    }

    public override bool Save(XmlWriter writer)
    {
      return _parameters.Save(writer);
    }

    public override ActorComponent Copy()
    {
      ParameterComponent result = new ParameterComponent();

      if (_parameters.Count > 0)
      {
        AttributeMap map = new AttributeMap();
        foreach (AttributeValue param in _parameters.Values)
        {
          AttributeValue copy = new AttributeValue();
          copy.Definition = param.Definition;
          copy.SetRawValue(param.Definition.GetValueCopy()); //Set value to default
          map.Add(param);
        }
        result._parameters = map;
      }

      return result;
    }

  }
}
