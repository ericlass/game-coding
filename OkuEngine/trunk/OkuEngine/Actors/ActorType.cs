using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Components;

namespace OkuEngine.Actors
{
  public class ActorType : StoreableEntity
  {

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      //TODO: Load actor type

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("actortype");

      if (!base.Save(writer))
        return false;

      //TODO: Save actor type

      writer.WriteEndElement();

      return true;
    }

  }
}
