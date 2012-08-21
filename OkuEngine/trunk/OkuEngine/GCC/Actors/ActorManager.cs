using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC.Actors
{
  public class ActorManager : IStoreable
  {
    private Dictionary<int, Actor> _actorMap = new Dictionary<int, Actor>();

    public ActorManager()
    {
    }

    public bool Add(Actor actor)
    {
      if (!_actorMap.ContainsKey(actor.Id))
      {
        _actorMap.Add(actor.Id, actor);
        return true;
      }
      return false;
    }

    public bool Remove(Actor actor)
    {
      //TODO: Maybe post actor remove event?
      return _actorMap.Remove(actor.Id);
    }

    public Actor this[int id]
    {
      get
      {
        if (_actorMap.ContainsKey(id))
          return _actorMap[id];

        return null;
      }
    }

    public bool Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "actor":
            Actor actor = new Actor();
            if (!actor.Load(child))
            {
              OkuManagers.Logger.LogError("Could not load actor with id '" + actor.Id + "'!");
            }
            if (!Add(actor))
            {
              OkuManagers.Logger.LogError("The actor id '" + actor.Id + "' was used twice!");
            }
            //TODO: Update sequence according to actor id
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      return true;
    }

    public void Save(XmlWriter writer)
    {
      writer.WriteStartElement("actors");

      foreach (Actor actor in _actorMap.Values)
      {
        actor.Save(writer);
      }

      writer.WriteEndElement();
    }

  }
}
