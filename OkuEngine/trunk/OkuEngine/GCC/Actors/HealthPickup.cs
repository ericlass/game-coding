using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC.Actors
{
  public class HealthPickup : ActorComponent
  {
    //These two static members cannot be enforced, but should be in all components to be consistent.
    public const int ComponentId = 1;
    public const string ComponentName = "healthpickup";

    private int _health = 0;
    
    public override int GetComponentId()
    {
      return ComponentId;
    }

    public void Apply(Actor actor)
    {
      throw new NotImplementedException();
    }

    public int Health
    {
      get { return _health; }
      set { _health = value; }
    }

    public override void Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "health":
            _health = int.Parse(child.FirstChild.Value);
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }
    }

    public override void Save(XmlWriter writer)
    {
      writer.WriteStartElement(ComponentName);

      writer.WriteStartElement("health");
      writer.WriteValue(_health);
      writer.WriteEndElement();

      writer.WriteEndElement();
    }

  }
}
