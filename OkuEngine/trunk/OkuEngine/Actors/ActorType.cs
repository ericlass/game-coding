using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Components;
using OkuEngine.States;

namespace OkuEngine.Actors
{
  public class ActorType : StoreableEntity
  {
    private StateManager<ActorState> _states = new StateManager<ActorState>();

    public StateManager<ActorState> States
    {
      get { return _states; }
    }

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      XmlNode statesNode = node["states"];
      if (statesNode != null)
      {
        if (!_states.Load(statesNode))
          return false;
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("actortype");

      if (!base.Save(writer))
        return false;

      if (_states != null)
        if (!_states.Save(writer))
          return false;

      writer.WriteEndElement();

      return true;
    }

  }
}
