using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.GCC.Scene;

namespace OkuEngine.GCC.Actor
{
  /// <summary>
  /// Defines a single actor in the game. Not to be confused with an ActorType.
  /// </summary>
  public class Actor : StoreableEntity
  {
    public ActorType _type = null;

    /// <summary>
    /// Creates a new actor.
    /// </summary>
    public Actor()
    {
    }

    /// <summary>
    /// Loads an actor includiong its components from the given xml node.
    /// This also adds the actor to the corresponding scene and layer.
    /// </summary>
    /// <param name="node">The node to start loading from.</param>
    public override void Load(XmlNode node)
    {
      base.Load(node);

      int actorType = 0;
      int sceneId = 0;
      int layerId = 0;
      int parentId = 0;

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "type":
            actorType = int.Parse(child.FirstChild.Value);
            break;

          case "scene":
            sceneId = int.Parse(child.FirstChild.Value);
            break;

          case "layer":
            layerId = int.Parse(child.FirstChild.Value);
            break;

          case "parent":
            parentId = int.Parse(child.FirstChild.Value);
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      if (actorType != 0 && sceneId != 0 && layerId != 0)
      {
        _type = OkuData.ActorTypes[actorType];
        //TODO: Check that scene and layer with given ids exist
        SceneNode parent = null;
        if (parentId != 0)
        {
          parent = OkuData.SceneManager[sceneId].GetLayer(layerId).GetNode(parentId);

        }

        OkuData.SceneManager[sceneId].GetLayer(layerId).Add(Id, null);
      }
      else
      {
        //TODO: Log error
      }
    }

    /// <summary>
    /// Saves the data of this actor to the given XML writer.
    /// </summary>
    /// <param name="writer">The xml writer to write to.</param>
    public override void Save(XmlWriter writer)
    {
      writer.WriteStartElement("actor");

      base.Save(writer);

      writer.WriteStartElement("type");
      writer.WriteValue(_type.Id);
      writer.WriteEndElement();

      int scene, layer;
      if (OkuData.SceneManager.FindActor(Id, out scene, out layer))
      {
        writer.WriteStartElement("scene");
        writer.WriteValue(scene);
        writer.WriteEndElement();

        writer.WriteStartElement("layer");
        writer.WriteValue(layer);
        writer.WriteEndElement();

        SceneNode node = OkuData.SceneManager[scene].GetLayer(layer).GetNode(Id);
        if (node != null && node.Parent != null && node.Parent.Properties.ActorId > 0)
        {
          writer.WriteStartElement("parent");
          writer.WriteValue(node.Parent.Properties.ActorId);
          writer.WriteEndElement();
        }
      }

      writer.WriteEndElement();
    }

  }
}
