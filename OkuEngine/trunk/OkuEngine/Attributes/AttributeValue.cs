using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Attributes
{
  public class AttributeValue : IStoreable
  {
    private AttributeDefinition _definition = null;
    private object _rawValue = null;

    public AttributeValue()
    {
    }

    public AttributeDefinition Definition
    {
      get { return _definition; }
      set { _definition = value; }
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
      throw new NotImplementedException();
    }

    internal object GetValueCopy()
    {
      switch (_definition.Type)
      {
        case AttributeType.Boolean:
          return _rawValue;

        case AttributeType.Integer:
          return _rawValue;

        case AttributeType.Number:
          return _rawValue;

        case AttributeType.String:
          string strVal = _rawValue as string;
          return String.Copy(strVal);

        default:
          throw new NotImplementedException("Cannot copy value of type " + _definition.Type.ToString() + "!");
      }
    }

    public bool Save(XmlWriter writer)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      return _rawValue.ToString();
    }

  }
}
