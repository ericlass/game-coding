using System;

namespace RougeLike.Attributes
{
  public interface IAttributeValue
  {
    string TypeName { get; }
    string GetValueAsString();
    void SetValueFromString(string str);
    string GetValueForSaving();

    /// <summary>
    /// Compares the attribute value to the other.
    /// Null is always less then any other value.
    /// </summary>
    /// <param name="other">The attribute value to compare to.</param>
    /// <returns>0 if the values equal, a positive value if this value is greater than the given or a negative value when this value is less than the given value.</returns>
    int CompareTo(IAttributeValue other);
  }
}
