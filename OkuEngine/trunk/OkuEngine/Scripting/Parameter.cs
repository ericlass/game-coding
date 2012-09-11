using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Scripting
{
  public class Parameter : IStoreable
  {
    private string _name = null;
    private ParameterType _type = ParameterType.String;
    private object _value = null;
    private bool _input = true;

    public Parameter()
    {
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public ParameterType Type
    {
      get { return _type; }
      set { _type = value; }
    }

    public bool IsInput
    {
      get { return _input; }
      set { _input = value; }
    }

    public object RawValue
    {
      get { return _value; }
    }

    public bool ValueBoolean
    {
      get { return (bool)_value; }
      set { _value = value; }
    }

    public double ValueInteger
    {
      get
      {
        if (_value is Double)
          _value = (int)((Double)_value);
        return (int)_value;
      }
      set { _value = value; }
    }

    public double ValueDouble
    {
      get 
      {
        if (_value is Int32)
          _value = (double)((Int32)_value);
        return (double)_value; 
      }
      set { _value = value; }
    }

    public string ValueString
    {
      get 
      {
        if (!(_value is string))
          _value = _value.ToString();
        return (string)_value; 
      }
      set { _value = value; }
    }

    internal void SetValue(object value)
    {
      _value = value;
    }

    public bool Load(XmlNode node)
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
        _type = Converter.ParseEnum<ParameterType>(value);
      }
      else
      {
        OkuManagers.Logger.LogError("Parameter " + _name + " has no type! " + node.OuterXml);
        return false;
      }

      value = node.GetTagValue("input");
      if (value != null)
      {
        _input = Converter.StrToBool(value, _input);
      }

      _value = node.GetTagValue("value");      

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("parameter");

      writer.WriteValueTag("name", _name);
      writer.WriteValueTag("type", _type.ToString());
      writer.WriteValueTag("input", Converter.BoolToStr(_input));
      if (_value != null)
        writer.WriteValueTag("value", _value.ToString());

      writer.WriteEndElement();

      return true;
    }

    public override string ToString()
    {
      return _value.ToString();
    }

  }
}
