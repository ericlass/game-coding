using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Actors.Components;

namespace OkuEngine.Actors
{
  public class ActorType : StoreableEntity
  {
    private Dictionary<int, ActorComponent> _components = null;

    /// <summary>
    /// Gets the component with the given id.
    /// </summary>
    /// <param name="componentId">The id of the component.</param>
    /// <returns>The component with the given id or null if the actor has no component with this id.</returns>
    public ActorComponent GetComponent(int componentId)
    {
      if (_components != null && _components.ContainsKey(componentId))
      {
        return _components[componentId];
      }
      return null;
    }

    /// <summary>
    /// Adds the given component to the actor type.
    /// </summary>
    /// <param name="component">The component to add.</param>
    internal bool AddComponent(ActorComponent component)
    {
      if (_components != null && component != null && !_components.ContainsKey(component.GetComponentId()))
      {
        _components.Add(component.GetComponentId(), component);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Creates a new actor of this type.
    /// </summary>
    /// <param name="node">The xml node to load the actor data from.</param>
    /// <returns>The newly created actor.</returns>
    public Actor CreateActor(XmlNode node)
    {
      Actor result = new Actor();
      if (result.Load(node))
      {
        foreach (ActorComponent comp in _components.Values)
        {
          ActorComponent copyComp = comp.Copy();
          copyComp.Owner = result;
          result.AddComponent(comp.Copy());
        }
      }
      return result;
    }

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

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
            if (_components == null)
              _components = new Dictionary<int, ActorComponent>();

            _components.Add(component.GetComponentId(), component);
          }
          else
          {
            OkuManagers.Logger.LogError("Could not load actor type component: " + componentNode.OuterXml);
            return false;
          }
          componentNode = componentNode.NextSibling;
        }
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("actortype");

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
