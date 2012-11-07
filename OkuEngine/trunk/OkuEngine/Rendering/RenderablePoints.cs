﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;

namespace OkuEngine.Rendering
{
  public class RenderablePoints : IRenderable
  {
    private Vertices _vertices = null;
    private float _size = 2.0f;

    public void Update(float dt)
    {
      //Nothing to do for points
    }

    public void Render(Scene scene)
    {
      OkuManagers.Renderer.DrawPoints(_vertices.Positions, _vertices.Colors, _vertices.Count, _size);
    }

    public bool Load(XmlNode node)
    {
      string value = node.GetTagValue("size");
      if (value != null)
      {
        float size = 0;
        if (Converter.TryStrToFloat(value, out size))
          _size = size;
        else
        {
          OkuManagers.Logger.LogError("Invalid number given for point size! " + node.OuterXml);
        }
      }

      XmlNode vertexNode = node["vertices"];
      if (vertexNode != null)
      {
        _vertices = new Vertices();
        if (!_vertices.Load(vertexNode))
        {
          OkuManagers.Logger.LogError("Vertices for line renderable could not be loaded! " + node.OuterXml);
          return false;
        }
      }

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("renderable");

      writer.WriteStartAttribute("type");
      writer.WriteValue("point");
      writer.WriteEndAttribute();

      if (!_vertices.Save(writer))
        return false;

      writer.WriteEndElement();

      return true;
    }

  }
}