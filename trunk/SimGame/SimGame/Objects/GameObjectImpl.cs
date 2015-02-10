using System;
using System.Collections.Generic;

namespace SimGame.Objects
{
  public class GameObjectImpl
  {
    public GameObject Object { get; set; }

    public virtual void Initialize() { }
    public virtual void Update(float dt) { }
    public virtual void Render() { }
    public virtual void Finish() { }
    public virtual void TriggerAction(string actionId, object[] parameters) { }
  }
}
