﻿using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using OkuEngine.Driver.Audio;
using OkuEngine.Resources;
using OkuEngine.Processes;
using OkuEngine.Events;
using OkuEngine.Scripting;
using OkuEngine.Driver.Renderer;
using OkuEngine.Logging;
using OkuEngine.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
          else if (msg.msg == User32.WM_KEYDOWN)
          {
            if (OkuManagers.InputManager != null)
            {
              OkuManagers.InputManager.OnKeyAction((Keys)msg.wParam, KeyAction.Down);
            }
          }
          else if (msg.msg == User32.WM_KEYUP)
          {
            if (OkuManagers.InputManager != null)
            {
              OkuManagers.InputManager.OnKeyAction((Keys)msg.wParam, KeyAction.Up);
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
      KeySequence.Initialize();

      OkuManagers.Logger = new Logger();
      OkuManagers.Logger.AddWriter(new DebugConsoleLogWriter());

      OkuManagers.EventManager = new EventManager("OkuMainEventManager");

      OkuManagers.InputManager = new InputManager();

      OkuScriptManager scriptManager = new OkuScriptManager();
      scriptManager.Initialize();
      OkuManagers.ScriptManager = scriptManager;

      OkuManagers.ProcessManager = new ProcessManager();

      ResourceCacheParams resParams = new ResourceCacheParams();
      SetupResourceCache(ref resParams);
      ResourceCache resCache = new ResourceCache(resParams);
      OkuManagers.ResourceCache = resCache;
      if (resCache.Initialize())
      {
        ResourceHandle configHandle = resCache.GetHandle(new Resource(GetConfigFileName()));
        if (configHandle != null)
        {
          /*
          XmlDocument config = new XmlDocument();
          config.Load(configHandle.Buffer);

          XmlNode rootNode = config.DocumentElement;

          XmlNode engineNode = rootNode["engine"];
          XmlNode gameNode = rootNode["game"];

          XmlNode attribsNode = null;
          XmlNode imagesNode = null;
          XmlNode scenesNode = null;
          XmlNode actorTypesNode = null;
          XmlNode animationsNode = null;
          XmlNode inputBindingsNode = null;
          XmlNode userEventsNode = null;
          XmlNode behaviorsNode = null;
          XmlNode sceneObjectNode = null;

          if (gameNode != null)
          {
            attribsNode = gameNode["attributes"];
            imagesNode = gameNode["images"];
            scenesNode = gameNode["scenes"];
            actorTypesNode = gameNode["actortypes"];
            animationsNode = gameNode["animations"];
            inputBindingsNode = gameNode["keybindings"];
            userEventsNode = gameNode["userevents"];
            behaviorsNode = gameNode["behaviors"];
            sceneObjectNode = gameNode["sceneobjects"];
          }

          if (engineNode != null)
            LoadSettings(engineNode);

          if (userEventsNode != null)
            OkuData.Instance.UserEvents.Load(userEventsNode);

          if (inputBindingsNode != null)
            OkuManagers.InputManager.Load(inputBindingsNode);

          if (behaviorsNode != null)
            OkuData.Instance.Behaviors.Load(behaviorsNode);

          if (imagesNode != null)
            OkuData.Instance.Images.Load(imagesNode);

          if (animationsNode != null)
            OkuData.Instance.Animations.Load(animationsNode);

          if (actorTypesNode != null)
            OkuData.Instance.ActorTypes.Load(actorTypesNode);

          if (sceneObjectNode != null)
            OkuData.Instance.SceneObjects.Load(sceneObjectNode);
      
          if (scenesNode != null)
            OkuData.Instance.SceneManager.Load(scenesNode);

          if (attribsNode != null)
          {
            LoadGameAttribs(attribsNode);
            if (_startScene > 0)
              OkuData.Instance.SceneManager.SetActiveScene(_startScene);
            else
              OkuData.Instance.SceneManager.SetActiveScene(new OkuEngine.Scenes.Scene(-1, "Empty Scene"));
          }
          */

          StreamReader reader = new StreamReader(configHandle.Buffer);
          string configText = reader.ReadToEnd();
          reader.Close();

          long tick1, tick2, freq;
          Kernel32.QueryPerformanceFrequency(out freq);

          Kernel32.QueryPerformanceCounter(out tick1);
          OkuData.Instance = JsonConvert.DeserializeObject<OkuData>(configText, OkuData.JsonSettings);
          Kernel32.QueryPerformanceCounter(out tick2);

          float time = (tick2 - tick1) / (float)freq;
          OkuManagers.Logger.LogInfo("JSON deserialisation took: " + time + " seconds");

          if (!AfterLoad())
            return;

          Initialize();
        }
      }
      else
      {
        OkuManagers.Logger.LogError("Could not initialize resource cache!");
        System.Windows.Forms.Application.Exit();
      }
    }

    private bool AfterLoad()
    {
      IRenderer renderer = RendererFactory.Instance.CreateRenderer(OkuData.Instance.RenderSettings);
      if (renderer != null)
      {
        OkuManagers.Renderer = renderer;
        OkuManagers.EventManager.AddListener(EventTypes.ViewPortChanged, new EventListenerDelegate(OkuManagers.Renderer.OnViewportEvent));
      }
      else
        throw new OkuException("Could not create renderer!");

      ISoundEngine sound = SoundEngineFactory.Instance.CreateSoundEngine(OkuData.Instance.AudioSettings);
      if (sound != null)
        OkuManagers.SoundEngine = sound;
      else
        throw new OkuException("Could not create sound engine!");

      return OkuData.Instance.AfterLoad();
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
      OkuData.Instance.SceneManager.ActiveScene.Update(dt);

      //Update script engine (global timedelta value)
      OkuManagers.ScriptManager.Update(dt);

      //Update sound engine (does nothing atm)
      OkuManagers.SoundEngine.Update(dt);
      
      //Update input data
      OkuManagers.Input.Update();
      OkuManagers.Input.Mouse.WheelDelta = _mouseDelta / 120.0f;
      _mouseDelta = 0;

      // Update input manager (runs state behaviors)
      OkuManagers.InputManager.Update();
      
      //Process events
      OkuManagers.EventManager.Update(float.MaxValue);
      //Update processes (not used atm)
      OkuManagers.ProcessManager.UpdateProcesses(dt);

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
          OkuData.Instance.SceneManager.ActiveScene.Render();
          Render(i);
          OkuManagers.Renderer.End(i);
        }
      }
      else
      {
        OkuManagers.Renderer.Begin(0);
        OkuData.Instance.SceneManager.ActiveScene.Render();
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
