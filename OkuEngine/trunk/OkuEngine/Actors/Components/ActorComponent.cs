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
    protected Actor _owner = null;

    /// <summary>
    /// Gets or sets the actor type this component belongs to.
    /// </summary>
    internal Actor Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public virtual void Update(float dt)
    {
    }

    public abstract int GetComponentId();
    public abstract bool Load(XmlNode node);
    public abstract bool Save(XmlWriter writer);

  }
}
