using System;

namespace JSONator
{
  /// <summary>
  /// Defines a JSON boolean value.
  /// </summary>
  public class JSONBoolValue : JSONValue
  {
    /// <summary>
    /// Creates a new JSON boolean value with the given boolean.
    /// </summary>
    /// <param name="value"></param>
    public JSONBoolValue(bool value)
    {
      Value = value;
    }

    /// <summary>
    /// Gets the type of the value.
    /// </summary>
    public override JSONValueType ValueType
    {
      get { return JSONValueType.Bool; }
    }

    /// <summary>
    /// Gets or sets the boolean value.
    /// </summary>
    public bool Value { get; set; }

    /// <summary>
    /// Creates a string representation of the boolean value.
    /// </summary>
    /// <returns>The boolean vaule as a string.</returns>
    public override string ToString()
    {
      return Value ? "true": "false";
    }

  }
}
