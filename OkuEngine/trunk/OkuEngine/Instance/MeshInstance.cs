using System;

namespace OkuEngine
{
  public class MeshInstance : VisualInstance
  {
    private VertexContent _vertices = null;
    private MeshMode _mode = MeshMode.Quads;
    private ImageContent _texture = null;

    public MeshInstance()
    {
      _vertices = new VertexContent();
    }

    public MeshInstance(VertexContent vertices)
    {
      _vertices = vertices;
    }

    public MeshInstance(ImageContent texture)
    {
      _vertices = new VertexContent();
      _texture = texture;
    }

    public MeshInstance(VertexContent vertices, ImageContent texture)
    {
      _vertices = vertices;
      _texture = texture;
    }

    public MeshInstance(VertexContent vertices, ImageContent texture, MeshMode mode)
    {
      _vertices = vertices;
      _texture = texture;
      _mode = mode;
    }

    public VertexContent Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    public ImageContent Texture
    {
      get { return _texture; }
      set { _texture = value; }
    }

    public MeshMode Mode
    {
      get { return _mode; }
      set { _mode = value; }
    }

    public void Draw()
    {
      OkuDrivers.Renderer.DrawMesh(_vertices.Vertices, _mode, _texture);
    }

    public override void Draw(Matrix3 transform)
    {
      OkuDrivers.Renderer.DrawMesh(_vertices.Vertices, _mode, transform, _texture);
    }

    //TODO: static functions to create default geometry like quads, circles...


    
  }
}
