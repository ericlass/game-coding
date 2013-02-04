using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.States
{
  // A state definition defines the components for a state instance
  // This is what the actor state stores now
  public class StateDefinition : StateBase
  {
    public StateInstance CreateInstance()
    {
      StateInstance result = new StateInstance();
      result.SetName(_name);
      foreach (KeyValuePair<string, IStateComponent> item in _components)
      {
        result.Add(item.Value.Copy());
      }
      return result;
    }

    public override bool Load(XmlNode node)
    {
      _components.Clear();

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
            //A state definition will not load duplicate components
            if (Add(component))
            {
              component.Owner = this;
            }
            else
              ;//TODO: Log
          }
          else
            ;//TODO: Log
          
        }
        child = child.NextSibling;
      }
      
      return true;
    }
    
  }
}
