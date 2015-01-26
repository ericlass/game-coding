using System;

namespace JSONator
{
  /// <summary>
  /// Defines a JSON null value.
  /// </summary>
  public class JSONNull : JSONValue
  {
    /// <summary>
    /// Gets the type of the value.
    /// </summary>
    public override JSONValueType ValueType
    {
      get { return JSONValueType.Null; }
    }

    /// <summary>
    /// Creates a string representation of the null value.
    /// </summary>
    /// <returns>The string "null".</returns>
    public override string ToString()
    {
      return "null";
    }

  }
}
