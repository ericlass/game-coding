using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.GCC.Scene;
using OkuEngine.GCC.Resources;
using OkuEngine.GCC.Actor;

namespace OkuEngine
{
  /// <summary>
  /// Contains the data of the game.
  /// </summary>
  public static class OkuData
  {
    private static VariableList _globals = null;
    private static VariableList _locals = null;
    private static ResourceCache _resources = null;
    private static SceneManager _sceneManager = null;
    private static ActorTypeManager _actorTypes = null;

    /// <summary>
    /// Gets the global variable list.
    /// </summary>
    public static VariableList Globals
    {
      get
      {
        if (_globals == null)
          _globals = new VariableList();
        return _globals;
      }
    }

    /// <summary>
    /// Gets or sets the local variable list.
    /// </summary>
    public static VariableList Locals
    {
      get
      {
        if (_locals == null)
          _locals = new VariableList();
        return _locals;
      }
      set { _locals = value; }
    }

    /// <summary>
    /// Gets or sets the resource cache.
    /// </summary>
    public static ResourceCache ResourceCache
    {
      get { return _resources; }
      set { _resources = value; }
    }

    /// <summary>
    /// Gets the scene manager.
    /// </summary>
    public static SceneManager SceneManager
    {
      get
      {
        if (_sceneManager == null)
        {
          _sceneManager = new SceneManager();
        }
        return _sceneManager;
      }
    }

    /// <summary>
    /// Gets a map of actor types.
    /// </summary>
    public static ActorTypeManager ActorTypes
    {
      get
      {
        if (_actorTypes == null)
          _actorTypes = new ActorTypeManager();

        return _actorTypes;
      }
    }

  }
}
