using System.Runtime.InteropServices;
using System.Windows.Forms;
using OkuBase.Platform;
using OkuBase.Settings;
using OkuBase.Input;

namespace OkuBase
{
  /// <summary>
  /// Main game class that runs the whole game.
  /// </summary>
  public class OkuGame
  {
    private string _name = "OkuGame";
    private OkuManager _okuInstance = null;

    /// <summary>
    /// Creates a new game.
    /// </summary>
    public OkuGame()
    {
    }

    /// <summary>
    /// Gets or sets the name of the game.
    /// </summary>
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    /// <summary>
    /// Gets the oku library.
    /// </summary>
    public OkuManager Oku
    {
      get { return _okuInstance; }
    }

    /// <summary>
    /// Runs the game in an infinite loop.
    /// </summary>
    public void Run()
    {
      _okuInstance = OkuManager.Instance;

      OkuSettings settings = Configure();

      DoInitialize(settings);

      long tick1, tick2, freq;
      long perf1, perf2;
      Kernel32.QueryPerformanceFrequency(out freq);
      Kernel32.QueryPerformanceCounter(out tick1);
      Kernel32.QueryPerformanceCounter(out tick2);

      User32.NativeMessage msg = new User32.NativeMessage();
      HandleRef hRef = new HandleRef(OkuManager.Instance.Graphics.Driver.Display, OkuManager.Instance.Graphics.Driver.Display.Handle);

      bool running = true;
      while (running)
      {
        if (!OkuManager.Instance.Graphics.Driver.Display.Created)
          break;

        if (User32.PeekMessage(out msg, hRef, 0, 0, 1))
        {
          switch (msg.msg)
          {
            case User32.WM_QUIT:
              running = false;
              break;

            case User32.WM_MOUSEWHEEL:
              int mouseDelta = (int)(msg.wParam) >> 16;
              _okuInstance.Input.MouseWheel(mouseDelta);
              break;

            case User32.WM_KEYDOWN:
              _okuInstance.Input.KeyPressed((Keys)((int)msg.wParam));
              break;

            case User32.WM_KEYUP:
              _okuInstance.Input.KeyReleased((Keys)((int)msg.wParam));
              break;

            case User32.WM_LBUTTONDBLCLK:
              _okuInstance.Input.MouseDblClick(MouseButton.Left);
              break;

            case User32.WM_LBUTTONDOWN:
              _okuInstance.Input.MousePressed(MouseButton.Left);
              break;

            case User32.WM_LBUTTONUP:
              _okuInstance.Input.MouseReleased(MouseButton.Left);
              break;

            case User32.WM_RBUTTONDBLCLK:
              _okuInstance.Input.MouseDblClick(MouseButton.Right);
              break;

            case User32.WM_RBUTTONDOWN:
              _okuInstance.Input.MousePressed(MouseButton.Right);
              break;

            case User32.WM_RBUTTONUP:
              _okuInstance.Input.MouseReleased(MouseButton.Right);
              break;

            case User32.WM_MBUTTONDBLCLK:
              _okuInstance.Input.MouseDblClick(MouseButton.Middle);
              break;

            case User32.WM_MBUTTONDOWN:
              _okuInstance.Input.MousePressed(MouseButton.Middle);
              break;

            case User32.WM_MBUTTONUP:
              _okuInstance.Input.MouseReleased(MouseButton.Middle);
              break;

            case User32.WM_XBUTTONDBLCLK:
              uint xButton = (uint)(msg.wParam.ToInt32() >> 16 & 0x0000FFFF);
              if (xButton == 1)
                _okuInstance.Input.MouseDblClick(MouseButton.Fourth);
              else if (xButton == 2)
                _okuInstance.Input.MouseDblClick(MouseButton.Fifth);
              else
                throw new OkuException("Unsupported X Mouse Button: " + xButton);
              break;

            case User32.WM_XBUTTONDOWN:
              xButton = (uint)(msg.wParam.ToInt32() >> 16 & 0x0000FFFF);
              if (xButton == 1)
                _okuInstance.Input.MousePressed(MouseButton.Fourth);
              else if (xButton == 2)
                _okuInstance.Input.MousePressed(MouseButton.Fifth);
              else
                throw new OkuException("Unsupported X Mouse Button: " + xButton);
              break;

            case User32.WM_XBUTTONUP:
              xButton = (uint)(msg.wParam.ToInt32() >> 16 & 0x0000FFFF);
              if (xButton == 1)
                _okuInstance.Input.MouseReleased(MouseButton.Fourth);
              else if (xButton == 2)
                _okuInstance.Input.MouseReleased(MouseButton.Fifth);
              else
                throw new OkuException("Unsupported X Mouse Button: " + xButton);
              break;

            default:
              User32.TranslateMessage(ref msg);
              User32.DispatchMessage(ref msg);
              break;
          }
        }
        else
        {
          tick1 = tick2;
          Kernel32.QueryPerformanceCounter(out tick2);
          float time = (tick2 - tick1) / (float)freq;

          Kernel32.QueryPerformanceCounter(out perf1);
          DoUpdate(time);
          Kernel32.QueryPerformanceCounter(out perf2);
          float updateTime = (perf2 - perf1) / (float)freq;

          Kernel32.QueryPerformanceCounter(out perf1);
          DoRender();
          Kernel32.QueryPerformanceCounter(out perf2);
          float renderTime = (perf2 - perf1) / (float)freq;

          //System.Diagnostics.Debug.WriteLine("Update: " + updateTime.ToString("0.######") + " | Render: " + renderTime.ToString("0.######"));
        }
      }

      OkuManager.Instance.Finish();
    }

    public virtual OkuSettings Configure()
    {
      return new OkuSettings();
    }

    /// <summary>
    /// Triggers the initialization of all engine parts.
    /// </summary>
    public void DoInitialize(OkuSettings settings)
    {
      KeySequence.Initialize();
      OkuManager.Instance.Initialize(settings);
      Initialize();
    }

    /// <summary>
    /// Can be overriden to do custom initialization when the game starts.
    /// This is called after the renderer, sound engine and config file
    /// have been already initialized.
    /// </summary>
    public virtual void Initialize()
    {
    }

    /// <summary>
    /// Triggers update of all engine parts and node actions every frame.
    /// </summary>
    /// <param name="dt"></param>
    public void DoUpdate(float dt)
    {
      OkuManager.Instance.Update(dt);
      Update(dt);
    }

    /// <summary>
    /// Can be overriden to add custom update code. This method is
    /// called every frame and should be use to update the game scene.
    /// </summary>
    /// <param name="dt">The time since the last frame in fractional seconds.</param>
    public virtual void Update(float dt)
    {
    }

    /// <summary>
    /// Trigger the rendering of the whole scene.
    /// </summary>
    public void DoRender()
    {
      OkuManager.Instance.Graphics.Begin();
      Render();
      OkuManager.Instance.Graphics.End();
    }

    /// <summary>
    /// Can be overriden to add custom rendering code. This method is called every
    /// frame just after the Update method.
    /// </summary>
    public virtual void Render()
    {
    }

  }
}