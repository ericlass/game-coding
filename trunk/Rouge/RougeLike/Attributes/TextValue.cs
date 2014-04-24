using System;

namespace RougeLike.Attributes
{
  public class TextValue : AttributeValueBase<string>
  {
    public override string TypeName
    {
      get { return "text"; }
    }

    public override string GetValueAsString()
    {
      return _value;
    }

    public override void SetValueFromString(string str)
    {
      _value = str;
    }
  }
}
