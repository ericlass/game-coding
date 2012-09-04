using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scene;
using OkuEngine.Actors.Components;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a single actor in the game. Not to be confused with an ActorType.
  /// </summary>
  public class Actor : StoreableEntity
  {
    private Dictionary<int, ActorComponent> _components = null; //Is created lazylly in the getter. Some actors might not need it.

    /// <summary>
    /// Creates a new actor.
    /// </summary>
    public Actor()
    {
    }

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
    /// Loads an actor including its components from the given xml node.
    /// This also adds the actor to the corresponding scene and layer.
    /// </summary>
    /// <param name="node">The node to start loading from.</param>
    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      int actorType = 0;

      string value = node.GetTagValue("type");
      if (value != null)
      {
        int test = 0;
        if (int.TryParse(value, out test))
          actorType = test;
        else
          return false;
      }

      XmlNode child = node["components"];
      if (child != null)
      {
        ActorComponentFactory factory = new ActorComponentFactory();
        XmlNode componentNode = child.FirstChild;
        while (componentNode != null)
        {
          ActorComponent component = factory.CreateComponent(componentNode);
          if (component != null)
          {
            Components.Add(component.GetComponentId(), component);
            component.Owner = this;
          }
          else
          {
            OkuManagers.Logger.LogError("Could not load actor component: " + componentNode.OuterXml);
            return false;
          }
          componentNode = componentNode.NextSibling;
        }
      }

      return true;
    }

    /// <summary>
    /// Saves the data of this actor to the given XML writer.
    /// </summary>
    /// <param name="writer">The xml writer to write to.</param>
    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("actor");

      if (!base.Save(writer))
        return false;

      writer.WriteStartElement("components");
      foreach (ActorComponent comp in _components.Values)
      {
        comp.Save(writer);
      }
      writer.WriteEndElement();

      writer.WriteEndElement();

      return true;
    }

  }
}
