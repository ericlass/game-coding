using System;
using System.Xml;
using OkuEngine.Scenes;

namespace OkuEngine.Rendering
{
  /// <summary>
  /// Description of RenderableBigImage.
  /// </summary>
  public class RenderableBigImage : IRenderable
  {
    private struct ImageTile
    {
      AABB BoundingBox;
      Vertices Vertices;

      public ImageTile(AABB boundingBox, Vertices vertices)
      {
        BoundingBox = boundingBox;
        Vertices = vertices;
      }
    }

    private int _imageId = 0;
    private ImageContent _image = null;
    private int _tileSize = 512;
    private Vector2f _offset = Vector2f.Zero;

    private ImageTile[,] _tiles = null;
    private AABB _boundingBox = new AABB();

    public RenderableBigImage()
    {
    }

    public RenderableBigImage(int tileSize)
    {
      _tileSize = tileSize;
    }
    
    public void Update(float dt)
    {
      throw new NotImplementedException();
    }
      
    public void Render(Scene scene)
    {
      //TODO: Find out which tiles to draw. Take into account centering!
    }
      
    public AABB GetBoundingBox()
    {
      return _boundingBox;
    }

    private void Init()
    {
      if (_image == null)
        throw new OkuException("RenderableBigImage.Init() was called although _image was null!");

      int vparts = (_image.Width / _tileSize) + 1;
      int hparts = (_image.Height / _tileSize) + 1;

      float halfWidth = _image.Width * 0.5f;
      float halfHeight = _image.Height * 0.5f;
      _boundingBox = new AABB(-halfWidth, -halfHeight, _image.Width, _image.Height);

      _tiles = new ImageTile[vparts, hparts];
      for (int y = 0; y < hparts; y++)
      {
        for (int x = 0; x < vparts; x++)
        {
          //Tile bounds in image space
          int left = x * _tileSize;
          int right = Math.Min(_image.Width, left + _tileSize);
          int bottom = y * _tileSize;
          int top = Math.Min(_image.Height, bottom + _tileSize);

          //Tile vertices in object space
          float vertLeft = left - halfWidth;
          float vertRight = right - halfWidth;
          float vertBottom = bottom - halfHeight;
          float vertTop = top - halfHeight;

          Vertices verts = new Vertices();
          verts.Positions = new Vector2f[] 
          {
            new Vector2f(vertLeft, vertBottom),
            new Vector2f(vertLeft, vertTop),
            new Vector2f(vertRight, vertTop),
            new Vector2f(vertRight, vertBottom)
          };

          //Tile texture coordinates
          float texLeft = _image.Width / (float)left;
          float texRight = _image.Width / (float)right;
          float texBottom = _image.Height / (float)bottom;
          float texTop = _image.Height / (float)top;

          verts.TexCoords = new Vector2f[]
          {
            new Vector2f(texLeft, texBottom),
            new Vector2f(texLeft, texTop),
            new Vector2f(texRight, texTop),
            new Vector2f(texRight, texBottom)
          };

          //Tile bounding box in object space
          AABB boundingBox = new AABB(vertLeft, vertBottom, vertRight - vertLeft, vertTop - vertBottom);

          _tiles[x, y] = new ImageTile(boundingBox, verts);
        }
      }
    }
      
    public bool Load(XmlNode node)
    {
      _imageId = 0;
      _image = null;

      string value = node.GetTagValue("image");
      if (value == null)
      {
        OkuManagers.Logger.LogError("No image specified for big image renderable! " + node.OuterXml);
        return false;
      }

      int test = 0;
      if (!int.TryParse(value, out test))
      {
        OkuManagers.Logger.LogError("Could not parse image id! " + node.OuterXml);
        return false;
      }

      _imageId = test;
      _image = OkuData.Images[_imageId];
      if (_image == null)
      {
        OkuManagers.Logger.LogError("Image with id " + _imageId + " does not exists! " + node.OuterXml);
        return false;
      }

      Init();
      return true;
    }
      
    public bool Save(XmlWriter writer)
    {
      writer.WriteValueTag("image", _imageId.ToString());
      return true;
    }

    public IRenderable Copy()
    {
      RenderableBigImage result = new RenderableBigImage();
      result._image = _image;
      result._imageId = _imageId;
      result._offset = _offset;
      result._tileSize = _tileSize;
      result.Init();
      return result;
    }

  }
}
