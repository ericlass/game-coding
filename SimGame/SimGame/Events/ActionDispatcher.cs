using System;
using System.Collections.Generic;
using SimGame.Objects;

namespace SimGame.Events
{
  public class ActionDispatcher
  {
    private GameObjectManager _objectManager = null;

    public ActionDispatcher(GameObjectManager objectManager)
    {
      _objectManager = objectManager;
    }

    //Is called by the event manager when an event is triggered
    public void Dispatch(EventHandler handler)
    {
      GameObjectWrapper obj = _objectManager[handler.ObjectId];
      if (obj == null)
        throw new ArgumentException("Unknown object id: " + handler.ObjectId);

      obj.TriggerAction(handler.ActionId, handler.Parameters);
    }
  }
}
