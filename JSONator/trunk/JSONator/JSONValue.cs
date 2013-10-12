using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONator
{
  public abstract class JSONValue
  {
    public abstract JSONValueType ValueType { get; }
  }
}
