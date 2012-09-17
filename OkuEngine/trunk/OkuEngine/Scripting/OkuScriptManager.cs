﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace OkuEngine.Scripting
{
  /// <summary>
  /// Provides special script manager function that only make sense in the game engine.
  /// </summary>
  public class OkuScriptManager : ScriptManager
  {
    /// <summary>
    /// Initializes the basic runtime environment for the scripts.
    /// Sets up classes and functions to be used by scripts.
    /// </summary>
    public void Initialize()
    {
      _engine.SetGlobalFunction("oku_getActorX", new Func<int, double>((actorId) => OkuData.Actors[actorId].SceneNode.Properties.Transform.Translation.X));
      _engine.SetGlobalFunction("oku_getActorY", new Func<int, double>((actorId) => OkuData.Actors[actorId].SceneNode.Properties.Transform.Translation.Y));

      _engine.SetGlobalFunction("oku_setActorX", new Action<int, double>((actorId, value) => OkuData.Actors[actorId].SceneNode.Properties.Transform.SetX((float)value)));
      _engine.SetGlobalFunction("oku_setActorY", new Action<int, double>((actorId, value) => OkuData.Actors[actorId].SceneNode.Properties.Transform.SetY((float)value)));

      _engine.SetGlobalFunction("oku_getActorAngle", new Func<int, double>((actorId) => OkuData.Actors[actorId].SceneNode.Properties.Transform.Rotation));
      _engine.SetGlobalFunction("oku_setActorAngle", new Action<int, double>((actorId, value) => OkuData.Actors[actorId].SceneNode.Properties.Transform.Rotation = (float)value));

      _engine.SetGlobalFunction("logMessage", new Action<string>((message) => OkuManagers.Logger.LogInfo(message)));

      StreamReader reader = new StreamReader(Assembly.GetAssembly(typeof(OkuScriptManager)).GetManifestResourceStream("OkuEngine.OkuRuntime.js"));
      string code = null;
      try
      {
        code = reader.ReadToEnd();
      }
      finally
      {
        reader.Close();
      }
      _engine.Execute(code);
    }

    public override void Update(float dt)
    {
      _engine.SetGlobalValue("timeDelta", (double)dt);
    }

  }
}
