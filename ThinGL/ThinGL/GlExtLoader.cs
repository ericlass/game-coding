using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ThinGL
{
  public static partial class GlExt
  {
    private static Dictionary<string, Delegate> _delegates = new Dictionary<string, Delegate>();

    private static Delegate GetProc<T>()
    {
      string name = typeof(T).Name;
      Delegate result = null;
      if (!_delegates.ContainsKey(name))
      {
        IntPtr proc = Wgl.wglGetProcAddress(name);

        if (proc == null || proc == IntPtr.Zero)
          throw new InvalidOperationException(name + " is not available!");

        result = Marshal.GetDelegateForFunctionPointer(proc, typeof(T));

        _delegates.Add(name, result);
      }
      else
        result = _delegates[name];

      return result;
    }

    public static void ClearBufferData(uint target, uint internalformat, uint format, uint type, IntPtr data)
    {
      glClearBufferData del = (glClearBufferData)GetProc<glClearBufferData>();
      del(target, internalformat, format, type, data);
    }

  }
}
