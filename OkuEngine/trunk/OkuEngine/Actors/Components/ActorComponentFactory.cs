using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Actors.Components
{
  public class ActorComponentFactory
  {
    private delegate ActorComponent ActorComponentCreatorDelegate(XmlNode node);

    private Dictionary<string, ActorComponentCreatorDelegate> _actorComponentCreators = new Dictionary<string, ActorComponentCreatorDelegate>();

    public ActorComponentFactory()
    {
      _actorComponentCreators.Add(HealthPickup.ComponentName, new ActorComponentCreatorDelegate(CreateHealthPickup));
      _actorComponentCreators.Add(RenderComponent.ComponentName, new ActorComponentCreatorDelegate(CreateRenderComponent));
    }

    protected ActorComponent CreateHealthPickup(XmlNode node)
    {
      return new HealthPickup();
    }

    protected ActorComponent CreateRenderComponent(XmlNode node)
    {
      string type = node.Attributes.GetAttributeValue("type", "");
      switch (type.ToLower())
      {
        case ImageRenderComponent.RenderType:
          return new ImageRenderComponent();

        case MeshRenderComponent.RenderType:
          return new MeshRenderComponent();

        case LineRenderComponent.RenderType:
          return new LineRenderComponent();

        case PointRenderComponent.RenderType:
          return new PointRenderComponent();

        default:
          OkuManagers.Logger.LogError("Render component type '" + type + "' is not supported!");
          break;
      }

      return null;
    }

    public ActorComponent CreateComponent(XmlNode node)
    {
      string name = node.Name;
      ActorComponent result = null;

      if (_actorComponentCreators.ContainsKey(name))
      {
        result = _actorComponentCreators[name](node);
        if (result != null)
        {
          if (!result.Load(node))
            return null;
        }
      }

      return result;
    }

  }
}
