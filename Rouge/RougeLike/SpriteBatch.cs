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
      public Vector2f Position;
      public Color Tint;

      public BatchedSprite(Vector2f pos, Color tint)
      {
        Position = pos;
        Tint = tint;
      }
    }

    private struct CompiledBatch
    {
      public ImageBase Image;
      public Vector2f[] Vertices;
      public Vector2f[] TexCoords;
      public Color[] Colors;
      public int Count;
    }

    private const int MaxVertices = 16000;

    private Dictionary<int, ImageBase> _images = new Dictionary<int,ImageBase>();
    private Dictionary<int, List<BatchedSprite>> _sprites = new Dictionary<int, List<BatchedSprite>>();
    private List<CompiledBatch> _batches = new List<CompiledBatch>();

    private Vector2f[] pos = null;
    private Vector2f[] tex = null;
    private Color[] colors = null;
    
    /// <summary>
    /// Creates a new sprite batch.
    /// </summary>
    public SpriteBatch()
    {
      pos = new Vector2f[MaxVertices];
      tex = new Vector2f[MaxVertices];
      colors = new Color[MaxVertices];
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
    /// <param name="tint">The tint color for the sprite.</param>
    public void Add(ImageBase image, Vector2f position, Color tint)
    {
      if (!_images.ContainsKey(image.Id))
        _images.Add(image.Id, image);

      List<BatchedSprite> spriteList;
      if (!_sprites.ContainsKey(image.Id))
      {
        spriteList = new List<BatchedSprite>();
        _sprites.Add(image.Id, spriteList);
      }
      else
        spriteList = _sprites[image.Id];

      spriteList.Add(new BatchedSprite(position, tint));
    }

    /// <summary>
    /// Adds a new sprite to the batch with the given image and position.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    /// <param name="position">The position to draw at.</param>
    public void Add(ImageBase image, Vector2f position)
    {
      Add(image, position, Color.White);
    }

    /// <summary>
    /// Finalizes the batching and create the final vertex buffers for drawing.
    /// </summary>
    public void End()
    {
      foreach (int imageId in _images.Keys)
      {
        ImageBase image = _images[imageId];
        List<BatchedSprite> sprites = _sprites[imageId];

        for (int i = 0; i < sprites.Count; i++)
        {
          int start = i * 4;
          BatchedSprite spr = sprites[i];

          float left = spr.Position.X - (image.Width / 2);
          float bottom = spr.Position.Y - (image.Height / 2);
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

          Color col = spr.Tint;
          colors[start] = col;
          colors[start + 1] = col;
          colors[start + 2] = col;
          colors[start + 3] = col;
        }

        CompiledBatch batch = new CompiledBatch();
        batch.Image = image;
        batch.Vertices = pos;
        batch.TexCoords = tex;
        batch.Count = sprites.Count * 4;
        batch.Colors = colors;
        _batches.Add(batch);
      }
    }

    /// <summary>
    /// Finally draws the batches of sprites.
    /// </summary>
    public void Draw()
    {
      foreach (CompiledBatch batch in _batches)
        OkuBase.OkuManager.Instance.Graphics.DrawMesh(batch.Vertices, batch.TexCoords, batch.Colors, batch.Count, PrimitiveType.Quads, batch.Image);
    }

  }
}
