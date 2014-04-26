using System;

namespace RougeLike.Attributes
{
  public abstract class AttributeValueBase<T> : IAttributeValue
  {
    protected T _value = default(T);

    public T Value
    {
      get { return _value; }
      set { _value = value; }
    }

    public abstract string TypeName { get; }

    public abstract string GetValueAsString();
    public abstract void SetValueFromString(string str);


    public string GetValueForSaving()
    {
      return TypeName + "|" + GetValueAsString();
    }

  }
}
