using System;
using System.Collections.Generic;

namespace SimGame.Objects
{
  public interface IGameObject
  {
    //Standard methods
    void Init(GameObjectWrapper wrapper);
    void Update(float dt, GameObjectWrapper wrapper);
    void Finish(GameObjectWrapper wrapper);

    //Something has triggered an action for this object
    void TriggerAction(string actionId, object[] parameters);
  }
}
