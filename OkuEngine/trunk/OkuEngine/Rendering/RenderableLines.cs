﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Driver.Renderer;
using Newtonsoft.Json;

namespace OkuEngine.Rendering
{
  public class RenderableLines : IRenderable
  {
    private Vertices _vertices = null;
    private float _width = 1.0f;
    private bool _closed = true;

    /// <summary>
    /// Gets or sets the width of the line in pixels.
    /// </summary>
    [JsonPropertyAttribute]
    public float Width
    {
      get { return _width; }
      set { _width = value; }
    }

    /// <summary>
    /// Gets or sets of the line is closed by connection the last and first vertex.
    /// </summary>
    [JsonPropertyAttribute]
    public bool Closed
    {
      get { return _closed; }
      set { _closed = value; }
    }

    /// <summary>
    /// Gets or sets the vertices.
    /// </summary>
    [JsonPropertyAttribute]
    public Vertices Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    public void Update(float dt)
    {
      //Nothing to for lines
    }

    public void Render(Scene scene)
    {
      if (_closed)
        OkuManagers.Renderer.DrawLines(_vertices.Positions, _vertices.Colors, _vertices.Count, _width, VertexInterpretation.PolygonClosed);
      else
        OkuManagers.Renderer.DrawLines(_vertices.Positions, _vertices.Colors, _vertices.Count, _width, VertexInterpretation.Polygon);
    }

    public AABB GetBoundingBox()
    {
      return _vertices.GetAABB();
    }

    public bool Load(XmlNode node)
    {
      string value = node.GetTagValue("width");
      if (value != null)
      {
        float w = 0;
        if (Converter.TryStrToFloat(value, out w))
          _width = w;
        else
        {
          OkuManagers.Logger.LogError("Invalid number given for line width! " + node.OuterXml);
        }
      }

      value = node.GetTagValue("closed");
      if (value != null)
      {
        _closed = Converter.StrToBool(value, true);
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
      writer.WriteValue("line");
      writer.WriteEndAttribute();
      
      writer.WriteValueTag("width", Converter.FloatToString(_width));
      writer.WriteValueTag("closed", Converter.BoolToStr(_closed));
      if (!_vertices.Save(writer))
        return false;

      writer.WriteEndElement();

      return true;
    }

    public IRenderable Copy()
    {
      RenderableLines result = new RenderableLines();
      result._closed = _closed;
      result._vertices = _vertices.Copy();
      result._width = _width;
      return result;
    }

    public bool AfterLoad()
    {
      return _vertices.AfterLoad();
    }

  }
}
