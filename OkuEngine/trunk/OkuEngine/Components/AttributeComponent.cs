using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Attributes;

namespace OkuEngine.Components
{
  public class AttributeComponent : EntityComponent
  {
    public const int ComponentId = EntityComponentIds.ParameterId;
    public const string ComponentName = "attributes";

    private Dictionary<string, AttributeValue> _attributes = new Dictionary<string, AttributeValue>();

    public override int GetComponentId()
    {
      return ComponentId;
    }

    public override bool Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        AttributeValue value = new AttributeValue();
        if (value.Load(child))
        {
          if (!_attributes.ContainsKey(value.Name))
            _attributes.Add(value.Name, value);
          else
            OkuManagers.Logger.LogError("Attribute " + value.Name + " was specified twice! " + node.OuterXml);
        }

        child = child.NextSibling;
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      throw new NotImplementedException();
    }

  }
}
