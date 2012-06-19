using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC
{
  public class HealthPickup : ActorComponent
  {
    //These two static members cannot be enforced, but should be in all components to be consistent.
    public const int ComponentId = 1;
    public const string ComponentName = "healthpickup";
    
    public override int GetComponentId()
    {
      return ComponentId;
    }

    public override bool Init(XmlNode node)
    {
      if (node.Name != ComponentName)
        return false;

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name)
        {
          case "health":
            Health = child.Attributes.GetFloat("value", 0.0f);
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      return true;
    }

    public void Apply(Actor actor)
    {
      throw new NotImplementedException();
    }

    public float Health { get; set; }

  }
}
