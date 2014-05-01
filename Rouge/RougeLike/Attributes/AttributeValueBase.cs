using System;

namespace RougeLike.Attributes
{
  /// <summary>
  /// Defines the base for all attribute values.
  /// </summary>
  /// <typeparam name="T">The type of the value of the attribute.</typeparam>
  public abstract class AttributeValueBase<T> : IAttributeValue
  {
    protected T _value = default(T);

    /// <summary>
    /// Gets or sets the value of the attribute.
    /// </summary>
    public T Value
    {
      get { return _value; }
      set { _value = value; }
    }

    /// <summary>
    /// Gets the name of the type of the attribute.
    /// </summary>
    public abstract string TypeName { get; }

    /// <summary>
    /// Gets the value of the attribute as a string.
    /// </summary>
    /// <returns>The value as a string.</returns>
    public abstract string GetValueAsString();

    /// <summary>
    /// Set the value of the attribute by parsing the given string according to the type of attribute.
    /// </summary>
    /// <param name="str">The string containing the attribute value.</param>
    public abstract void SetValueFromString(string str);

    /// <summary>
    /// Converts the attribute value to a string in the format [type]"|"[value].
    /// </summary>
    /// <returns>The attribute value as a string.</returns>
    public string GetValueForSaving()
    {
      return TypeName + "|" + GetValueAsString();
    }

    public abstract int CompareTo(IAttributeValue other);

  }
}
