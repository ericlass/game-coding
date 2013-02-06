using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.States
{
  /// <summary>
  /// A state definition defines the components for a state instance.
  /// </summary>  
  public class StateDefinition : StateBase
  {
    /// <summary>
    /// Creates a new instance of the state.
    /// </summary>
    /// <returns>A new state instance.</returns>
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
              OkuManagers.Logger.LogError("Trying to add a " + component.ComponentTypeName + " twice! " + node.OuterXml);
          }
          
        }
        child = child.NextSibling;
      }
      
      return true;
    }
    
  }
}
