using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;
using OkuEngine.Resources;

namespace OkuEngine.Actors.Components
{
  public class MeshRenderComponent : RenderComponent
  {
    public const string RenderType = "mesh";

    public override bool Load(XmlNode node)
    {
      string value = node.GetTagValue("points");
      if (value != null)
        _points = Converter.ParseVectors(value);

      value = node.GetTagValue("texcoords");
      if (value != null)
        _texCoords = Converter.ParseVectors(value);

      value = node.GetTagValue("colors");
      if (value != null)
        _colors = Converter.ParseColors(value);

      value = node.GetTagValue("mode");
      if (value != null)
        _mode = Converter.ParseEnum<DrawMode>(value);

      _imageName = node.GetTagValue("image");
      if (_imageName != null)
      {
        _points = Converter.ParseVectors(value);
        ResourceHandle handle = OkuData.ResourceCache.GetHandle(new Resource(_imageName));
        if (handle != null)
          _image = new ImageContent((handle.Extras as TextureExtraData).Image);
        else
          OkuManagers.Logger.LogError("Image resource '" + _imageName + "' was not found!");
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

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement(ComponentName);

      writer.WriteValueTag("type", RenderType);

      if (_points != null)
        writer.WriteValueTag("points", _points.ToOkuString());

      if (_texCoords != null)
        writer.WriteValueTag("texcoords", _texCoords.ToOkuString());

      if (_colors != null)
        writer.WriteValueTag("colors", _colors.ToOkuString());

      writer.WriteValueTag("mode", _mode.ToString());

      if (_imageName != null)
        writer.WriteValueTag("image", _imageName);

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
