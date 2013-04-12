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
    private DrawMode _mode = DrawMode.ClosedPolygon;

    private ImageContent _image = null;

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
      OkuDrivers.Instance.Renderer.DrawMesh(_vertices.Positions, _vertices.TexCoords, _vertices.Colors, _vertices.Count, _mode, _image);
    }

    public Rectangle2f GetBoundingBox()
    {
      return _vertices.GetAABB();
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
        OkuManagers.Instance.Logger.LogError("There is no image with the id " + _imageId + "!");
        return false;
      }
      return _vertices.AfterLoad();
    }

  }
}
