using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Contains the data of the game.
  /// </summary>
  public static class OkuData
  {
    private static VariableList _globals = null;
    private static VariableList _locals = null;
    private static SceneGraph _scene = new SceneGraph();

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
    public static SceneGraph Scene
    {
      get { return _scene; }
    }

    /// <summary>
    /// Gets or sets the world transformation matrix that can be used
    /// to transform coordinates from object space to world space.
    /// Object space means current object space of the scene node that is 
    /// currently processed.
    /// </summary>
    /*public static Matrix3 WorldMatrix
    {
      get { return _worldMatrix; }
      set { _worldMatrix = value; }
    }*/

  }
}
