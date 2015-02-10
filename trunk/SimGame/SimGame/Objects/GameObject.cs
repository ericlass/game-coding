using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame.Objects
{
  /// <summary>
  /// Defines the base structure for a game object.
  /// The handlers are called accordingly by the object manager.
  /// Each handler is optional and can be null.
  /// </summary>
  public class GameObject
  {
    //Make actions do nothing by default
    private Action<GameObject> _initializeHandler = null;
    private Action<float> _updateHandler = null;
    private Action _renderHandler = null;
    private Action _finishHandler = null;
    private Action<string, object[]> _triggerActionHandler = null;

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
      set { _initializeHandler = value; }
    }

    /// <summary>
    /// Sets the update handler.
    /// </summary>
    public Action<float> UpdateHandler
    {
      set { _updateHandler = value; }
    }

    /// <summary>
    /// Sets the render handler.
    /// </summary>
    public Action RenderHandler
    {
      set { _renderHandler = value; }
    }

    /// <summary>
    /// Gets if the object can be rendered (= has a render handler).
    /// </summary>
    public bool CanRender
    {
      get { return _renderHandler != null; }
    }

    /// <summary>
    /// Sets the finilization handler.
    /// </summary>
    public Action FinishHandler
    {
      set { _finishHandler = value; }
    }

    /// <summary>
    /// Sets the trigger action handler.
    /// </summary>
    public Action<string, object[]> TriggerActionHandler
    {
      set { _triggerActionHandler = value; }
    }

    /// <summary>
    /// Executes the initialization handler, if it is not null.
    /// </summary>
    public void Initialize()
    {
      if (_initializeHandler != null)
        _initializeHandler(this);
    }

    /// <summary>
    /// Executes the update handler, if it is not null.
    /// </summary>
    /// <param name="dt">The time since the last frame in seconds.</param>
    public void Update(float dt)
    {
      if (_updateHandler != null)
        _updateHandler(dt);
    }

    /// <summary>
    /// Executes the render handler, if it is not null.
    /// </summary>
    public void Render()
    {
      if (_renderHandler != null)
        _renderHandler();
    }

    /// <summary>
    /// Executes the finalization handler, if it is not null.
    /// </summary>
    public void Finish()
    {
      if (_finishHandler != null)
        _finishHandler();
    }

    /// <summary>
    /// Executes the trigger action handler, if it is not null.
    /// </summary>
    /// <param name="actionId">The id of the action to be triggered.</param>
    /// <param name="parameters">The parameters for the action.</param>
    public void TriggerAction(string actionId, object[] parameters)
    {
      if (_triggerActionHandler != null)
        _triggerActionHandler(actionId, parameters);
    }

  }
}
