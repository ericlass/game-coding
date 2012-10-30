using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Attributes
{
  public class AttributeMap : InheritingDictionary<string, AttributeValue>, IStoreable
  {
    public bool Add(AttributeValue value)
    {
      if (!ContainsKey(value.Name.ToLower()))
      {
        Add(value.Name.ToLower(), value);
        return true;
      }
      return false;
    }

    public bool Load(XmlNode node)
    {
      Clear();
      if (node.NodeType == XmlNodeType.Element && node.Name.ToLower() == "attributes")
      {
        XmlNode child = node.FirstChild;
        while (child != null)
        {
          if (child.NodeType == XmlNodeType.Element && child.Name.ToLower() == "attribute")
          {
            AttributeValue value = new AttributeValue();
            if (!value.Load(child))
              return false;
            if (!Add(value))
            {
              OkuManagers.Logger.LogError("Trying to add attribute " + value.Name + " twice! " + node.OuterXml);
              return false;
            }
          }
          child = child.NextSibling;
        }
      }
      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("attributes");

      foreach (AttributeValue value in Values)
      {
        if (!value.Save(writer))
          return false;
      }

      writer.WriteEndElement();

      return true;
    }

  }
}
