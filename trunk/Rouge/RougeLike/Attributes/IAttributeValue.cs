using System;

namespace RougeLike.Attributes
{
  public interface IAttributeValue
  {
    string TypeName { get; }
    string GetValueAsString();
    void SetValueFromString(string str);
  }
}
