using System;
using System.Collections.Generic;
using SimGame.Events;

namespace SimGame.Objects
{
  public class GameObjectWrapper
  {
    private IGameObject _object = null;
    private EventManager _eventQueue = null;

    private string _id = null;

    public GameObjectWrapper(string id, IGameObject obj, EventManager eventQueue)
    {
      _eventQueue = eventQueue;

      _object = obj;
      _id = id;
    }

    public string Id
    {
      get { return _id; }
    }

    public void Init()
    {
      _object.Init(this);
    }

    public void Update(float dt)
    {
      _object.Update(dt, this);
    }

    public void Finish(float dt)
    {
      _object.Finish(this);
      //Make sure to release reference
      _object = null;
    }

    //The actual object is supposed to call this method whenever it wants to fire an event
    public void FireEvent(string eventId)
    {
      _eventQueue.QueueEvent(_id + "." + eventId);
    }

    //This is called from some event manager which dispatches events to the corresponding objects
    public void TriggerAction(string actionId, object[] parameters)
    {
      _object.TriggerAction(actionId, parameters);
    }
  }
}
