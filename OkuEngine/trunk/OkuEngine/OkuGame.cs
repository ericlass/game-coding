﻿using System;
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

    public void Render()
    {
      OkuInterfaces.Renderer.Begin();

      OkuInterfaces.Renderer.DrawTree(OkuData.Scene.World);

      OkuInterfaces.Renderer.End();
    }

  }
}
