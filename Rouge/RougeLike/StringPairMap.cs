using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class StringPairMap : Dictionary<string, string>
  {
    public void Merge(StringPairMap other)
    {
      foreach (var kv in other)
      {
        Add(kv.Key, kv.Value);
      }
    }
  }
}
