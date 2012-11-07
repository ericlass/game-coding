﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Components
{
  public class HealthPickup : EntityComponent
  {
    //These two static members cannot be enforced, but should be in all components to be consistent.
    public const int ComponentId = EntityComponentIds.HealthPickupId;
    public const string ComponentName = "healthpickup";

    private int _health = 0;
    
    public override int GetComponentId()
    {
      return ComponentId;
    }

    public int Health
    {
      get { return _health; }
      set { _health = value; }
    }

    public override bool Load(XmlNode node)
    {
      string value = node.GetTagValue("health");
      if (value != null)
      {
        int test = 0;
        if (int.TryParse(value, out test))
          _health = test;
        else
          return false;
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement(ComponentName);
      writer.WriteValueTag("health", _health.ToString());
      writer.WriteEndElement();

      return true;
    }

  }
}