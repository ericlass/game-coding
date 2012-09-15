using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Scripting
{
  /// <summary>
  /// Provides special script manager function that only make sense in the game engine.
  /// </summary>
  public class OkuScriptManager : ScriptManager
  {
    private const string ActorClass =
      "// Actor class\n" +
      "function Actor(actorId)\n" +
      "{\n" +
      "  this.actorId = actorId;\n" +
      "  \n" +
      "  this.getX = function()\n" +
      "  {\n" +
      "    return oku_getActorX(this.actorId);\n" +
      "  }\n" +
      "\n" +
      "  this.getY = function()\n" +
      "  {\n" +
      "    return oku_getActorY(this.actorId);\n" +
      "  }\n" +
      "\n" +
      "  this.setX = function()\n" +
      "  {\n" +
      "    return oku_setActorX(this.actorId);\n" +
      "  }\n" +
      "\n" +
      "  this.setY = function()\n" +
      "  {\n" +
      "    return oku_setActorY(this.actorId);\n" +
      "  }  \n" +
      "}";

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

      _engine.Execute(ActorClass);
    }

  }
}
