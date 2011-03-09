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
      Initialize();

      long tick1, tick2, freq;
      long perf1, perf2;
      Kernel32.QueryPerformanceFrequency(out freq);
      Kernel32.QueryPerformanceCounter(out tick1);
      Kernel32.QueryPerformanceCounter(out tick2);

      User32.NativeMessage msg = new User32.NativeMessage();
      HandleRef hRef = new HandleRef(OkuInterfaces.Renderer.MainForm, OkuInterfaces.Renderer.MainForm.Handle);

      while (true)
      {
        if (!OkuInterfaces.Renderer.MainForm.Created)
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
          Update(time);
          Kernel32.QueryPerformanceCounter(out perf2);
          float updateTime = (perf2 - perf1) / (float)freq;

          Kernel32.QueryPerformanceCounter(out perf1);
          Render();
          Kernel32.QueryPerformanceCounter(out perf2);
          float renderTime = (perf2 - perf1) / (float)freq;

          System.Diagnostics.Debug.WriteLine("Update: " + updateTime.ToString("0.######") + " | Render: " + renderTime.ToString("0.######"));
        }
      }

      OkuInterfaces.Renderer.Finish();
      OkuInterfaces.SoundEngine.Finish();
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
    public void Initialize()
    {
      InitDefaultConfig();
      LoadConfigFile();
      
      OkuInterfaces.Renderer = new OpenGLRenderer();
      OkuInterfaces.Renderer.Initialize();

      OkuInterfaces.SoundEngine = new OpenALSoundEngine();
      OkuInterfaces.SoundEngine.Initialize();

      SceneNodeList actionNodes = new SceneNodeList();
      
      foreach (SceneNode node in OkuData.Scene.Nodes)
      {
        if (node.HasAction())
          actionNodes.Add(node);
      }

      foreach (SceneNode node in actionNodes)
      {
        OkuData.Locals = node.ActionHandler.Locals;
        node.ActionHandler.OnAction(node, ActionType.Init);
      }
    }

    /// <summary>
    /// Triggers update of all engine parts and node actions every frame.
    /// </summary>
    /// <param name="dt"></param>
    public void Update(float dt)
    {
      OkuData.Globals.Set<float>("oku.timedelta", dt);

      SceneNodeList actionNodes = new SceneNodeList();

      foreach (SceneNode node in OkuData.Scene.Nodes)
      {
        if (node.HasAction())
          actionNodes.Add(node);
      }

      OkuInterfaces.Input.Update();
      foreach (SceneNode node in actionNodes)
      {
        OkuData.Locals = node.ActionHandler.Locals;
        node.ExecuteUpdateAction();
      }
    }

    private Stack<Matrix3> _matStack = new Stack<Matrix3>();
    private Matrix3 _worldMatrix = new Matrix3();

    /// <summary>
    /// Pushes the current world matrix onto the stack.
    /// </summary>
    private void pushMatrix()
    {
      _matStack.Push(_worldMatrix);
    }

    /// <summary>
    /// Pops the last matrix from the stack into the world matrix.
    /// </summary>
    private void popMatrix()
    {
      _worldMatrix = _matStack.Pop();
    }

    /// <summary>
    /// Trigger the rendering of the whole scene.
    /// </summary>
    public void Render()
    {
      OkuInterfaces.Renderer.Begin();
      _worldMatrix.LoadIdentity();

      Transformation cameraTransform = OkuData.Scene.Camera.Transform;
      _worldMatrix.Translate(cameraTransform.Translation * -1);
      _worldMatrix.Scale(-cameraTransform.Scale);
      _worldMatrix.Rotate(-cameraTransform.Rotation);

      RenderTree(OkuData.Scene.World);

      OkuInterfaces.Renderer.End();
    }

    /// <summary>
    /// Renders the scene graph starting at the given scene node. Typically
    /// this would be the world node.
    /// </summary>
    /// <param name="startNode">The node to start rendering at.</param>
    private void RenderTree(SceneNode startNode)
    {
      pushMatrix();

      _worldMatrix.ApplyTransform(startNode.Transform);
      startNode.WorldMatrix = _worldMatrix;

      if (startNode.Content != null && startNode.Content.Type == ContentType.Image)
      {
        Polygon transformed = ((ImageContent)(startNode.Content)).GetTransformedVertices(_worldMatrix);
        if (IsInViewPort(transformed))
          OkuInterfaces.Renderer.Draw(startNode);
      }

      if (startNode.HasChildren())
      {
        foreach (SceneNode child in startNode.Children)
          RenderTree(child);
      }

      popMatrix();
    }

    /// <summary>
    /// Checks if the given polygon is i the viewport. At the moment
    /// this is a simple boudning box test.
    /// </summary>
    /// <param name="shape">The shape to test for visibility.</param>
    /// <returns>True if the shape is visible, else False.</returns>
    private bool IsInViewPort(Polygon shape)
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
