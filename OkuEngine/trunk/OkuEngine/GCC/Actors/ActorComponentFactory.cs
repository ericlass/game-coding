using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC.Actors
{
  public class ActorComponentFactory
  {
    private delegate ActorComponent ActorComponentCreatorDelegate();

    private Dictionary<string, ActorComponentCreatorDelegate> _actorComponentCreators = new Dictionary<string, ActorComponentCreatorDelegate>();

    public ActorComponentFactory()
    {
      _actorComponentCreators.Add(HealthPickup.ComponentName, new ActorComponentCreatorDelegate(CreateHealthPickup));
      _actorComponentCreators.Add(RenderComponent.ComponentName, new ActorComponentCreatorDelegate(CreateRenderComponent));
    }

    protected ActorComponent CreateHealthPickup()
    {
      return new HealthPickup();
    }

    protected ActorComponent CreateRenderComponent()
    {
      return new RenderComponent();
    }

    public ActorComponent CreateComponent(XmlNode node)
    {
      string name = node.Name;
      ActorComponent result = null;

      if (_actorComponentCreators.ContainsKey(name))
      {
        result = _actorComponentCreators[name]();
        result.Load(node);
      }

      return result;
    }

  }
}
