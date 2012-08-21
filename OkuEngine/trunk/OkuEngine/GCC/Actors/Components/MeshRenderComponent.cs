using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;
using OkuEngine.GCC.Resources;

namespace OkuEngine.GCC.Actors.Components
{
  public class MeshRenderComponent : RenderComponent
  {
    public const string RenderType = "mesh";

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

          case "texcoords":
            _texCoords = Converter.ParseVectors(child.FirstChild.Value);
            break;

          case "colors":
            _colors = Converter.ParseColors(child.FirstChild.Value);
            break;

          case "mode":
            _mode = Converter.ParseEnum<DrawMode>(child.FirstChild.Value);
            break;

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
            }
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      if (_points == null)
      {
        OkuManagers.Logger.LogError("Mesh render component is missing points!");
        return false;
      }

      if ((_texCoords != null && _image == null) || (_texCoords == null && _image != null))
      {
        OkuManagers.Logger.LogError("texcoords and image should be both set or both missing in a mesh render component!");
      }

      if (_mode == DrawMode.None)
      {
        OkuManagers.Logger.LogError("Mesh render component is missing mode!");
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

      if (_texCoords != null)
      {
        writer.WriteStartElement("texcoords");
        writer.WriteValue(_texCoords.ToOkuString());
        writer.WriteEndElement();
      }

      if (_colors != null)
      {
        writer.WriteStartElement("colors");
        writer.WriteValue(_colors.ToOkuString());
        writer.WriteEndElement();
      }

      writer.WriteStartElement("mode");
      writer.WriteValue(_mode.ToString());
      writer.WriteEndElement();

      if (_imageName != null)
      {
        writer.WriteStartElement("image");
        writer.WriteValue(_imageName);
        writer.WriteEndElement();
      }

      writer.WriteEndElement();
    }
  }
}
