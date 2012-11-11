﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Attributes
{
  /// <summary>
  /// Defines a single attribute value of a specific type.
  /// </summary>
  public class AttributeValue : IStoreable
  {
    private string _name = null;
    private AttributeType _type = AttributeType.Number;
    private object _rawValue = null;

    /// <summary>
    /// Creates a new attribute value with type Number.
    /// </summary>
    public AttributeValue()
    {
    }

    /// <summary>
    /// Gets the name of the attribute.
    /// </summary>
    public string Name
    {
      get { return _name; }
    }

    /// <summary>
    /// Gets the type of the attribute.
    /// </summary>
    public AttributeType Type
    {
      get { return _type; }
    }

    /// <summary>
    /// Gets the raw value object.
    /// </summary>
    public object RawValue
    {
      get { return _rawValue; }
    }

    /// <summary>
    /// Sets the raw value object.
    /// </summary>
    /// <param name="rawValue"></param>
    internal void SetRawValue(object rawValue)
    {
      _rawValue = rawValue;
    }

    /// <summary>
    /// Gets or sets the value as a boolean.
    /// </summary>
    public bool ValueBoolean
    {
      get { return (bool)_rawValue; }
      set { _rawValue = value; }
    }

    /// <summary>
    /// Gets or sets the value as an integer.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the value as a double.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the value as a string.
    /// </summary>
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
      else
      {
        OkuManagers.Logger.LogError("No name given for attribute! " + node.OuterXml);
        return false;
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
