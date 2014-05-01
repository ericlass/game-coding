using System;

namespace RougeLike.Attributes
{
  /// <summary>
  /// Defines a single text attribute value.
  /// </summary>
  public class TextValue : AttributeValueBase<string>
  {
    /// <summary>
    /// Creates a new text value.
    /// </summary>
    public TextValue()
    {
    }

    /// <summary>
    /// Creates a new text value with the given value.
    /// </summary>
    /// <param name="value">The value of the new text value.</param>
    public TextValue(string value)
    {
      _value = value;
    }

    /// <summary>
    /// Gets the name of the attribute type.
    /// </summary>
    public override string TypeName
    {
      get { return "text"; }
    }

    /// <summary>
    /// Gets the value as a string.
    /// </summary>
    /// <returns>The value as a string.</returns>
    public override string GetValueAsString()
    {
      return _value;
    }

    /// <summary>
    /// Sets the value from a string.
    /// </summary>
    /// <param name="str">The string to parse.</param>
    public override void SetValueFromString(string str)
    {
      _value = str;
    }

    public override int CompareTo(IAttributeValue other)
    {
      if (other == null)
      {
        if (_value == null)
          return 0;
        else
          return 1;
      }

      if (!(other is TextValue))
        throw new OkuBase.OkuException("Cannot compare a text value to " + other.GetType().Name + "!");

      TextValue comp = other as TextValue;
      return _value.CompareTo(comp.Value);
    }
  }
}
