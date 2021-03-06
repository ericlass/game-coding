﻿using System;
using System.Collections.Generic;
using OkuBase.Geometry;

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
    private bool _visible = true;

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
    /// Gets or sets if the object is currently visible.
    /// </summary>
    public bool Visible
    {
      get { return _visible; }
      set { _visible = value; }
    }

    /// <summary>
    /// Gets the boundaries of this object as an AABB.
    /// </summary>
    public Rectangle2f Bounds
    {
      get 
      { 
        Rectangle2f implBounds = _impl.GetBounds();
        return new Rectangle2f(_transform.Translation + implBounds.Min, _transform.Translation + implBounds.Max); 
      }
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

    /// <summary>
    /// Gets an attribute value from the object.
    /// </summary>
    /// <typeparam name="T">The type of the attribute.</typeparam>
    /// <param name="attribute">The name of the attribute.</param>
    /// <returns>The attributes values or null if the objects no attribute with the given name.</returns>
    public T GetAttributeValue<T>(string attribute)
    {
      object value = _impl.GetAttributeValue(attribute);
      if (!(value is T))
        throw new ArgumentException("Attribute '" + attribute + "' is not of type '" + typeof(T).FullName + "' but '" + value.GetType().FullName + "'!");

      return (T)value;
    }

  }
}
