using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.States
{
  /// <summary>
  /// The instance is created from the StateDefinition.CreateInstance() method.
  /// </summary>
  public class StateInstance : StateBase
  {
    /// <summary>
    /// Creates a new state instance. This should not be done
    /// directly but through the StateDefinition.CreateInstance() method.
    /// </summary>
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
            if (_components.ContainsKey(component.ComponentTypeName))
              _components[component.ComponentTypeName] = component;
            else
              _components.Add(component.ComponentTypeName, component);

            component.Owner = this;
          }
        }
        child = child.NextSibling;
      }
      
      return true;
    }
  }
}
