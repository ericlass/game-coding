using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Attributes
{
  public class AttributeDefinition : IStoreable
  {
    private string _name = null;
    private AttributeType _type = AttributeType.Integer;
    private object _defaultValue = null;

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public AttributeType Type
    {
      get { return _type; }
      set { _type = value; }
    }

    public object DefaultValue
    {
      get { return _defaultValue; }
      set { _defaultValue = value; }
    }

    public bool Load(System.Xml.XmlNode node)
    {
      _name = node.GetTagValue("name");

      if (_name == null)
      {
        OkuManagers.Logger.LogError("Parameter has no name! " + node.OuterXml);
        return false;
      }

      string value = node.GetTagValue("type");
      if (value != null)
      {
        _type = Converter.ParseEnum<AttributeType>(value);
      }
      else
      {
        OkuManagers.Logger.LogError("Parameter " + _name + " has no type! " + node.OuterXml);
        return false;
      }

      _defaultValue = ValueFromString(node.GetTagValue("value"));

      return true;
    }

    public bool Save(System.Xml.XmlWriter writer)
    {
      writer.WriteStartElement("parameter");

      writer.WriteValueTag("name", _name);
      writer.WriteValueTag("type", _type.ToString());
      if (_defaultValue != null)
        writer.WriteValueTag("default", _defaultValue.ToString());

      writer.WriteEndElement();

      return true;
    }

    internal object GetValueCopy()
    {
      switch (_type)
      {
        case AttributeType.Boolean:
          return _defaultValue;

        case AttributeType.Integer:
          return _defaultValue;

        case AttributeType.Number:
          return _defaultValue;

        case AttributeType.String:
          string strVal = _defaultValue as string;
          return String.Copy(strVal);

        default:
          throw new NotImplementedException("Cannot copy value of type " + _type.ToString() + "!");
      }
    }

    private object ValueFromString(string value)
    {
      if (value == null)
        return null;

      switch (_type)
      {
        case AttributeType.Boolean:
          return Converter.StrToBool(value, false);

        case AttributeType.Integer:
          int test = 0;
          if (int.TryParse(value, out test))
            return test;
          else
            return 0;

        case AttributeType.Number:
          double testd = 0;
          if (double.TryParse(value, out testd))
            return testd;
          else
            return 0.0;

        case AttributeType.String:
          return value;

        default:
          throw new NotImplementedException("Don't know how to parse parameter type " + _type.ToString() + "!");
      }
    }

  }
}
