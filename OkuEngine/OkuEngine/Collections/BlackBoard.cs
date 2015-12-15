using System;
using System.Collections.Generic;

namespace OkuEngine.Collections
{
  public class BlackBoard : Dictionary<string, object>
  {
    public new object this[string name]
    {
      get
      {
        if (this.ContainsKey(name))
          return base[name];

        return null;
      }
      set
      {
        base[name] = value;
      }
    }

  }
}
