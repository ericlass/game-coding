using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using OkuEngine.Driver.Audio;
using OkuEngine.GCC.Actors;
using OkuEngine.GCC.Scene;
using OkuEngine.GCC.Resources;
using OkuEngine.GCC.Processes;
using OkuEngine.GCC.Events;
using OkuEngine.GCC.Scripting;
using OkuEngine.Driver.Renderer;
using OkuEngine.Logging;

namespace OkuEngine
{
  /// <summary>
  /// Main game class that runs the whole game.
  /// </summary>
  public class OkuGame
  {
    private int _mouseDelta = 0;
    private string _name = "OkuGame";
    private int _startScene = 0;

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
      return "okugame.xml";
    }

    /// <summary>
    /// Triggers the initialization of all engine parts.
    /// </summary>
    public void DoInitialize()
    {
      OkuManagers.Logger = new Logger();
      OkuManagers.Logger.AddWriter(new DebugConsoleLogWriter());

      OkuManagers.EventManager = new EventManager("OkuMainEventManager");
      OkuManagers.ScriptManager = new ScriptManager();
      OkuManagers.ProcessManager = new ProcessManager();

      ResourceCacheParams resParams = new ResourceCacheParams();
      SetupResourceCache(ref resParams);
      ResourceCache resCache = new ResourceCache(resParams);
      OkuData.ResourceCache = resCache;
      if (resCache.Initialize())
      {
        ResourceHandle configHandle = resCache.GetHandle(new Resource(GetConfigFileName()));
        if (configHandle != null)
        {
          //TODO: include xml validation
          XmlDocument config = new XmlDocument();
          config.Load(configHandle.Buffer);

          XmlNode engineNode = null;
          XmlNode attribsNode = null;
          XmlNode actorTypesNode = null;
          XmlNode scenesNode = null;
          XmlNode actorsNode = null;
          
          XmlNode rootNode = config.DocumentElement;
          XmlNode topNode = rootNode.FirstChild;

          while (topNode != null)
          {
            switch (topNode.Name.ToLower())
            {
              case "engine":
                engineNode = topNode;
                break;

              case "game":
                XmlNode gameNode = topNode.FirstChild;
                while (gameNode != null)
                {
                  switch (gameNode.Name.ToLower())
                  {
                    case "attributes":
                      attribsNode = gameNode;
                      break;

                    case "actortypes":
                      actorTypesNode = gameNode;
                      break;

                    case "scenes":
                      scenesNode = gameNode;
                      break;

                    case "actors":
                      actorsNode = gameNode;
                      break;

                    default:
                      break;
                  }

                  gameNode = gameNode.NextSibling;
                }
                break;

              default:
                break;
            }

            topNode = topNode.NextSibling;
          }

          if (engineNode != null)
            LoadSettings(engineNode);

          if (actorTypesNode != null)
            LoadActorTypes(actorTypesNode);

          if (scenesNode != null)
            LoadScenes(scenesNode);

          if (actorsNode != null)
            LoadActors(actorsNode);

          if (attribsNode != null)
          {
            LoadGameAttribs(attribsNode);
            if (_startScene > 0)
              OkuData.SceneManager.SetActiveScene(_startScene);
          }

          Initialize();
        }
      }
      else
      {
        OkuManagers.Logger.LogError("Could not initialize resource cache!");
        System.Windows.Forms.Application.Exit();
      }
    }

    /// <summary>
    /// Loads engine settings from the engine tag in the config XML.
    /// </summary>
    /// <param name="node">The "engine" node of the config XML.</param>
    private void LoadSettings(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "renderer":
            RendererFactory factory = new RendererFactory();
            IRenderer renderer = factory.CreateRenderer(child);
            if (renderer != null)
              OkuManagers.Renderer = renderer;
            else
              throw new OkuException("Could not create renderer \"" + child.ToString() + "\"!");
            break;

          case "sound":
            SoundEngineFactory soundFactory = new SoundEngineFactory();
            ISoundEngine sound = soundFactory.CreateSoundEngine(child);
            if (sound != null)
              OkuManagers.SoundEngine = sound;
            else
              throw new OkuException("Could not create sound engine \"" + child.ToString() + "\"!");
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      if (OkuManagers.Renderer != null)
      {
        OkuManagers.EventManager.AddListener(EventTypes.ViewPortChanged, new EventListenerDelegate(OkuManagers.Renderer.OnViewportEvent));
      }
    }

    /// <summary>
    /// Loads game attributes from the given xml node.
    /// </summary>
    /// <param name="node">The xml node to read from.</param>
    private void LoadGameAttribs(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "name":
            _name = child.FirstChild.Value;
            break;

          case "startscene":
            _startScene = int.Parse(child.FirstChild.Value);
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }
    }

    /// <summary>
    /// Loads the actor type from the given xml node.
    /// </summary>
    /// <param name="node">The xml node to read from.</param>
    private void LoadActorTypes(XmlNode node)
    {
      OkuData.ActorTypes.Load(node);
    }

    /// <summary>
    /// Loads the scenes from the given xml node.
    /// </summary>
    /// <param name="node">The xml node to read from.</param>
    private void LoadScenes(XmlNode node)
    {
      OkuData.SceneManager.Load(node);
    }

    /// <summary>
    /// Loads the actors from the given xml node.
    /// </summary>
    /// <param name="node">The xml node to read from.</param>
    private void LoadActors(XmlNode node)
    {
      OkuData.Actors.Load(node);
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
      OkuManagers.SoundEngine.Update(dt);
      OkuManagers.Input.Update();
      OkuManagers.Input.Mouse.WheelDelta = _mouseDelta / 120.0f;
      _mouseDelta = 0;

      OkuManagers.EventManager.Update(float.MaxValue);
      OkuManagers.ProcessManager.UpdateProcesses(dt);
      OkuData.SceneManager.ActiveScene.Update(dt);

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
          OkuData.SceneManager.ActiveScene.Render();
          Render(i);
          OkuManagers.Renderer.End(i);
        }
      }
      else
      {
        OkuManagers.Renderer.Begin(0);
        OkuData.SceneManager.ActiveScene.Render();
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
