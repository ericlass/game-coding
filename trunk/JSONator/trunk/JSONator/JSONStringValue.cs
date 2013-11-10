using System;

namespace JSONator
{
  /// <summary>
  /// Defines a JSON string value.
  /// </summary>
  public class JSONStringValue : JSONValue
  {
    /// <summary>
    /// Creates a new value with the given string.
    /// </summary>
    /// <param name="value">The string value.</param>
    public JSONStringValue(string value)
    {
      Value = value;
    }

    /// <summary>
    /// Gets the type of the value.
    /// </summary>
    public override JSONValueType ValueType
    {
      get { return JSONValueType.String; }
    }

    /// <summary>
    /// Gets or sets the string value.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Converts the string value to a string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return Value;
    }

  }
}
