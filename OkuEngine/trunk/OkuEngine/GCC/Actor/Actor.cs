using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC.Actor
{
  public class Actor
  {
    private int _actorId = 0;
    private ActorComponentMap _components = null; //Is created lazylly in the getter. Some actors might not need it.

    public Actor(int actorId)
    {
      _actorId = actorId;
    }

    public int ActorId
    {
      get { return _actorId; }
    }

    public bool Init(XmlNode node)
    {
      return true;
    }

    public void PostInit()
    {
      foreach (ActorComponent comp in Components.Values)
      {
        comp.PostInit();
      }
    }

    public ActorComponent GetComponent(int componentId)
    {
      if (Components.ContainsKey(componentId))
      {
        return Components[componentId];
      }
      return null;
    }

    public void AddComponent(ActorComponent component)
    {
      if (component != null)
      {
        Components.Add(component.GetComponentId(), component);
      }
    }

    private ActorComponentMap Components
    {
      get
      {
        if (_components == null)
        {
          _components = new ActorComponentMap();
        }
        return _components;
      }
    }

  }
}
