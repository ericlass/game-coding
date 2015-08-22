using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenGL;

namespace InitGLWindow
{
  /// <summary>
  /// Defines a simple window that is targeted at using OpenGL.
  /// </summary>
  public partial class OpenGLWindow
  {
    private static string ClassName = "MyGlWindow";

    private IntPtr _hInstance = IntPtr.Zero;
    private IntPtr _hwnd = IntPtr.Zero;
    private WndProc _wndProc = null;
    private IntPtr _rc = IntPtr.Zero;

    private HashSet<string> _extensions = null;    

    /// <summary>
    /// Private constructor with simple initializations.
    /// </summary>
    private OpenGLWindow()
    {
      _hInstance = Process.GetCurrentProcess().Handle;
      _wndProc = new WndProc(WndProc);
    }

    /// <summary>
    /// Creates and initializes the window.
    /// </summary>
    private void Initialize()
    {
      WndClassEx wcex = WndClassEx.Build();
      wcex.style = (int)(ClassStyles.HorizontalRedraw | ClassStyles.VerticalRedraw | ClassStyles.OwnDC);
      wcex.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndProc);
      wcex.cbClsExtra = 0;
      wcex.cbWndExtra = 0;
      wcex.hInstance = _hInstance;
      wcex.hIcon = WinApi.LoadIcon(_hInstance, WinApi.IDI_APPLICATION);
      wcex.hCursor = WinApi.LoadCursor(IntPtr.Zero, WinApi.IDC_ARROW);
      wcex.hbrBackground = IntPtr.Zero;
      wcex.lpszClassName = ClassName;
      wcex.lpszMenuName = null;

      wcex.hIconSm = WinApi.LoadIcon(_hInstance, WinApi.IDI_APPLICATION);

      short result = WinApi.RegisterClassEx(ref wcex);
      if (result == 0)
        throw new Exception("RegisterCallEx failed: " + Marshal.GetLastWin32Error());

      _hwnd = WinApi.CreateWindowEx(
        WindowStylesEx.WS_EX_NONE,
        ClassName,
        "My GL Window",
        WindowStyles.WS_OVERLAPPEDWINDOW,
        0,
        0,
        800,
        600,
        IntPtr.Zero,
        IntPtr.Zero,
        _hInstance,
        IntPtr.Zero
        );

      if (_hwnd == null || _hwnd == IntPtr.Zero)
        throw new Exception("CreateWindowEx failed: " + Marshal.GetLastWin32Error());
    }

    /// <summary>
    /// Loads available OpenGL extensions.
    /// </summary>
    /// <param name="major">The major version number of the current OpenGL implementation.</param>
    /// <param name="minor">The minor version number of the current OpenGL implementation.</param>
    private void loadExtensions(int major, int minor)
    {
      _extensions = new HashSet<string>();

      // Get GL extensions depending on GL version
      if (major < 3)
      {
        string extensionStr = Gl.GetString(StringName.Extensions);
        ParseExtensionString(extensionStr);
      }
      else
      {
        int extCount = 0;
        Gl.Get(Gl.NUM_EXTENSIONS, out extCount);
        for (uint i = 0; i < extCount; i++)
        {
          string ext = Gl.GetString(Gl.EXTENSIONS, i);
          _extensions.Add(ext);
          System.Diagnostics.Debug.WriteLine(ext);
        }
      }

      // Get WGL extensions
      string wglExtStr = Wgl.GetExtensionsStringARB(WinApi.GetDC(_hwnd));
      ParseExtensionString(wglExtStr);
    }

    /// <summary>
    /// Checks if the extensions with the given name is implemented.
    /// </summary>
    /// <param name="extName">The name of the extension.</param>
    /// <returns>True if the extension is supported, else false.</returns>
    public bool isExtSupported(string extName)
    {
      return _extensions.Contains(extName);
    }

    /// <summary>
    /// Parses a string of extensions. The extensions are expected to be separated by spaces.
    /// </summary>
    /// <param name="glExtStr">The full extension string that returned from OpenGL.</param>
    private void ParseExtensionString(string glExtStr)
    {
      foreach (string ext in glExtStr.Split(' '))
      {
        _extensions.Add(ext.Trim());
        System.Diagnostics.Debug.WriteLine(ext);
      }
    }

    /// <summary>
    /// Initializes OpenGL and starts the window message loop.
    /// </summary>
    /// <returns>The wParam value of the last message.</returns>
    public int Run()
    {
      WinApi.ShowWindow(_hwnd, ShowFlags.SW_SHOW);
      WinApi.UpdateWindow(_hwnd);

      CreateGlContext();

      Msg msg = new Msg();
      while (WinApi.GetMessage(out msg, IntPtr.Zero, 0, 0))
      {
        WinApi.TranslateMessage(ref msg);
        WinApi.DispatchMessage(ref msg);
      }

      return (int)msg.wParam;
    }

    /// <summary>
    /// Creates the OpenGL context. This is done differently depending on the OpenGL version.
    /// </summary>
    private void CreateGlContext()
    {
      Gl.GetString(0);

      PixelFormatDescriptor pfd = PixelFormatDescriptor.Build();
      pfd.nVersion = 1;
      pfd.dwFlags = WinApi.PFD_DOUBLEBUFFER | WinApi.PFD_SUPPORT_OPENGL | WinApi.PFD_DRAW_TO_WINDOW;
      pfd.iPixelType = WinApi.PFD_TYPE_RGBA;
      pfd.cColorBits = 32;
      pfd.cDepthBits = 32;
      pfd.cStencilBits = 8;
      pfd.iLayerType = WinApi.PFD_MAIN_PLANE;

      IntPtr dc = WinApi.GetDC(_hwnd);
      int pixelFormat = WinApi.ChoosePixelFormat(dc, ref pfd);

      if (pixelFormat == 0)
        throw new Exception("ChoosePixelFormat failed: " + Marshal.GetLastWin32Error());

      if (!WinApi.SetPixelFormat(dc, pixelFormat, ref pfd))
        throw new Exception("SetPixelFormat failed: " + Marshal.GetLastWin32Error());

      IntPtr tempRc = Wgl.CreateContext(dc);
      if (tempRc == IntPtr.Zero)
        throw new Exception("CreateContext failed: " + Marshal.GetLastWin32Error());

      Wgl.MakeCurrent(dc, tempRc);

      string versionStr = Gl.GetString(StringName.Version);
      System.Diagnostics.Debug.WriteLine(versionStr);
      int major = int.Parse(versionStr.Substring(0, 1));
      int minor = -1;
      if (major < 3)
      {
        minor = int.Parse(versionStr.Substring(2, 1));
      }
      else
      {
        Gl.Get(Gl.MAJOR_VERSION, out major);
        Gl.Get(Gl.MINOR_VERSION, out minor);
      }

      loadExtensions(major, minor);

      if (isExtSupported("WGL_ARB_create_context"))
      {
        int[] attribs = new int[]
        {
        Wgl.CONTEXT_MAJOR_VERSION_ARB, 4,
        Wgl.CONTEXT_MINOR_VERSION_ARB, 5,
        Wgl.CONTEXT_FLAGS_ARB, 0,
        0
        };

        _rc = Wgl.CreateContextAttribsARB(dc, IntPtr.Zero, attribs);
        Wgl.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
        Wgl.DeleteContext(tempRc);
        Wgl.MakeCurrent(dc, _rc);
      }
      else
        _rc = tempRc;
    }

  }
}
