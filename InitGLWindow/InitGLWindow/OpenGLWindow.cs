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
    public delegate void UpdateDelegate(float dt);
    public delegate void RenderDelegate();
    

    private string _wndClassName = null;
    private IntPtr _hInstance = IntPtr.Zero;
    private IntPtr _hwnd = IntPtr.Zero;
    private WndProc _wndProc = null;
    private IntPtr _rc = IntPtr.Zero;
    private bool _running = false;

    private long _tickFrequency = 0;
    private long _lastTick = 0;

    private HashSet<string> _extensions = null;

    public event RenderDelegate OnRender;
    public event UpdateDelegate OnUpdate;

    /// <summary>
    /// Private constructor with simple initializations.
    /// </summary>
    private OpenGLWindow(string wndClassName)
    {
      _wndClassName = wndClassName;
      _hInstance = Process.GetCurrentProcess().Handle;
      _wndProc = new WndProc(WndProc);
    }

    /// <summary>
    /// Creates and initializes the window.
    /// </summary>
    private void Initialize()
    {
      //Fill WndClassEx struct
      WndClassEx wcex = WndClassEx.Build();
      wcex.style = (int)(ClassStyles.HorizontalRedraw | ClassStyles.VerticalRedraw | ClassStyles.OwnDC);
      wcex.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndProc);
      wcex.cbClsExtra = 0;
      wcex.cbWndExtra = 0;
      wcex.hInstance = _hInstance;
      wcex.hIcon = WinApi.LoadIcon(_hInstance, WinApi.IDI_APPLICATION);
      wcex.hCursor = WinApi.LoadCursor(IntPtr.Zero, WinApi.IDC_ARROW);
      wcex.hbrBackground = IntPtr.Zero;
      wcex.lpszClassName = _wndClassName;
      wcex.lpszMenuName = null;
      wcex.hIconSm = WinApi.LoadIcon(_hInstance, WinApi.IDI_APPLICATION);

      //Register window class
      short result = WinApi.RegisterClassEx(ref wcex);
      if (result == 0)
        throw new Exception("RegisterCallEx failed: " + Marshal.GetLastWin32Error());

      //Create window
      _hwnd = WinApi.CreateWindowEx(
        WindowStylesEx.WS_EX_NONE,
        _wndClassName,
        "OpenGLWindow",
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

      //Check if window creation was successful
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

      WinApi.QueryPerformanceFrequency(out _tickFrequency);
      WinApi.QueryPerformanceCounter(out _lastTick);

      IntPtr dc = WinApi.GetDC(_hwnd);

      Msg msg = new Msg();
      _running = true;
      while (_running)
      {
        //Process window messages first
        if (WinApi.PeekMessage(out msg, _hwnd, 0, 0, 1))
        {
          switch (msg.message)
          {
            default:
              WinApi.TranslateMessage(ref msg);
              WinApi.DispatchMessage(ref msg);
              break;
          }
        }
        else
        {
          //If no window message need to be processed, do update and render
          long tick;
          WinApi.QueryPerformanceCounter(out tick);
          float time = (tick - _lastTick) / (float)_tickFrequency;
          _lastTick = tick;

          if (OnUpdate != null)
            OnUpdate(time);

          if (OnRender != null)
          {
            OnRender();
            WinApi.SwapBuffers(dc);
          }
        }
      }

      return (int)msg.wParam;
    }

    /// <summary>
    /// Creates the OpenGL context. This is done differently depending on the OpenGL version.
    /// </summary>
    private void CreateGlContext()
    {
      // Find matching pixel format
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

      //Set the new pixel format
      if (!WinApi.SetPixelFormat(dc, pixelFormat, ref pfd))
        throw new Exception("SetPixelFormat failed: " + Marshal.GetLastWin32Error());

      //Create temporary GL context
      IntPtr tempRc = Wgl.CreateContext(dc);
      if (tempRc == IntPtr.Zero)
        throw new Exception("CreateContext failed: " + Marshal.GetLastWin32Error());

      Wgl.MakeCurrent(dc, tempRc);

      //Get Gl version the old way first
      string versionStr = Gl.GetString(StringName.Version);
      System.Diagnostics.Debug.WriteLine(versionStr);

      int major = int.Parse(versionStr.Substring(0, 1));
      int minor = -1;
      if (major < 3)
      {
        //For verions before 3, we have to stick to the version string
        minor = int.Parse(versionStr.Substring(2, 1));
      }
      else
      {
        //For verions 3+, we can use the new functions to get major and minor version
        Gl.Get(Gl.MAJOR_VERSION, out major);
        Gl.Get(Gl.MINOR_VERSION, out minor);
      }

      // Now is the time to load extensions
      loadExtensions(major, minor);

      if (isExtSupported("WGL_ARB_create_context"))
      {
        //If the new context creation scheme is available, use it to create a new context with a specific version
        int[] attribs = new int[]
        {
        Wgl.CONTEXT_MAJOR_VERSION_ARB, 4,
        Wgl.CONTEXT_MINOR_VERSION_ARB, 5,
        Wgl.CONTEXT_FLAGS_ARB, 0,
        Wgl.CONTEXT_PROFILE_MASK_ARB, (int)Wgl.CONTEXT_CORE_PROFILE_BIT_ARB,
        0
        };

        _rc = Wgl.CreateContextAttribsARB(dc, IntPtr.Zero, attribs);
        Wgl.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
        Wgl.DeleteContext(tempRc);
        Wgl.MakeCurrent(dc, _rc);
      }
      else
        //If new context creation is not supported, simply use the existing context
        _rc = tempRc;
    }

    /// <summary>
    /// This is the absolute default window proc function. You should call it whenever you do not handle a message yourself.
    /// </summary>
    /// <param name="hWnd">The handle of the window.</param>
    /// <param name="msg">The message.</param>
    /// <param name="wParam">The wParam.</param>
    /// <param name="lParam">The lParam.</param>
    /// <returns>A value depending on how the message was processed.</returns>
    private IntPtr InstanceWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
    {
      switch (msg)
      {
        case WinMessages.DESTROY:
          _running = false;
          WinApi.PostQuitMessage(0);
          break;

        default:
          return WinApi.DefWindowProc(hWnd, msg, wParam, lParam);
      }

      return IntPtr.Zero;
    }

  }
}
