using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Attributes
{
  public class AttributeMap : Dictionary<string, AttributeValue>, IStoreable
  {

    public AttributeMap()
    {
    }

    public AttributeMap(AttributeMap baseMap) : base(baseMap)
    {
    }

    public bool Add(AttributeValue param)
    {
      if (!this.ContainsKey(param.Definition.Name))
      {
        this.Add(param.Definition.Name, param);
        return true;
      }
      return false;
    }

    //TODO: The parameter component needs a definition list, not a value map!

    public bool Load(XmlNode node)
    {
      this.Clear();

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        if (child.NodeType == XmlNodeType.Element && child.Name.ToLower() == "parameter")
        {
          AttributeValue param = new AttributeValue();
          if (!param.Load(child))
          {
            OkuManagers.Logger.LogError("Parameter could not be loaded: " + child.OuterXml);
            return false;
          }
          if (!Add(param))
          {
            OkuManagers.Logger.LogError("Parameter with name " + param.Definition.Name + " was specified twice!");
            return false;
          }
        }

        child = child.NextSibling;
      }
      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("parameters");

      foreach (AttributeValue param in this.Values)
      {
        param.Save(writer);
      }

      writer.WriteEndElement();

      return true;
    }

  }
}
