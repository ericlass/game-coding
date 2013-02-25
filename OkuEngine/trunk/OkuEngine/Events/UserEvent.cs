using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Events
{
  /// <summary>
  /// Defines a user defined event.
  /// </summary>
  public class UserEvent : StoreableEntity
  {
    public override bool Load(XmlNode node)
    {
      //TODO: Check that event id is greater than EventTypes.UserEventBase
      return base.Load(node);
    }

    public override bool Save(XmlWriter writer)
    {
      return base.Save(writer);
    }

    public override bool AfterLoad()
    {
      return true;
    }

  }
}
