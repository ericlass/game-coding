using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Components;

namespace OkuEngine.Actors
{
  public class ActorType : StoreableEntity
  {
    private XmlNode _actorTypeNode = null; //XmlNode containing complete actor type config
    private List<XmlNode> _componentNodes = null; //XmlNode for each component by component id

    internal List<XmlNode> ComponentNodes
    {
      get { return _componentNodes; }
    }

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      _actorTypeNode = node;
      

      XmlNode componentsNode = node["components"];
      if (componentsNode != null)
      {
        if (_componentNodes == null)
          _componentNodes = new List<XmlNode>();
        else
          _componentNodes.Clear();

        XmlNode child = componentsNode.FirstChild;
        while (child != null)
        {
          int id = OkuManagers.ComponentFactory.GetComponentId(child);
          if (id > 0)
          {
            _componentNodes.Add(child);
          }
          else
          {
            OkuManagers.Logger.LogError("Actortype " + _name + " specifies an unknown component ! " + child.OuterXml);
          }

          child = child.NextSibling;
        }
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("actortype");

      if (!base.Save(writer))
        return false;

      writer.WriteStartElement("components");
      foreach (XmlNode comp in _componentNodes)
      {
        comp.WriteTo(writer);
      }
      writer.WriteEndElement();

      writer.WriteEndElement();

      return true;
    }

  }
}
