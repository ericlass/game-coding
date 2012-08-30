﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scene;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a single actor in the game. Not to be confused with an ActorType.
  /// </summary>
  public class Actor : StoreableEntity
  {
    private ActorType _type = null;

    /// <summary>
    /// Creates a new actor.
    /// </summary>
    public Actor()
    {
    }

    /// <summary>
    /// Gets or sets the type of the actor.
    /// </summary>
    public ActorType Type
    {
      get { return _type; }
      set { _type = value; }
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

      _type = OkuData.ActorTypes[actorType];
      if (_type == null)
      {
        OkuManagers.Logger.LogError("There is no actor type with the id '" + actorType + "'!");
        return false;
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

      writer.WriteValueTag("type", _type.Id.ToString());

      int scene, layer;
      if (OkuData.SceneManager.FindActor(Id, out scene, out layer))
      {
        writer.WriteValueTag("scene", scene.ToString());
        writer.WriteValueTag("layer", layer.ToString());

        SceneNode node = OkuData.SceneManager[scene].GetLayer(layer).GetNode(Id);
        if (node != null)
        {
          if (node.Parent != null && node.Parent.Properties.ActorId > 0)
          {
            writer.WriteValueTag("parent", node.Parent.Properties.ActorId.ToString());
          }

          node.Properties.Transform.Save(writer);
        }
      }

      writer.WriteEndElement();

      return true;
    }

  }
}
