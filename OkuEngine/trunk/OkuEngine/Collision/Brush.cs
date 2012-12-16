﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Rendering;

namespace OkuEngine.Collision
{
  /// <summary>
  /// Defines a static piece of level geometry with collision information
  /// and an optional renderable.
  /// </summary>
  public class Brush : SceneObject
  {
    private IRenderable _renderable = null;
    private AABB _boundingBox = new AABB();
    private Vector[] _shape = null;

    /// <summary>
    /// Create a new brush.
    /// </summary>
    public Brush()
    {
    }

    /// <summary>
    /// Gets the bounding box of the brush.
    /// </summary>
    public override AABB BoundingBox
    {
      get { return _boundingBox; }
    }

    /// <summary>
    /// Gets the shape of the brush. Can be null if only AABB is specified.
    /// </summary>
    public override Vector[] Shape
    {
      get { return _shape; }
    }

    /// <summary>
    /// Gets if the brush is static or not, so it always returns true.
    /// </summary>
    public override bool IsStatic
    {
      get { return true; }
    }

    /// <summary>
    /// Renders the brushes renderable if there is any using the given scene.
    /// </summary>
    /// <param name="scene">The scene to be used.</param>
    public override void Render(Scene scene)
    {
      if (_renderable != null)
        _renderable.Render(scene);
    }

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      XmlNode renderNode = node["renderable"];
      if (renderNode != null)
      {
        _renderable = RenderableFactory.Instance.CreateRenderable(renderNode);
        if (_renderable == null)
        {
          OkuManagers.Logger.LogError("Renderable for brush " + Id + " could not be loaded! " + renderNode.OuterXml);
          return false;
        }
      }

      string shape = node.GetTagValue("shape");
      if (shape != null)
      {
        _shape = Converter.ParseVectors(shape);
      }

      if (_shape != null)
      {
        _boundingBox = _shape.BoundingBox();
      }
      else
      {
        if (_renderable != null)
          _boundingBox = _renderable.GetBoundingBox();
        else
        {
          OkuManagers.Logger.LogError("Brush " + Id + " does not have a renderable or shape! " + node.OuterXml);
          return false;
        }
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("brush");

      if (!base.Save(writer))
        return false;

      if (_renderable != null)
        _renderable.Save(writer);

      if (_shape != null)
        writer.WriteValueTag("shape", _shape.ToOkuString());

      writer.WriteEndElement();

      return true;
    }

  }
}
