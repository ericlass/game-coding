using System;

namespace JSONator
{
  public class JSONNullValue : JSONValue
  {
    public override JSONValueType ValueType
    {
      get { return JSONValueType.Null; }
    }
  }
}
