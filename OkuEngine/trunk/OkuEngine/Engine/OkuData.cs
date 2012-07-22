using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.GCC.Scene;
using OkuEngine.GCC.Resources;

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
    private static Scene _scene = new Scene();

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
    /// Gets the scene graph.
    /// </summary>
    public static Scene Scene
    {
      get { return _scene; }
    }

    /// <summary>
    /// Gets or sets the resource cache.
    /// </summary>
    public static ResourceCache ResourceCache
    {
      get { return _resources; }
      set { _resources = value; }
    }

  }
}
