using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Driver.Renderer;
using Newtonsoft.Json;

namespace OkuEngine.Rendering
{
  public class RenderableMesh : IRenderable
  {
    private Vertices _vertices = null;
    private int _imageId = 0;
    private ImageContent _image = null;
    private DrawMode _mode = DrawMode.ClosedPolygon;

    [JsonPropertyAttribute]
    public int ImageId
    {
      get { return _imageId; }
      set { _imageId = value; }
    }

    [JsonPropertyAttribute]
    public DrawMode Mode
    {
      get { return _mode; }
      set { _mode = value; }
    }

    [JsonPropertyAttribute]
    public Vertices Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    public void Update(float dt)
    {
      //Nothing to do for mesh
    }

    public void Render(Scene scene)
    {
      OkuManagers.Renderer.DrawMesh(_vertices.Positions, _vertices.TexCoords, _vertices.Colors, _vertices.Count, _mode, _image);
    }

    public AABB GetBoundingBox()
    {
      return _vertices.GetAABB();
    }

    public bool Load(XmlNode node)
    {
      string value = node.GetTagValue("image");
      if (value != null)
      {
        _imageId = 0;
        if (int.TryParse(value, out _imageId))
        {
          _image = OkuData.Instance.Images[_imageId];
          if (_image == null)
          {
            OkuManagers.Logger.LogError("There is no image with the id " + _imageId + "! " + node.OuterXml);
            return false;
          }
        }
        else
        {
          OkuManagers.Logger.LogError("The image id " + _imageId + " is not a valid number! " + node.OuterXml);
          return false;
        }
      }
      else
      {
        OkuManagers.Logger.LogError("No image given for mesh! " + node.OuterXml);
        return false;
      }

      XmlNode vertexNode = node["vertices"];
      if (vertexNode != null)
      {
        _vertices = new Vertices();
        if (!_vertices.Load(vertexNode))
        {
          OkuManagers.Logger.LogError("Vertices for mesh could not be loaded! " + node.OuterXml);
          return false;
        }
      }

      _mode = Converter.ParseEnum<DrawMode>(node.GetTagValue("mode"));

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("renderable");

      writer.WriteStartAttribute("type");
      writer.WriteValue("mesh");
      writer.WriteEndAttribute();

      writer.WriteValueTag("image", _imageId.ToString());
      writer.WriteValueTag("mode", _mode.ToString());

      if (!_vertices.Save(writer))
        return false;

      writer.WriteEndElement();

      return true;
    }

    public IRenderable Copy()
    {
      RenderableMesh result = new RenderableMesh();
      result._image = _image;
      result._imageId = _imageId;
      result._mode = _mode;
      result._vertices = _vertices.Copy();
      return result;
    }

    public bool AfterLoad()
    {
      _image = OkuData.Instance.Images[_imageId];
      if (_image == null)
      {
        OkuManagers.Logger.LogError("There is no image with the id " + _imageId + "!");
        return false;
      }
      return _vertices.AfterLoad();
    }

  }
}
