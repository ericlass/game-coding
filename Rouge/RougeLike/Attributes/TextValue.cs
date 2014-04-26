using System;

namespace RougeLike.Attributes
{
  public class TextValue : AttributeValueBase<string>
  {
    public TextValue()
    {
    }

    public TextValue(string value)
    {
      _value = value;
    }

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
