using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC.Actors
{
  /// <summary>
  /// Base class for all actor components
  /// </summary>
  public abstract class ActorComponent : IStoreable
  {
    protected ActorType _owner = null;

    /// <summary>
    /// Gets or sets the actor this component belongs to.
    /// </summary>
    internal ActorType Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public virtual void Update(float dt)
    {
    }

    public abstract int GetComponentId();
    public abstract void Load(XmlNode node);
    public abstract void Save(XmlWriter writer);

  }
}
