using System;
using System.Collections.Generic;

namespace SimGame.Objects
{
  public class GameObjectBase
  {
    public GameObject Object { get; set; }

    public virtual void Initialize(GameObject obj) { }
    public virtual void Update(GameObject obj, float dt) { }
    public virtual void Render(GameObject obj) { }
    public virtual void Finish(GameObject obj) { }
    public virtual void TriggerAction(GameObject obj, string actionId, object[] parameters) { }
  }
}
