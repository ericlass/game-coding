using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

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
    [JsonPropertyAttribute]
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    /// <summary>
    /// Gets the type of the attribute.
    /// </summary>
    [JsonPropertyAttribute]
    public AttributeType Type
    {
      get { return _type; }
      set { _type = value; }
    }

    /// <summary>
    /// Gets the raw value object.
    /// </summary>
    [JsonPropertyAttribute]
    public object RawValue
    {
      get { return _rawValue; }
      set { _rawValue = value; }
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

    public AttributeValue Copy()
    {
      AttributeValue result = new AttributeValue();
      result._name = _name;
      result._rawValue = _rawValue;
      result._type = _type;
      return result;
    }
    
    public bool AfterLoad()
    {
      return true;
    }

    public override string ToString()
    {
      return _rawValue == null ? "NULL" : _rawValue.ToString();
    }

  }
}
