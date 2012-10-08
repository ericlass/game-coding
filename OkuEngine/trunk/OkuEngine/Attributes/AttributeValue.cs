using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Attributes
{
  public class AttributeValue : IStoreable
  {
    private string _name = null;
    private AttributeType _type = AttributeType.Number;
    private object _rawValue = null;

    public AttributeValue()
    {
    }

    public string Name
    {
      get { return _name; }
    }

    public AttributeType Type
    {
      get { return _type; }
    }

    public object RawValue
    {
      get { return _rawValue; }
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
      _name = node.GetTagValue("name");
      if (_name != null)
      {
        _name = _name.Trim().ToLower();
      }

      _type = Converter.ParseEnum<AttributeType>(node.GetTagValue("type"));
      _rawValue = Converter.AttributeValueFromString(node.GetTagValue("value"), _type);

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("attribute");

      writer.WriteValueTag("name", _name);
      writer.WriteValueTag("type", _type.ToString());
      writer.WriteValueTag("value", Converter.ValueToString(this));

      writer.WriteEndElement();

      return true;
    }

    public override string ToString()
    {
      return _rawValue == null ? "NULL" : _rawValue.ToString();
    }

  }
}
