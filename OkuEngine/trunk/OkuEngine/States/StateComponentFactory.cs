using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Actors;

namespace OkuEngine.States
{
  public class StateComponentFactory
  {
    private static StateComponentFactory _instance = null;

    public static StateComponentFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new StateComponentFactory();
        return _instance;
      }
    }

    public delegate IStateComponent CreateStateComponentDelegate();

    private Dictionary<string, CreateStateComponentDelegate> _creators = new Dictionary<string, CreateStateComponentDelegate>();

    private StateComponentFactory()
    {
      _creators.Add(Actor.ActorStateRenderableComponentName, CreateRenderable);
      _creators.Add(Actor.ActorStateAttributeComponentName, CreateAttribute);
      _creators.Add(Actor.ActorStateShapeComponentName, CreateShape);
      _creators.Add(Actor.ActorStateAABBComponentName, CreateAABB);
    }

    public IStateComponent CreateComponent(XmlNode node)
    {
      string name = node.Name.Trim().ToLower();
      if (!_creators.ContainsKey(name))
      {
        OkuManagers.Logger.LogError("Unknown state component \"" + name + "\"! " + node.OuterXml);
        return null;
      }

      IStateComponent component = _creators[name]();
      if (!component.Load(node))
      {
        OkuManagers.Logger.LogError("Could not load state component! " + node.OuterXml);
        return null;
      }

      return component;
    }

    public IStateComponent CreateRenderable()
    {
      return new RenderableStateComponent();
    }

    public IStateComponent CreateAttribute()
    {
      return new AttributeStateComponent();
    }

    public IStateComponent CreateShape()
    {
      return new ShapeStateComponent();
    }

    public IStateComponent CreateAABB()
    {
      return new AABBStateComponent();
    }

  }
}
