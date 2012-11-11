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
      return base.Load(node);
    }

    public override bool Save(XmlWriter writer)
    {
      return base.Save(writer);
    }

  }
}
