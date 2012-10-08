using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Components
{
  public class EntityComponentFactory
  {
    private delegate EntityComponent ActorComponentCreatorDelegate(XmlNode node);

    private Dictionary<string, ActorComponentCreatorDelegate> _actorComponentCreators = new Dictionary<string, ActorComponentCreatorDelegate>();

    public EntityComponentFactory()
    {
      _actorComponentCreators.Add(HealthPickup.ComponentName, new ActorComponentCreatorDelegate(CreateHealthPickup));
      _actorComponentCreators.Add(RenderComponent.ComponentName, new ActorComponentCreatorDelegate(CreateRenderComponent));
      _actorComponentCreators.Add(AttributeComponent.ComponentName, new ActorComponentCreatorDelegate(CreateParameterComponent));
    }

    protected EntityComponent CreateHealthPickup(XmlNode node)
    {
      return new HealthPickup();
    }

    protected EntityComponent CreateRenderComponent(XmlNode node)
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

    protected EntityComponent CreateParameterComponent(XmlNode node)
    {
      return new AttributeComponent();
    }

    public EntityComponent CreateComponent(XmlNode node)
    {
      string name = node.Name;
      EntityComponent result = null;

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

    public int GetComponentId(XmlNode node)
    {
      switch (node.Name.ToLower())
      {
        case HealthPickup.ComponentName:
          return HealthPickup.ComponentId;

        case RenderComponent.ComponentName:
          return RenderComponent.ComponentId;

        case AttributeComponent.ComponentName:
          return AttributeComponent.ComponentId;

        default:
          return 0;
      }
    }

  }
}
