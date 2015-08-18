using System;
using System.Runtime.InteropServices;

namespace InitGLWindow
{
  /// <summary>
  /// The WNDCLASSEX structure contains window class information.
  /// It is used with the RegisterClassEx and GetClassInfoEx functions.
  /// The WNDCLASSEX structure is similar to the WNDCLASS structure.
  /// There are two differences. WNDCLASSEX includes the cbSize member,
  /// which specifies the size of the structure, and the hIconSm member,
  /// which contains a handle to a small icon associated with the window class.
  /// </summary>
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct WndClassEx
  {
    [MarshalAs(UnmanagedType.U4)]
    public int cbSize;
    [MarshalAs(UnmanagedType.U4)]
    public int style;
    public IntPtr lpfnWndProc;
    public int cbClsExtra;
    public int cbWndExtra;
    public IntPtr hInstance;
    public IntPtr hIcon;
    public IntPtr hCursor;
    public IntPtr hbrBackground;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
    public string lpszMenuName;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
    public string lpszClassName;
    public IntPtr hIconSm;

    /// <summary>
    /// Conveneience constructor that initializes the cbSize field.
    /// </summary>
    /// <returns>A new struct with the cbSize field already initialized.</returns>
    public static WndClassEx Build()
    {
      var nw = new WndClassEx();
      nw.cbSize = Marshal.SizeOf(typeof(WndClassEx));
      return nw;
    }
  }
}