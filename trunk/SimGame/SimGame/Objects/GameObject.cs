using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame.Objects
{
  /// <summary>
  /// Defines the base structure for a game object.
  /// 
  /// </summary>
  public class GameObject
  {
    //Make actions do nothing by default
    private Action<GameObject> _initializeHandler = (a) => { };
    private Action<GameObject, float> _updateHandler = (a, b) => { };
    private Action<GameObject> _renderHandler = (a) => { };
    private Action<GameObject> _finishHandler = (a) => { };
    private Action<GameObject, string, object[]> _triggerActionHandler = (a, b, c) => { };

    public GameObject(string id)
    {
      Id = id;
    }

    /// <summary>
    /// Gets or sets the id of the object.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the z index of the object.
    /// </summary>
    public int ZIndex { get; set; }

    /// <summary>
    /// Gets or sets the transform of the object.
    /// </summary>
    public Transform Transform { get; set; }

    /// <summary>
    /// Sets the initialization handler.
    /// </summary>
    public Action<GameObject> InitializeHandler
    {
      set
      {
        if (value != null)
          _initializeHandler = value;
        else
          _initializeHandler = (a) => { };
      }
    }

    /// <summary>
    /// Sets the update handler.
    /// </summary>
    public Action<GameObject, float> UpdateHandler
    {
      set
      {
        if (value != null)
          _updateHandler = value;
        else
          _updateHandler = (a, b) => { };
      }
    }

    /// <summary>
    /// Sets the render handler.
    /// </summary>
    public Action<GameObject> RenderHandler
    {
      set
      {
        if (value != null)
          _renderHandler = value;
        else
          _renderHandler = (a) => { };
      }
    }

    /// <summary>
    /// Sets the finilization handler.
    /// </summary>
    public Action<GameObject> FinishHandler
    {
      set
      {
        if (value != null)
          _finishHandler = value;
        else
          _finishHandler = (a) => { };
      }
    }

    /// <summary>
    /// Sets the trigger action handler.
    /// </summary>
    public Action<GameObject, string, object[]> TriggerActionHandler
    {
      set
      {
        if (value != null)
          _triggerActionHandler = value;
        else
          _triggerActionHandler = (a, b, c) => { };
      }
    }

    /// <summary>
    /// Executes the initialization handler.
    /// </summary>
    public void Initialize()
    {
      _initializeHandler(this);
    }

    /// <summary>
    /// Executes the update handler.
    /// </summary>
    /// <param name="dt">The time since the last frame in seconds.</param>
    public void Update(float dt)
    {
      _updateHandler(this, dt);
    }

    /// <summary>
    /// Executes the render handler.
    /// </summary>
    public void Render()
    {
      _renderHandler(this);
    }

    /// <summary>
    /// Executes the finalization handler.
    /// </summary>
    public void Finish()
    {
      _finishHandler(this);
    }

    /// <summary>
    /// Executes the trigger action handler.
    /// </summary>
    /// <param name="actionId">The id of the action to be triggered.</param>
    /// <param name="parameters">The parameters for the action.</param>
    public void TriggerAction(string actionId, object[] parameters)
    {
      _triggerActionHandler(this, actionId, parameters);
    }

  }
}
