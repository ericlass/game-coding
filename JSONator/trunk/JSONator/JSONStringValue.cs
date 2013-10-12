using System;

namespace JSONator
{
  public class JSONStringValue : JSONValue
  {
    public override JSONValueType ValueType
    {
      get { return JSONValueType.String; }
    }

    public string Value { get; set; }
  }
}
