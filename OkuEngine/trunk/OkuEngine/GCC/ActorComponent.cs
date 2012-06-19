using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC
{
  /// <summary>
  /// Base class for all actor components
  /// </summary>
  public abstract class ActorComponent
  {
    protected Actor _owner = null;

    /// <summary>
    /// Gets or sets the actor this component belongs to.
    /// </summary>
    internal Actor Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public virtual bool Init(XmlNode node)
    {
      return false;
    }

    public virtual void PostInit()
    {
    }

    public virtual void Update(float dt)
    {
    }

    public abstract int GetComponentId();
  }
}
