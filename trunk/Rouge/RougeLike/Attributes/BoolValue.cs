using System;

namespace RougeLike.Attributes
{
  /// <summary>
  /// Defines a single boolean attribute value
  /// </summary>
  public class BoolValue : AttributeValueBase<bool>
  {
    /// <summary>
    /// Creates new bool value.
    /// </summary>
    public BoolValue()
    {
    }

    /// <summary>
    /// Creates a new bool value with the given value.
    /// </summary>
    /// <param name="value">The value of the new bool value.</param>
    public BoolValue(bool value)
    {
      _value = value;
    }

    /// <summary>
    /// Gets the name of the attribute type.
    /// </summary>
    public override string TypeName
    {
      get { return "bool"; }
    }

    /// <summary>
    /// Gets the value as a string.
    /// </summary>
    /// <returns></returns>
    public override string GetValueAsString()
    {
      return OkuBase.Utils.Converter.BoolToStr(_value);
    }

    /// <summary>
    /// Sets the value from a string.
    /// </summary>
    /// <param name="str">The string to parse.</param>
    public override void SetValueFromString(string str)
    {
      _value = OkuBase.Utils.Converter.StrToBool(str, false);
    }

    public override int CompareTo(IAttributeValue other)
    {
      if (other == null)
        return 1;

      if (!(other is BoolValue))
        throw new OkuBase.OkuException("Cannot compare a boolen value to " + other.GetType().Name + "!");      
      
      BoolValue comp = other as BoolValue;
      return _value.CompareTo(comp.Value);
    }

  }
}
