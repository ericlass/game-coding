using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame.Objects
{
  /// <summary>
  /// Container for game objects. This is done to force some stuff like the constructor.
  /// </summary>
  public class GameObject
  {
    private string _id = null;
    private int _zIndex = 0;
    private Transform _transform = new Transform();

    private GameObjectBase _impl = null;
    
    public GameObject(string id, GameObjectBase impl)
    {
      _id = id;
      _impl = impl;
    }

    /// <summary>
    /// Gets or sets the id of the object.
    /// </summary>
    public string Id 
    { 
      get { return _id; } 
      set { _id = value; }
    }

    /// <summary>
    /// Gets or sets the z index of the object.
    /// </summary>
    public int ZIndex
    {
      get { return _zIndex; }
      set { _zIndex = value; }
    }

    /// <summary>
    /// Gets or sets the transform of the object.
    /// </summary>
    public Transform Transform 
    {
      get { return _transform; }
      set { _transform = value; }
    }

    /// <summary>
    /// Initializes the object.
    /// </summary>
    public void Initialize()
    {
      _impl.Initialize(this);
    }

    /// <summary>
    /// Updates the object.
    /// </summary>
    /// <param name="dt">The time since the last frame in seconds.</param>
    public void Update(float dt)
    {
      _impl.Update(this, dt);
    }

    /// <summary>
    /// Renders the object.
    /// </summary>
    public void Render()
    {
      _impl.Render(this);
    }

    /// <summary>
    /// Finished the object.
    /// </summary>
    public void Finish()
    {
      _impl.Finish(this);
    }

    /// <summary>
    /// Triggers the given action for the object.
    /// </summary>
    /// <param name="actionId">The id of the action to be triggered.</param>
    /// <param name="parameters">The parameters for the action.</param>
    public void TriggerAction(string actionId, object[] parameters)
    {
      _impl.TriggerAction(this, actionId, parameters);
    }
    
    /// <summary>
    /// Should be used by object implementations to fire an event correctly.
    /// <param name="eventName">The name of the event, without the object id.</param>
    /// </summary>
    public void QueueEvent(string eventName)
    {
      Global.EventQueue.QueueEvent(_id + "." + eventName);
    }

  }
}
