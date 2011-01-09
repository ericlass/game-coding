using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Specifies the type of action that is happening.
  /// </summary>
  public enum ActionType { 
    /// <summary>
    /// This action only happens once when the game starts and should be used to initialize and prepare things that are needed while the game is running.
    /// </summary>
    Init, 
    /// <summary>
    /// This action happens every frame of the game so it should be as fast as possible.
    /// </summary>
    Update, 
    /// <summary>
    /// This action only happens once when the game ends. Should be used to free resources used while the game was running.
    /// </summary>
    Finish
  }

  /// <summary>
  /// Callback delegate for the action.
  /// </summary>
  /// <param name="type">The type of action that is done.</param>
  public delegate void ActionHandleDelegate(SceneNode node, ActionType type);

  /// <summary>
  /// Contains information about the action handler.
  /// </summary>
  public class ActionHandler
  {
    private VariableList _locals = null;
    private ActionHandleDelegate _onAction = null;
    
    /// <summary>
    /// Creates a new ActionHandler with no action and no variables.
    /// </summary>
    public ActionHandler()
    {
    }

    /// <summary>
    /// Creates a new ActionHandler with the given action and no variables.
    /// </summary>
    /// <param name="action"></param>
    public ActionHandler(ActionHandleDelegate action)
    {
      OnAction = action;
    }

    /// <summary>
    /// Gets or sets the action associated with this ActionHandler.
    /// </summary>
    public ActionHandleDelegate OnAction 
    {
      get { return _onAction; }
      set { _onAction = value; }
    }

    /// <summary>
    /// Gets or sets the local variable list associated with the action.
    /// </summary>
    public VariableList Locals 
    {
      get
      {
        if (_locals == null)
          _locals = new VariableList();
        return _locals;
      }
      set { _locals = value; }
    }

  }
}
