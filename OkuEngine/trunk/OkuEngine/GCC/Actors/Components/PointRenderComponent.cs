using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;

namespace OkuEngine.GCC.Actors.Components
{
  public class PointRenderComponent : RenderComponent
  {
    public const string RenderType = "point";

    public override bool Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (node != null)
      {
        switch (child.Name.ToLower())
        {
          case "points":
            _points = Converter.ParseVectors(child.FirstChild.Value);
            break;

          case "colors":
            _colors = Converter.ParseColors(child.FirstChild.Value);
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      if (_points == null)
      {
        OkuManagers.Logger.LogError("Point render component is missing points!");
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

      _mode = DrawMode.Points;

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

      writer.WriteEndElement();
    }

  }
}
