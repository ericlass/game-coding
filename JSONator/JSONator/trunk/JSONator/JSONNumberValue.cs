using System;

namespace JSONator
{
  public class JSONNumberValue : JSONValue
  {
    public override JSONValueType ValueType
    {
      get { return JSONValueType.Number; }
    }

    public double Value { get; set; }
  }
}
