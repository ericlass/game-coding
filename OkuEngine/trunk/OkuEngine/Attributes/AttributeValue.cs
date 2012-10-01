using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Attributes
{
  public class AttributeValue : IStoreable
  {
    private int _attrId = 0;
    private object _rawValue = null;
    private IAttributeContainer _container = null;

    public AttributeValue(IAttributeContainer container)
    {
      _container = container;
    }

    public int AttributeId
    {
      get { return _attrId; }
      set { _attrId = value; }
    }

    public object RawValue
    {
      get { return _rawValue; }
    }

    public AttributeDefinition GetDefinition()
    {
      return _container.GetAttributeDefinition(_attrId);
    }

    internal void SetRawValue(object rawValue)
    {
      _rawValue = rawValue;
    }

    public bool ValueBoolean
    {
      get { return (bool)_rawValue; }
      set { _rawValue = value; }
    }

    public double ValueInteger
    {
      get
      {
        if (_rawValue is Double)
          _rawValue = (int)((Double)_rawValue);
        return (int)_rawValue;
      }
      set { _rawValue = value; }
    }

    public double ValueDouble
    {
      get 
      {
        if (_rawValue is Int32)
          _rawValue = (double)((Int32)_rawValue);
        return (double)_rawValue; 
      }
      set { _rawValue = value; }
    }

    public string ValueString
    {
      get 
      {
        if (!(_rawValue is string))
          _rawValue = _rawValue.ToString();
        return (string)_rawValue; 
      }
      set { _rawValue = value; }
    }

    public bool Load(XmlNode node)
    {
      _attrId = 0;
      string value = node.GetTagValue("id");
      if (value != null)
      {
        int id = 0;
        if (int.TryParse(value, out id))
          _attrId = id;
      }

      if (value == null || _attrId == 0)
      {
        OkuManagers.Logger.LogError("Attribute value does not specify a valid attribute id! " + node.OuterXml);
        return false;
      }

      AttributeDefinition attrDef = _container.GetAttributeDefinition(_attrId);

      if (attrDef == null)
      {
        OkuManagers.Logger.LogError("There is no attribute definition with the id " + _attrId + "! " + node.OuterXml);
        return false;
      }

      _rawValue = Converter.AttributeValueFromString(node.GetTagValue("value"), attrDef.Type);

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("attribute");

      writer.WriteValueTag("id", _attrId.ToString());
      writer.WriteValueTag("id", _attrId.ToString());

      writer.WriteEndElement();

      return true;
    }

    public override string ToString()
    {
      return _rawValue == null ? "NULL" : _rawValue.ToString();
    }

  }
}
