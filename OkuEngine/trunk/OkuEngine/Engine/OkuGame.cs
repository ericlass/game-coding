using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using OkuEngine.Driver.Audio;
using OkuEngine.GCC.Resources;
using OkuEngine.GCC.Processes;
using OkuEngine.GCC.Events;
using OkuEngine.GCC.Scripting;
using OkuEngine.Driver.Renderer;

namespace OkuEngine
{
  /// <summary>
  /// Main game class that runs the whole game.
  /// </summary>
  public class OkuGame
  {
    private int _mouseDelta = 0;

    /// <summary>
    /// Creates a new game.
    /// </summary>
    public OkuGame()
    {
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
      HandleRef hRef = new HandleRef(OkuManagers.Renderer.Display, OkuManagers.Renderer.Display.Handle);

      while (true)
      {
        if (!OkuManagers.Renderer.Display.Created)
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

          System.Diagnostics.Debug.WriteLine("Update: " + updateTime.ToString("0.######") + " | Render: " + renderTime.ToString("0.######"));
        }
      }

      OkuManagers.Renderer.Finish();
      OkuManagers.SoundEngine.Finish();
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
      return "okuconfig.xml";
    }

    /// <summary>
    /// Triggers the initialization of all engine parts.
    /// </summary>
    public void DoInitialize()
    {
      OkuManagers.ProcessManager = new ProcessManager();
      OkuManagers.ScriptManager = new ScriptManager();
      OkuManagers.EventManager = new EventManager("OkuMainEventManager");

      ResourceCacheParams resParams = new ResourceCacheParams();
      SetupResourceCache(ref resParams);

      ResourceCache resCache = new ResourceCache(resParams);
      OkuManagers.ResourceCache = resCache;
      if (resCache.Initialize())
      {
        ResourceHandle configHandle = resCache.GetHandle(new Resource(GetConfigFileName()));
        if (configHandle != null)
        {
          //TODO: include xml validation
          XmlDocument config = new XmlDocument();
          config.Load(configHandle.Buffer);

          XmlNode configNode = config.DocumentElement;
          XmlNode managerNode = configNode.FirstChild;
          while (managerNode != null)
          {
            switch (managerNode.Name)
            {
              case "renderer":                
                RendererFactory factory = new RendererFactory();
                IRenderer renderer = factory.CreateRenderer(managerNode);
                if (renderer != null)
                  OkuManagers.Renderer = renderer;
                else
                  throw new OkuException("Could not create renderer \"" + managerNode.ToString() + "\"!");
                break;

              case "sound":
                SoundEngineFactory soundFactory = new SoundEngineFactory();
                ISoundEngine sound = soundFactory.CreateSoundEngine(managerNode);
                if (sound != null)
                  OkuManagers.SoundEngine = sound;
                else
                  throw new OkuException("Could not create sound engine \"" + managerNode.ToString() + "\"!");
                break;

              default:
                break;
            }

            managerNode = managerNode.NextSibling;
          }

          Initialize();
        }
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
      OkuData.Globals.Set<float>("oku.timedelta", dt);
      OkuManagers.SoundEngine.Update(dt);
      OkuManagers.Input.Update();
      OkuManagers.Input.Mouse.WheelDelta = _mouseDelta / 120.0f;
      _mouseDelta = 0;

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
      if (OkuManagers.Renderer.RenderPasses > 0)
      {
        for (int i = 0; i < OkuManagers.Renderer.RenderPasses; i++)
        {
          OkuManagers.Renderer.Begin(i);
          Render(i);
          OkuManagers.Renderer.End(i);
        }
      }
      else
      {
        OkuManagers.Renderer.Begin(0);
        Render(0);
        OkuManagers.Renderer.End(0);
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
