using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using OkuEngine.Resources;
using OkuEngine.Input;
using Newtonsoft.Json;

namespace OkuEngine
{
  /// <summary>
  /// Main game class that runs the whole game.
  /// </summary>
  public class OkuGame
  {
    private int _mouseDelta = 0;
    private string _name = "OkuGame";

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
    /// Runs the game in an infinite loop.
    /// </summary>
    public void Run()
    {
      DoInitialize();

      long tick1, tick2, freq;
      long perf1, perf2;
      Kernel32.QueryPerformanceFrequency(out freq);
      Kernel32.QueryPerformanceCounter(out tick1);
      Kernel32.QueryPerformanceCounter(out tick2);

      User32.NativeMessage msg = new User32.NativeMessage();
      HandleRef hRef = new HandleRef(OkuDrivers.Instance.Renderer.Display, OkuDrivers.Instance.Renderer.Display.Handle);

      while (true)
      {
        if (!OkuDrivers.Instance.Renderer.Display.Created)
          break;

        if (User32.PeekMessage(out msg, hRef, 0, 0, 1))
        {
          if (msg.msg == User32.WM_QUIT)
          {
            break;
          }
          else if (msg.msg == User32.WM_MOUSEWHEEL)
          {
            _mouseDelta = (int)(msg.wParam) >> 16;
          }
          else if (msg.msg == User32.WM_KEYDOWN)
          {
            if (OkuManagers.Instance.InputManager != null)
            {
              OkuManagers.Instance.InputManager.OnKeyAction((Keys)msg.wParam, KeyAction.Down);
            }
          }
          else if (msg.msg == User32.WM_KEYUP)
          {
            if (OkuManagers.Instance.InputManager != null)
            {
              OkuManagers.Instance.InputManager.OnKeyAction((Keys)msg.wParam, KeyAction.Up);
            }
          }
          else
          {
            User32.TranslateMessage(ref msg);
            User32.DispatchMessage(ref msg);
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

      OkuDrivers.Instance.Renderer.Finish();
      OkuDrivers.Instance.SoundEngine.Finish();
    }

    /// <summary>
    /// Used to setup parameters for the resource cache.
    /// </summary>
    /// <param name="resourceParams">The parameters of the resource cache.</param>
    protected virtual void SetupResourceCache(ref ResourceCacheParams resourceParams)
    {
      resourceParams.ResourceFile = new FileSystemResourceFile();
      resourceParams.SizeInMb = 256;
    }

    /// <summary>
    /// Gets the name of the config file that is used to initializes the engine.
    /// </summary>
    /// <returns>The name of the config file. Can include path.</returns>
    protected virtual string GetConfigFileName()
    {
      return "okugame.xml";
    }

    /// <summary>
    /// Triggers the initialization of all engine parts.
    /// </summary>
    public void DoInitialize()
    {
      KeySequence.Initialize();

      // Scared that managers might not be initialized in the correct order
      OkuManagers.Instance.ToString();

      ResourceCacheParams resParams = new ResourceCacheParams();
      SetupResourceCache(ref resParams);
      ResourceCache resCache = new ResourceCache(resParams);
      OkuManagers.Instance.ResourceCache = resCache;
      if (resCache.Initialize())
      {
        ResourceHandle configHandle = resCache.GetHandle(new Resource(GetConfigFileName()));
        if (configHandle != null)
        {
          StreamReader reader = new StreamReader(configHandle.Buffer);
          string configText = reader.ReadToEnd();
          reader.Close();

          OkuData.Instance = JsonConvert.DeserializeObject<OkuData>(configText, OkuData.JsonSettings);

          if (!OkuDrivers.Instance.Initialize())
            return;
          
          if (!OkuData.Instance.AfterLoad())
            return;

          OkuManagers.Instance.InputManager.AfterLoad();

          // JSON Serialiazing for tests
          /*string json = JsonConvert.SerializeObject(OkuData.Instance, Formatting.Indented, OkuData.JsonSettings);
          Clipboard.SetText(json);*/

          //TODO: Remove
          Initialize();
        }
      }
      else
      {
        OkuManagers.Instance.Logger.LogError("Could not initialize resource cache!");
        System.Windows.Forms.Application.Exit();
      }
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
      //Update scene (previous transforms...)
      OkuData.Instance.Scenes.ActiveScene.Update(dt);

      //Update script engine (global timedelta value)
      OkuManagers.Instance.ScriptManager.Update(dt);

      //Update sound engine (does nothing atm)
      OkuDrivers.Instance.SoundEngine.Update(dt);
      
      //Update input data
      OkuManagers.Instance.Input.Update();
      OkuManagers.Instance.Input.Mouse.WheelDelta = _mouseDelta / 120.0f;
      _mouseDelta = 0;

      // Update input manager (runs state behaviors)
      OkuManagers.Instance.InputManager.Update();
      
      //Process events
      OkuManagers.Instance.EventManager.Update(float.MaxValue);
      //Update processes (not used atm)
      OkuManagers.Instance.ProcessManager.UpdateProcesses(dt);

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
      if (OkuDrivers.Instance.Renderer.RenderPasses > 0)
      {
        for (int i = 0; i < OkuDrivers.Instance.Renderer.RenderPasses; i++)
        {
          OkuDrivers.Instance.Renderer.Begin(i);
          OkuData.Instance.Scenes.ActiveScene.Render();
          Render(i);
          OkuDrivers.Instance.Renderer.End(i);
        }
      }
      else
      {
        OkuDrivers.Instance.Renderer.Begin(0);
        OkuData.Instance.Scenes.ActiveScene.Render();
        Render(0);
        OkuDrivers.Instance.Renderer.End(0);
      }
    }

    /// <summary>
    /// Can be overriden to add custom rendering code. This method is called every
    /// frame just after the Update method.
    /// </summary>
    public virtual void Render(int pass)
    {
    }

  }
}
