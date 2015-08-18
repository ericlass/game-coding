using System;
using System.Runtime.InteropServices;

namespace InitGLWindow
{
  public static class WinApi
  {
    public const int IDC_ARROW = 32512;
    public const int IDI_APPLICATION = 32512;

    /* pixel types */
    public static byte PFD_TYPE_RGBA = 0;
    public static byte PFD_TYPE_COLORINDEX = 1;

    /* layer types */
    public static byte PFD_MAIN_PLANE = 0;
    public static byte PFD_OVERLAY_PLANE = 1;
    //public static uint PFD_UNDERLAY_PLANE = (-1);

    /* PIXELFORMATDESCRIPTOR flags */
    public static uint PFD_DOUBLEBUFFER = 0x00000001;
    public static uint PFD_STEREO = 0x00000002;
    public static uint PFD_DRAW_TO_WINDOW = 0x00000004;
    public static uint PFD_DRAW_TO_BITMAP = 0x00000008;
    public static uint PFD_SUPPORT_GDI = 0x00000010;
    public static uint PFD_SUPPORT_OPENGL = 0x00000020;
    public static uint PFD_GENERIC_FORMAT = 0x00000040;
    public static uint PFD_NEED_PALETTE = 0x00000080;
    public static uint PFD_NEED_SYSTEM_PALETTE = 0x00000100;
    public static uint PFD_SWAP_EXCHANGE = 0x00000200;
    public static uint PFD_SWAP_COPY = 0x00000400;
    public static uint PFD_SWAP_LAYER_BUFFERS = 0x00000800;
    public static uint PFD_GENERIC_ACCELERATED = 0x00001000;
    public static uint PFD_SUPPORT_DIRECTDRAW = 0x00002000;
    public static uint PFD_DIRECT3D_ACCELERATED = 0x00004000;
    public static uint PFD_SUPPORT_COMPOSITION = 0x00008000;

    /* PIXELFORMATDESCRIPTOR flags for use in ChoosePixelFormat only */
    public static uint PFD_DEPTH_DONTCARE = 0x20000000;
    public static uint PFD_DOUBLEBUFFER_DONTCARE = 0x40000000;
    public static uint PFD_STEREO_DONTCARE = 0x80000000;

    /// <summary>
    /// Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.
    /// </summary>
    /// <param name="lpwcx">
    ///   A pointer to a WNDCLASSEX structure. You must fill the structure
    ///   with the appropriate class attributes before passing it to the function.
    /// </param>
    /// <returns>
    ///   If the function succeeds, the return value is a class atom that uniquely
    ///   identifies the class being registered. This atom can only be used by the
    ///   CreateWindow, CreateWindowEx, GetClassInfo, GetClassInfoEx, FindWindow,
    ///   FindWindowEx, and UnregisterClass functions and the IActiveIMMap::FilterClientWindows method.
    ///   If the function fails, the return value is zero.To get extended error information, call GetLastError.
    /// </returns>
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.U2)]
    public static extern short RegisterClassEx([In] ref WndClassEx lpwcx);

    /// <summary>
    /// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the CreateWindow function.
    /// </summary>
    /// <param name="dwExStyle">The extended window style of the window being created.</param>
    /// <param name="lpClassName">A null-terminated string or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.</param>
    /// <param name="lpWindowName">The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title bar.</param>
    /// <param name="dwStyle">The style of the window being created.</param>
    /// <param name="x">The initial horizontal position of the window.</param>
    /// <param name="y">The initial vertical position of the window.</param>
    /// <param name="nWidth">The width, in device units, of the window.</param>
    /// <param name="nHeight">The height, in device units, of the window.</param>
    /// <param name="hWndParent">A handle to the parent or owner window of the window being created.</param>
    /// <param name="hMenu">A handle to a menu, or specifies a child-window identifier, depending on the window style.</param>
    /// <param name="hInstance">A handle to the instance of the module to be associated with the window.</param>
    /// <param name="lpParam">Pointer to a value to be passed to the window through the CREATESTRUCT structure (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message. This message is sent to the created window by this function before it returns.</param>
    /// <returns></returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr CreateWindowEx(
      WindowStylesEx dwExStyle,
      [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
      string lpClassName,
      [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
      string lpWindowName,
      WindowStyles dwStyle,
      int x,
      int y,
      int nWidth,
      int nHeight,
      IntPtr hWndParent,
      IntPtr hMenu,
      IntPtr hInstance,
      IntPtr lpParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern int UpdateWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadIcon(IntPtr hInst, string iconName);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadIcon(IntPtr hInst, int iconName);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadCursor(IntPtr hInstance, string lpCursorName);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

    [DllImport("user32.dll")]
    public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);    

    [DllImport("user32.dll")]
    public static extern bool GetMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

    [DllImport("user32.dll")]
    public static extern bool TranslateMessage([In] ref Msg lpMsg);

    [DllImport("user32.dll")]
    public static extern IntPtr DispatchMessage([In] ref Msg lpmsg);

    [DllImport("user32.dll")]
    public static extern void PostQuitMessage(int nExitCode);

    [DllImport("gdi32.dll")]
    public static extern int ChoosePixelFormat(IntPtr hdc, [In] ref PixelFormatDescriptor ppfd);

    [DllImport("gdi32.dll")]
    public static extern bool SetPixelFormat(IntPtr hdc, int iPixelFormat, ref PixelFormatDescriptor ppfd);

    [DllImport("gdi32.dll")]
    public static extern bool SwapBuffers(IntPtr hdc);

    [DllImport("Opengl32.dll")]
    public static extern IntPtr wglCreateContext(IntPtr hdc);

    [DllImport("Opengl32.dll")]
    public static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

    [DllImport("Opengl32.dll")]
    public static extern bool wglDeleteContext(IntPtr hglrc);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("gdi32.dll")]
    public static extern int DescribePixelFormat(IntPtr hdc, int iPixelFormat, uint nBytes, ref PixelFormatDescriptor ppfd);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

  }
}
