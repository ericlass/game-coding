using System;

namespace RougeLike.Attributes
{
  public class BoolValue : AttributeValueBase<bool>
  {
    public override string TypeName
    {
      get { return "bool"; }
    }

    public override string GetValueAsString()
    {
      return OkuBase.Utils.Converter.BoolToStr(_value);
    }

    public override void SetValueFromString(string str)
    {
      _value = OkuBase.Utils.Converter.StrToBool(str, false);
    }
  }
}
