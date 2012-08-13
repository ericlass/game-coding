using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC.Actor
{
  /// <summary>
  /// Defines the type of an actor.
  /// </summary>
  public class ActorType : StoreableEntity
  {
    private Dictionary<int, ActorComponent> _components = null; //Is created lazylly in the getter. Some actors might not need it.

    /// <summary>
    /// Gets the component with the given id.
    /// </summary>
    /// <param name="componentId">The id of the component.</param>
    /// <returns>The component with the given id or null if the actor has no component with this id.</returns>
    public ActorComponent GetComponent(int componentId)
    {
      if (Components.ContainsKey(componentId))
      {
        return Components[componentId];
      }
      return null;
    }

    /// <summary>
    /// Adds the given component to the actor type.
    /// </summary>
    /// <param name="component">The component to add.</param>
    public void AddComponent(ActorComponent component)
    {
      if (component != null)
      {
        Components.Add(component.GetComponentId(), component);
      }
    }

    /// <summary>
    /// Gets the map of components.
    /// </summary>
    private Dictionary<int, ActorComponent> Components
    {
      get
      {
        if (_components == null)
        {
          _components = new Dictionary<int, ActorComponent>();
        }
        return _components;
      }
    }

    /// <summary>
    /// Loads the actor type from the given xml node.
    /// </summary>
    /// <param name="node">The xml node to read from.</param>
    public override void Load(XmlNode node)
    {
      base.Load(node);

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "components":
            ActorComponentFactory factory = new ActorComponentFactory();
            XmlNode componentNode = child.FirstChild;
            while (componentNode != null)
            {
              ActorComponent component = factory.CreateComponent(componentNode);
              if (component != null)
              {
                _components.Add(component.GetComponentId(), component);
              }
              componentNode = componentNode.NextSibling;
            }
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }
    }

    /// <summary>
    /// Saves the actor type to the given xml writer.
    /// </summary>
    /// <param name="writer">The xml writer to write to.</param>
    public override void Save(XmlWriter writer)
    {
      writer.WriteStartElement("actortype");

      base.Save(writer);

      writer.WriteStartElement("components");
      foreach (ActorComponent comp in _components.Values)
      {
        comp.Save(writer);
      }
      writer.WriteEndElement();

      writer.WriteEndElement();
    }

  }
}
