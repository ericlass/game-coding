using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC
{
  public class ActorFactory
  {
    private delegate ActorComponent ActorComponentCreatorDelegate();

    private Dictionary<string, ActorComponentCreatorDelegate> _actorComponentCreators = new Dictionary<string, ActorComponentCreatorDelegate>();

    public ActorFactory()
    {
      _actorComponentCreators.Add(HealthPickup.ComponentName, new ActorComponentCreatorDelegate(CreateHealthPickup));
      _actorComponentCreators.Add(TransformComponent.ComponentName, new ActorComponentCreatorDelegate(CreateTransformComponent));
    }

    public ActorComponent CreateHealthPickup()
    {
      return new HealthPickup();
    }

    public ActorComponent CreateTransformComponent()
    {
      return new TransformComponent();
    }

    public Actor CreateActor(XmlNode node)
    {
      Actor result = new Actor(KeySequence.NextValue);
      if (!result.Init(node))
      {
        throw new OkuException();
      }

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        ActorComponent comp = CreateComponent(child);
        if (comp != null)
        {
          result.AddComponent(comp);
          comp.Owner = result;
          comp.PostInit();
        }

        child = child.NextSibling;
      }

      result.PostInit();

      return result;
    }

    protected virtual ActorComponent CreateComponent(XmlNode node)
    {
      string name = node.Name;
      ActorComponent result = null;

      if (_actorComponentCreators.ContainsKey(name))
      {
        result = _actorComponentCreators[name]();
        if (!result.Init(node))
        {
          throw new OkuException();
        }
      }

      return result;
    }

  }
}
