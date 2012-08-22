using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;

namespace OkuEngine.GCC.Actors.Components
{
  public class LineRenderComponent : RenderComponent
  {
    public const string RenderType = "line";

    private float _lineWidth = 1.0f;

    public override bool Load(XmlNode node)
    {
      bool closed = false;

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "points":
            _points = Converter.ParseVectors(child.FirstChild.Value);
            break;

          case "colors":
            _colors = Converter.ParseColors(child.FirstChild.Value);
            break;

          case "closed":
            closed = Converter.StrToBool(child.FirstChild.Value, false);
            break;

          case "width":
            _lineWidth = Converter.StrToFloat(child.FirstChild.Value);
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      if (_points == null)
      {
        OkuManagers.Logger.LogError("Line render component is missing points!");
        return false;
      }

      if (_colors == null)
      {
        _colors = new Color[_points.Length];
        for (int i = 0; i < _colors.Length; i++)
        {
          _colors[i] = Color.Black;
        }
      }

      if (closed)
        _mode = DrawMode.ClosedPolygon;
      else
        _mode = DrawMode.Polygon;

      return true;
    }

    public override void Save(XmlWriter writer)
    {
      writer.WriteStartElement(ComponentName);

      writer.WriteStartAttribute("type");
      writer.WriteValue(RenderType);
      writer.WriteEndAttribute();

      if (_points != null)
      {
        writer.WriteStartElement("points");
        writer.WriteValue(_points.ToOkuString());
        writer.WriteEndElement();
      }

      if (_colors != null)
      {
        writer.WriteStartElement("colors");
        writer.WriteValue(_colors.ToOkuString());
        writer.WriteEndElement();
      }

      if (_mode == DrawMode.ClosedPolygon)
      {
        writer.WriteStartElement("closed");
        writer.WriteValue(Converter.BoolToStr(true));
        writer.WriteEndElement();
      }

      if (_lineWidth != 1.0f)
      {
        writer.WriteStartElement("width");
        writer.WriteValue(Converter.FloatToString(_lineWidth));
        writer.WriteEndElement();
      }

      writer.WriteEndElement();
    }

    public override bool PreRender()
    {
      OkuManagers.Renderer.SetLineWidth(_lineWidth);
      return true;
    }

    public override bool PostRender()
    {
      return true;
    }

  }
}
