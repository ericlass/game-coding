using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using OkuBase.Geometry;
using OkuBase.Collections;

namespace RougeLike
{
  /// <summary>
  /// Batches sprite draw operations to draw them in one draw call.
  /// </summary>
  public class SpriteBatch
  {
    private struct BatchedSprite
    {
      public ImageBase Image;
      public Vector2f[] Vertices;
      public Vector2f[] TexCoords;
      public int Count;
    }

    private Dictionary<int, ImageBase> _images = new Dictionary<int,ImageBase>();
    private Dictionary<int, List<Vector2f>> _sprites = new Dictionary<int, List<Vector2f>>();
    private List<BatchedSprite> _batches = new List<BatchedSprite>();
    
    /// <summary>
    /// Creates a new sprite batch.
    /// </summary>
    public SpriteBatch()
    {            
    }

    /// <summary>
    /// Initializes the batching. Must be called once before adding sprites with the Add method.
    /// </summary>
    public void Begin()
    {
      _sprites.Clear();
      _batches.Clear();
    }

    /// <summary>
    /// Adds a new sprite to the batch with the given image and position.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    /// <param name="position">The position to draw at.</param>
    public void Add(ImageBase image, Vector2f position)
    {
      if (!_images.ContainsKey(image.Id))
        _images.Add(image.Id, image);

      List<Vector2f> spriteList;
      if (!_sprites.ContainsKey(image.Id))
      {
        spriteList = new List<Vector2f>();
        _sprites.Add(image.Id, spriteList);
      }
      else
        spriteList = _sprites[image.Id];

      spriteList.Add(position);
    }

    /// <summary>
    /// Finalizes the batching and create the final vertex buffers for drawing.
    /// </summary>
    public void End()
    {
      foreach (int imageId in _images.Keys)
      {
        ImageBase image = _images[imageId];
        List<Vector2f> positions = _sprites[imageId];

        Vector2f[] pos = new Vector2f[positions.Count * 4];
        Vector2f[] tex = new Vector2f[positions.Count * 4];

        for (int i = 0; i < positions.Count; i++)
        {
          int start = i * 4;
          Vector2f p = positions[i];

          float left = p.X;
          float bottom = p.Y;
          float right = left + image.Width;          
          float top = bottom + image.Height;          

          pos[start].X = left;
          pos[start].Y = bottom;

          pos[start + 1].X = left;
          pos[start + 1].Y = top;

          pos[start + 2].X = right;
          pos[start + 2].Y = top;

          pos[start + 3].X = right;
          pos[start + 3].Y = bottom;

          tex[start].X = 0;
          tex[start].Y = 0;

          tex[start + 1].X = 0;
          tex[start + 1].Y = 1;

          tex[start + 2].X = 1;
          tex[start + 2].Y = 1;

          tex[start + 3].X = 1;
          tex[start + 3].Y = 0;
        }

        BatchedSprite batch = new BatchedSprite();
        batch.Image = image;
        batch.Vertices = pos;
        batch.TexCoords = tex;
        batch.Count = positions.Count * 4;
        _batches.Add(batch);
      }
    }

    /// <summary>
    /// Finally draws the batches of sprites.
    /// </summary>
    public void Draw()
    {
      foreach (BatchedSprite batch in _batches)
        OkuBase.OkuManager.Instance.Graphics.DrawMesh(batch.Vertices, batch.TexCoords, null, batch.Count, PrimitiveType.Quads, batch.Image);
    }

  }
}
