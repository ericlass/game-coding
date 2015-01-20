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
    public void Dispatch(string actionStr, object[] parameters)
    {
      String[] parts = actionStr.Split('.');
      if (parts.Length != 2)
        throw new ArgumentException("Invalid action id! Action id must be formatted <objectid>.<actionid>");

      GameObjectWrapper obj = _objectManager[parts[0]];
      if (obj == null)
        throw new ArgumentException("Unknown object id! Action id must be formatted <objectid>.<actionid>");

      obj.TriggerAction(parts[1], parameters);
    }
  }
}
