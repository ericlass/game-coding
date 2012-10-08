using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;

namespace OkuEngine.Components
{
  public class PointRenderComponent : RenderComponent
  {
    public const string RenderType = "point";

    private float _pointSize = 1.0f;

    public override bool Load(XmlNode node)
    {
      string value = node.GetTagValue("points");
      if (value != null)
        _points = Converter.ParseVectors(value);

      value = node.GetTagValue("colors");
      if (value != null)
        _colors = Converter.ParseColors(value);

      value = node.GetTagValue("size");
      if (value != null)
        _pointSize = Converter.StrToFloat(value);

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

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement(ComponentName);

      writer.WriteValueTag("type", RenderType);

      if (_points != null)
        writer.WriteValueTag("points", _points.ToOkuString());

      if (_colors != null)
        writer.WriteValueTag("colors", _colors.ToOkuString());

      if (_pointSize != 1.0f)
        writer.WriteValueTag("size", Converter.FloatToString(_pointSize));

      writer.WriteEndElement();

      return true;
    }

    public override bool PreRender()
    {
      OkuManagers.Renderer.SetPointSize(_pointSize);
      return true;
    }

    public override bool PostRender()
    {
      return true;
    }

  }
}
