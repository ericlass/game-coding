using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC.Actors
{
  public class ActorTypeManager : IStoreable
  {
    private Dictionary<int, ActorType> _typeMap = new Dictionary<int, ActorType>();

    public bool Add(ActorType actorType)
    {
      if (!_typeMap.ContainsKey(actorType.Id))
      {
        _typeMap.Add(actorType.Id, actorType);
        return true;
      }
      return false;
    }

    public ActorType this[int actorTypeId]
    {
      get
      {
        if (_typeMap.ContainsKey(actorTypeId))
          return _typeMap[actorTypeId];
        return null;
      }
    }

    public bool Remove(int actorTypeId)
    {
      return _typeMap.Remove(actorTypeId);
    }

    public bool Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "actortype":
            ActorType type = new ActorType();
            type.Load(child);
            if (!Add(type))
            {
              OkuManagers.Logger.LogError("The actor type id '" + type.Id + "' is specified twice in the configuration file!");
            }
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
      writer.WriteStartElement("actortypes");

      foreach (ActorType type in _typeMap.Values)
      {
        type.Save(writer);
      }

      writer.WriteEndElement();
    }

  }
}
