using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;
using OkuEngine.Resources;

namespace OkuEngine.Actors.Components
{
  public class ImageRenderComponent : RenderComponent
  {
    public const string RenderType = "image";

    public override bool Load(XmlNode node)
    {
      Color color = Color.White;

      string value = node.GetTagValue("image");
      if (value != null)
      {
        int test = 0;
        if (int.TryParse(value, out test))
          _image = test;
      }
      else
      {
        OkuManagers.Logger.LogError("No image given for image render component!");
        return false;
      }

      value = node.GetTagValue("color");
      if (value != null)
      {
        Color col;
        if (Color.TryParse(value, out col))
          color = col;
        else
          OkuManagers.Logger.LogError("Color '" + value + "' could not be parsed!");
      }

      ImageContent image = OkuData.Images[_image];

      if (image == null)
      {
        OkuManagers.Logger.LogError("Image with id '" + _image + "' was not found!");
        return false;
      }

      float halfWidth = image.Width / 2.0f;
      float halfHeight = image.Height / 2.0f;

      _points = new Vector[4];
      _texCoords = new Vector[4];
      _colors = new Color[4];

      _points[0] = new Vector(-halfWidth, halfHeight);
      _points[1] = new Vector(halfWidth, halfHeight);
      _points[2] = new Vector(halfWidth, -halfHeight);
      _points[3] = new Vector(-halfWidth, -halfHeight);

      _texCoords[0] = new Vector(0, 1);
      _texCoords[1] = new Vector(1, 1);
      _texCoords[2] = new Vector(1, 0);
      _texCoords[3] = new Vector(0, 0);

      _colors[0] = color;
      _colors[1] = color;
      _colors[2] = color;
      _colors[3] = color;

      _mode = DrawMode.Quads;

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement(ComponentName);

      writer.WriteValueTag("type", RenderType);
      writer.WriteValueTag("image", _image.ToString());

      if (!_colors[0].Equals(Color.White))
        writer.WriteValueTag("color", _colors[0].ToString());

      writer.WriteEndElement();

      return true;
    }

    public override bool PreRender()
    {
      return true;
    }

    public override bool PostRender()
    {
      return true;
    }

  }
}
