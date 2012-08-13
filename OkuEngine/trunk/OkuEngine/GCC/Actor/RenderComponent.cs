using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;
using OkuEngine.GCC.Resources;

namespace OkuEngine.GCC.Actor
{
  public class RenderComponent : ActorComponent
  {
    public const int ComponentId = 2;
    public const string ComponentName = "renderable";

    private Vector[] _points = null;
    private Vector[] _texCoords = null;
    private Color[] _colors = null;
    private DrawMode _mode = DrawMode.None;
    private ImageContent _texture = null;
    private string _textureName = null;

    public Vector[] Points
    {
      get { return _points; }
      set { _points = value; }
    }

    public Vector[] TexCoords
    {
      get { return _texCoords; }
      set { _texCoords = value; }
    }

    public Color[] Colors
    {
      get { return _colors; }
      set { _colors = value; }
    }

    public DrawMode Mode
    {
      get { return _mode; }
      set { _mode = value; }
    }

    public ImageContent Texture
    {
      get { return _texture; }
      set { _texture = value; }
    }

    public override int GetComponentId()
    {
      return ComponentId;
    }

    public override void Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
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
            _mode = Converter.ParseDrawMode(child.FirstChild.Value);
            break;

          case "image":
            _textureName = child.FirstChild.Value;
            ResourceHandle handle = OkuData.ResourceCache.GetHandle(new Resource(_textureName));
            if (handle != null)
            {
              _texture = new ImageContent((handle.Extras as TextureExtraData).Image);
            }
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }
    }

    public override void Save(XmlWriter writer)
    {
      writer.WriteStartElement(ComponentName);

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

      if (_textureName != null)
      {
        writer.WriteStartElement("image");
        writer.WriteValue(_textureName);
        writer.WriteEndElement();
      }

      writer.WriteEndElement();
    }

  }
}
