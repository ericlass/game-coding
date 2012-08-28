using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Actors.Components
{
  /// <summary>
  /// Base class for all actor components
  /// </summary>
  public abstract class ActorComponent : IStoreable
  {
    protected ActorType _owner = null;

    /// <summary>
    /// Gets or sets the actor type this component belongs to.
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
    public abstract bool Load(XmlNode node);
    public abstract void Save(XmlWriter writer);

  }
}
