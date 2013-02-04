using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.States
{
  // The instance is created from the StateDefinition.CreateInstance() method
  // This is what is stored in the actors
  public class StateInstance : StateBase
  {
    public StateInstance()
    {
    }

    public override bool Load(XmlNode node)
    {
      // NEVER CLEAR COMPONENTS HERE AS THEY MIGHT BE PRE-FILLED BY CreateInstance()!!!

      if (!base.Load(node))
        return false;

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        if (child.NodeType == XmlNodeType.Element)
        {
          IStateComponent component = StateComponentFactory.Instance.CreateComponent(child);
          if (component != null)
          {
            // A state instance can override the components of a state definition
            if (_components.ContainsKey(component.ComponentName))
              _components[component.ComponentName] = component;
            else
              _components.Add(component.ComponentName, component);

            component.Owner = this;
          }
          else
            ; //TODO: Log
        }
        child = child.NextSibling;
      }
      
      return true;
    }
  }
}
