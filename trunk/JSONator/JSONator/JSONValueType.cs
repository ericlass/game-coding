using System;

namespace JSONator
{
  /// <summary>
  /// Defines the possible types of JSON values.
  /// </summary>
  public enum JSONValueType
  {
    /// <summary>
    /// Defines a null value.
    /// </summary>
    Null,
    /// <summary>
    /// Defines a boolean value with true and false.
    /// </summary>
    Bool,
    /// <summary>
    /// Defines a number value. Can be float or integer.
    /// </summary>
    Number,
    /// <summary>
    /// Defines a string value.
    /// </summary>
    String,
    /// <summary>
    /// Defines an object value.
    /// </summary>
    Object,
    /// <summary>
    /// Defines an array value.
    /// </summary>
    Array
  }
}
