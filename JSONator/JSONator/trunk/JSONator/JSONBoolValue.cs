using System;

namespace JSONator
{
  public class JSONBoolValue : JSONValue
  {
    public override JSONValueType ValueType
    {
      get { return JSONValueType.Bool; }
    }

    public bool Value { get; set; }
  }
}
