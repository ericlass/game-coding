using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Internal sequence class that is used to generate content ids and 
  /// other artifical ids.
  /// </summary>
  static class KeySequence
  {
    public const int InvalidKey = -1;

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
