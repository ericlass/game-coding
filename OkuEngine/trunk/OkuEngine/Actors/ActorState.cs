using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Attributes;
using OkuEngine.Rendering;
using OkuEngine.States;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a single state of an actor.
  /// </summary>
  public class ActorState : EntityState
  {
    private InheritingRenderable _renderable = new InheritingRenderable();

    /// <summary>
    /// Gets the renderable of the state.
    /// </summary>
    public InheritingRenderable Renderable
    {
      get { return _renderable; }
    }

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      XmlNode renderNode = node["renderable"];
      if (renderNode != null)
      {
        IRenderable renderable = RenderableFactory.Instance.CreateRenderable(renderNode);
        if (renderable != null)
        {
          _renderable = new InheritingRenderable();
          _renderable.Renderable = renderable;
        }
        else
          return false;
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("state");

      if (!base.Save(writer))
        return false;

      if (_renderable != null && _renderable.Renderable != null)
        _renderable.Renderable.Save(writer);

      writer.WriteEndElement();

      return true;
    }

  }
}
