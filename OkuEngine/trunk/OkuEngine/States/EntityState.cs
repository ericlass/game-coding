using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Attributes;

namespace OkuEngine.States
{
  public abstract class EntityState : IStoreable
  {
    private string _name = null;
    private AttributeMap _attributes = null;

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public AttributeMap Attributes
    {
      get { return _attributes; }
    }

    public virtual bool Load(XmlNode node)
    {
      _name = node.GetTagValue("name");

      if (_name == null)
      {
        OkuManagers.Logger.LogError("State without name detected at " + node.OuterXml);
        return false;
      }

      XmlNode attrNode = node["attributes"];
      if (attrNode != null)
      {
        if (_attributes == null)
          _attributes = new AttributeMap();

        if (!_attributes.Load(attrNode))
          return false;
      }

      return true;
    }

    public virtual bool Save(XmlWriter writer)
    {
      writer.WriteValueTag("name", _name);

      if (_attributes != null && !_attributes.Save(writer))
          return false;

      return true;
    }

  }
}
