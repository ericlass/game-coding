using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.States;
using OkuEngine.Rendering;

namespace OkuEngine.Actors
{
  public class RenderableStateComponent : IStateComponent
  {
    private StateBase _owner = null;
    private IRenderable _renderable = null;

    public StateBase Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public IRenderable Renderable
    {
      get { return _renderable; }
      set { _renderable = value; }
    }

    public string ComponentName
    {
      get { return Actor.ActorStateRenderableComponentName; }
    }

    public IStateComponent Copy()
    {
      RenderableStateComponent result = new RenderableStateComponent();
      result.Renderable = _renderable.Copy();
      return result;
    }

    public bool Load(XmlNode node)
    {
      _renderable = RenderableFactory.Instance.CreateRenderable(node);
      return _renderable != null;
    }

    public bool Save(XmlWriter writer)
    {
      return _renderable.Save(writer);
    }

  }
}
