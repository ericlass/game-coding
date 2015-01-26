using System;

namespace JSONator
{
  /// <summary>
  /// Defines a JSON number value.
  /// </summary>
  public class JSONNumber : JSONValue
  {
    /// <summary>
    /// Creates a new number value with the given double value.
    /// </summary>
    /// <param name="value">The double value.</param>
    public JSONNumber(double value)
    {
      Value = value;
    }

    /// <summary>
    /// Gets the type of the value.
    /// </summary>
    public override JSONValueType ValueType
    {
      get { return JSONValueType.Number; }
    }

    /// <summary>
    /// Gets or sets the double value.
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// Converts the value to a string.
    /// </summary>
    /// <returns>The string representation of the value.</returns>
    public override string ToString()
    {
      return Value.ToString();
    }

  }
}
