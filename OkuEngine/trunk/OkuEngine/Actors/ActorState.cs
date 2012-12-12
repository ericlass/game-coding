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
    private Vector[] _shape = null;
    private AABB _boundingBox = new AABB();

    /// <summary>
    /// Gets the renderable of the state.
    /// </summary>
    public InheritingRenderable Renderable
    {
      get { return _renderable; }
    }

    /// <summary>
    /// Gets the shape associated with the actor state.
    /// </summary>
    public Vector[] Shape
    {
      get { return _shape; }
    }

    /// <summary>
    /// Gets the bounding box of the actor state.
    /// </summary>
    public AABB BoundingBox
    {
      get { return _boundingBox; }
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

      string shape = node.GetTagValue("shape");
      if (shape != null)
      {
        _shape = Converter.ParseVectors(shape);
      }

      if (_shape != null)
        _boundingBox = _shape.BoundingBox();
      else
      {
        if (_renderable != null)
        {
          _boundingBox = _renderable.InheritedAABB();
        }
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

      if (_shape != null)
        writer.WriteValueTag("shape", _shape.ToOkuString());

      writer.WriteEndElement();

      return true;
    }

  }
}
