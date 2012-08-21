using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;
using OkuEngine.GCC.Resources;

namespace OkuEngine.GCC.Actors.Components
{
  public class ImageRenderComponent : RenderComponent
  {
    public const string RenderType = "image";

    public override bool Load(XmlNode node)
    {
      Color color = Color.White;

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "image":
            _imageName = child.FirstChild.Value;
            ResourceHandle handle = OkuData.ResourceCache.GetHandle(new Resource(_imageName));
            if (handle != null)
            {
              _image = new ImageContent((handle.Extras as TextureExtraData).Image);
            }
            else
            {
              OkuManagers.Logger.LogError("Image resource '" + _imageName + "' was not found!");
              return false;
            }
            break;

          case "color":
            Color col;
            if (Color.TryParse(child.FirstChild.Value, out col))
            {
              color = col;
            }
            else
            {
              OkuManagers.Logger.LogError("Color '" + child.FirstChild.Value + "' could not be parsed!");
            }
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      if (_image == null)
      {
        OkuManagers.Logger.LogError("Image resource '" + _imageName + "' was not found!");
        return false;
      }

      float halfWidth = _image.Width / 2.0f;
      float halfHeight = _image.Height / 2.0f;

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

    public override void Save(XmlWriter writer)
    {
      writer.WriteStartElement(ComponentName);

      writer.WriteStartAttribute("type");
      writer.WriteValue(RenderType);
      writer.WriteEndAttribute();

      writer.WriteStartElement("image");
      writer.WriteValue(_imageName);
      writer.WriteEndElement();

      if (!_colors[0].Equals(Color.White))
      {
        writer.WriteStartElement("color");
        writer.WriteValue(_colors[0].ToString());
        writer.WriteEndElement();
      }

      writer.WriteEndElement();
    }

  }
}
