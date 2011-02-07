using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace OkuEngine
{
  /// <summary>
  /// Main game class that runs the whole game.
  /// +++ NOT FULLY APPROVED FOR OKU GEN-2 +++
  /// May need some modification for Oku Gen2
  /// </summary>
  public class OkuGame
  {

    public OkuGame()
    {
    }

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

    public void Initialize()
    {
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
    private Polygon _transformed = new Polygon();

    private void pushMatrix()
    {
      _matStack.Push(_worldMatrix);
    }

    private void popMatrix()
    {
      _worldMatrix = _matStack.Pop();
    }

    public void Render()
    {
      OkuInterfaces.Renderer.Begin();
      _worldMatrix.LoadIdentity();

      Transformation cameraTransform = OkuData.Scene.Camera.Transform;
      _worldMatrix.Translate(cameraTransform.Translation * -1);
      _worldMatrix.Scale(cameraTransform.Scale);
      _worldMatrix.Rotate(-cameraTransform.Rotation);

      RenderTree(OkuData.Scene.World);

      OkuInterfaces.Renderer.End();
    }

    private void RenderTree(SceneNode startNode)
    {
      pushMatrix();

      _worldMatrix.Translate(startNode.Transform.Translation);
      _worldMatrix.Scale(startNode.Transform.Scale);
      _worldMatrix.Rotate(startNode.Transform.Rotation);

      if (startNode.Content != null && startNode.Content.Type == ContentType.Image)
      {
        ImageContent content = (ImageContent)startNode.Content;
        _worldMatrix.Transform(content.Vertices, _transformed);
        if (IsInViewPort(_transformed))
          OkuInterfaces.Renderer.Draw(content, _transformed);
      }

      if (startNode.HasChildren())
      {
        foreach (SceneNode child in startNode.Children)
          RenderTree(child);
      }

      popMatrix();
    }

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

      return ((right >= 0) && (left < OkuInterfaces.Renderer.ScreenWidth) && (bottom >= 0) && (top < OkuInterfaces.Renderer.ScreenHeight));
    }

  }
}
