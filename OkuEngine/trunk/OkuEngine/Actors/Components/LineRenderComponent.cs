using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;

namespace OkuEngine.Actors.Components
{
  public class LineRenderComponent : RenderComponent
  {
    public const string RenderType = "line";

    private float _lineWidth = 1.0f;

    public override bool Load(XmlNode node)
    {
      bool closed = false;

      string value = node.GetTagValue("points");
      if (value != null)
        _points = Converter.ParseVectors(value);

      value = node.GetTagValue("colors");
      if (value != null)
        _colors = Converter.ParseColors(value);

      value = node.GetTagValue("closed");
      if (value != null)
        closed = Converter.StrToBool(value, false);

      value = node.GetTagValue("width");
      if (value != null)
        _lineWidth = Converter.StrToFloat(value);

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

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement(ComponentName);

      writer.WriteValueTag("type", RenderType);

      if (_points != null)
        writer.WriteValueTag("points", _points.ToOkuString());

      if (_colors != null)
        writer.WriteValueTag("colors", _colors.ToOkuString());

      if (_mode == DrawMode.ClosedPolygon)
        writer.WriteValueTag("closed", Converter.BoolToStr(true));

      if (_lineWidth != 1.0f)
        writer.WriteValueTag("width", Converter.FloatToString(_lineWidth));

      writer.WriteEndElement();

      return true;
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
