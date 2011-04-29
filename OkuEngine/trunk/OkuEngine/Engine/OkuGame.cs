using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace OkuEngine
{
  /// <summary>
  /// Main game class that runs the whole game.
  /// </summary>
  public class OkuGame
  {
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
      HandleRef hRef = new HandleRef(OkuDrivers.Renderer.MainForm, OkuDrivers.Renderer.MainForm.Handle);

      while (true)
      {
        if (!OkuDrivers.Renderer.MainForm.Created)
          break;

        if (User32.PeekMessage(out msg, hRef, 0, 0, 1))
        {
          if (msg.msg == User32.WM_QUIT)
            break;
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

      OkuDrivers.Renderer.Finish();
      OkuDrivers.SoundEngine.Finish();
    }

    /// <summary>
    /// Initializes the configuration with their default values.
    /// </summary>
    private void InitDefaultConfig()
    {
      OkuData.Globals.Set<int>(OkuConstants.VarScreenWidth, 1024);
      OkuData.Globals.Set<int>(OkuConstants.VarScreenHeight, 768);
    }

    /// <summary>
    /// Loads the config file into the global variable cache.
    /// </summary>
    private void LoadConfigFile()
    {
      if (File.Exists(OkuConstants.ConfigFilename))
      {
        ConfigFile config = new ConfigFile();
        config.LoadFile(OkuConstants.ConfigFilename);
        if (config.Contains(OkuConstants.VarScreenWidth))
          OkuData.Globals.Set<int>(OkuConstants.VarScreenWidth, config.GetInt(OkuConstants.VarScreenWidth));
        if (config.Contains(OkuConstants.VarScreenHeight))
          OkuData.Globals.Set<int>(OkuConstants.VarScreenHeight, config.GetInt(OkuConstants.VarScreenHeight));
      }
    }

    /// <summary>
    /// Triggers the initialization of all engine parts.
    /// </summary>
    public void DoInitialize()
    {
      InitDefaultConfig();
      LoadConfigFile();
      
      OkuDrivers.Renderer = new OpenGLRenderer();
      OkuDrivers.Renderer.Initialize();

      OkuDrivers.SoundEngine = new OpenALSoundEngine();
      OkuDrivers.SoundEngine.Initialize();

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
      OkuData.Globals.Set<float>("oku.timedelta", dt);
      OkuDrivers.SoundEngine.Update(dt);
      OkuDrivers.Input.Update();

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
      OkuDrivers.Renderer.Begin();
      Render();
      OkuDrivers.Renderer.End();
    }

    /// <summary>
    /// Can be overriden to add custom rendering code. This method is called every
    /// frame just after the Update method.
    /// </summary>
    public virtual void Render()
    {
    }

    /// <summary>
    /// Checks if the given polygon is i the viewport. At the moment
    /// this is a simple boudning box test.
    /// </summary>
    /// <param name="shape">The shape to test for visibility.</param>
    /// <returns>True if the shape is visible, else False.</returns>
    private bool IsInViewPort(VectorList shape)
    {
      float left = float.MaxValue;
      float right = -float.MaxValue;
      float top = float.MaxValue;
      float bottom = -float.MaxValue;
      foreach (Vector vec in shape)
      {
        left = Math.Min(left, vec.X);
        right = Math.Max(right, vec.X);
        top = Math.Min(top, vec.Y);
        bottom = Math.Max(bottom, vec.Y);
      }

      return ((right >= 0) && (left < OkuData.Globals.Get<int>(OkuConstants.VarScreenWidth)) && (bottom >= 0) && (top < OkuData.Globals.Get<int>(OkuConstants.VarScreenHeight)));
    }

  }
}
