﻿using System;

namespace RougeLike.Attributes
{
  public class NumberValue : AttributeValueBase<double>
  {
    public override string TypeName
    {
      get { return "number"; }
    }

    public override string GetValueAsString()
    {
      return OkuBase.Utils.Converter.FloatToString((float)_value);
    }

    public override void SetValueFromString(string str)
    {
      _value = OkuBase.Utils.Converter.StrToFloat(str);
    }
  }
}
