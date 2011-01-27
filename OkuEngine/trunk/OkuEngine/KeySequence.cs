using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  static class KeySequence
  {
    private static int _currentValue = 0;

    public static int NextValue
    {
      get
      {
        _currentValue++;
        return _currentValue;
      }
    }

  }
}
