using System;

namespace RougeLike.Attributes
{
  /// <summary>
  /// Defines a single number attribute value.
  /// </summary>
  public class NumberValue : AttributeValueBase<float>
  {
    /// <summary>
    /// Creates a new number value.
    /// </summary>
    public NumberValue()
    {
    }

    /// <summary>
    /// Create a new number value with the given value.
    /// </summary>
    /// <param name="value">The value of the new number value.</param>
    public NumberValue(float value)
    {
      _value = value;
    }

    /// <summary>
    /// Gets the name of the attribute type.
    /// </summary>
    public override string TypeName
    {
      get { return "number"; }
    }

    /// <summary>
    /// Gets the value as a string.
    /// </summary>
    /// <returns>The value as a string.</returns>
    public override string GetValueAsString()
    {
      return OkuBase.Utils.Converter.FloatToString((float)_value);
    }

    /// <summary>
    /// Sets the value from a string.
    /// </summary>
    /// <param name="str">The string to parse.</param>
    public override void SetValueFromString(string str)
    {
      _value = OkuBase.Utils.Converter.StrToFloat(str);
    }

    public override int CompareTo(IAttributeValue other)
    {
      if (other == null)
        return 1;

      if (!(other is NumberValue))
        throw new OkuBase.OkuException("Cannot compare a number value to " + other.GetType().Name + "!");

      NumberValue comp = other as NumberValue;
      return _value.CompareTo(comp.Value);
    }
  }
}
