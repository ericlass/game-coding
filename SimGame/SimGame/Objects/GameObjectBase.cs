using System;
using System.Collections.Generic;
using OkuBase.Geometry;

namespace SimGame.Objects
{
  public class GameObjectBase
  {
    public virtual Rectangle2f GetBounds() { return new Rectangle2f(); }
    public virtual object GetAttributeValue(string attribute) { return null; }

    public virtual void Initialize(GameObject obj) { }
    public virtual void Update(GameObject obj, float dt) { }
    public virtual void Render(GameObject obj) { }
    public virtual void Finish(GameObject obj) { }

    public virtual void TriggerAction(GameObject obj, string actionId, object[] parameters) { }
  }
}
