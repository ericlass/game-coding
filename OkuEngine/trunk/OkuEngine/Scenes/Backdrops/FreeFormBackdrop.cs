﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Geometry;
using OkuEngine.Rendering;

namespace OkuEngine.Scenes.Backdrops
{
  public class FreeFormBackdrop : Backdrop
  {
    private const int MaxImageDimensions = 1024;
    private const int ImageSliceSize = 256;

    private Vector2f _offset = Vector2f.Zero;
    private ImageContent _image = null;
    private Polygon[] _shapes = null;
    
    private RegularGrid _grid = null;
    private Dictionary<Vector2i, Vertices> _sliceData = new Dictionary<Vector2i, Vertices>();

    public override Polygon[] Shapes
    {
      get { return _shapes; }
    }

    public override void Update(float dt)
    {      
    }

    public override void Render(Scene scene)
    {
      Vector2i min = Vector2i.Zero;
      Vector2i max = Vector2i.Zero;

      AABB viewportBox = scene.Viewport.GetBoundingBox();

      _grid.GetCellsIntersecting(viewportBox, ref min, ref max);
      for (int y = min.Y; y <= max.Y; y++)
      {
        for (int x = min.X; x <= max.X; x++)
        {
          Vector2i index = new Vector2i(x, y);
          if (_sliceData.ContainsKey(index))
          {
            Vertices verts = _sliceData[index];
            OkuManagers.Renderer.DrawMesh(verts.Positions, verts.TexCoords, verts.Colors, verts.Positions.Length, OkuEngine.Driver.Renderer.DrawMode.Quads, _image);
            OkuManagers.Renderer.SetPointSize(2.0f);
            OkuManagers.Renderer.DrawMesh(verts.Positions, null, verts.Colors, verts.Positions.Length, OkuEngine.Driver.Renderer.DrawMode.ClosedPolygon, null);
            OkuManagers.Renderer.DrawPoint(Vector2f.Zero, 2.0f, Color.Red);
          }
        }
      }
    }

    private void InitializeSlices()
    {
      _sliceData.Clear();
      if (_image.Width > MaxImageDimensions || _image.Height > MaxImageDimensions)
      {
        _grid = new RegularGrid(_image.Width, _image.Height, ImageSliceSize);
        _grid.Centered = true;

        Vector2i minCell = _grid.GetMinCell();
        Vector2i maxCell = _grid.GetMaxCell();

        AABB cellBounds;
        for (int y = minCell.Y; y <= maxCell.Y; y++)
        {
          for (int x = minCell.X; x <= maxCell.X; x++)
          {
            _grid.GetCellBounds(x, y, true, out cellBounds);
            Vector2f[] points = AABB.GetPoints(cellBounds.Min, cellBounds.Max);
            Vector2f[] texCoords = AABB.GetPoints(cellBounds.Min, cellBounds.Max);
            for (int i = 0; i < texCoords.Length; i++)
            {
              Vector2f texCoord = texCoords[i];
              texCoord.X = (texCoord.X - _grid.Left) / _grid.Width;
              texCoord.Y = (texCoord.Y - _grid.Bottom) / _grid.Height;
              texCoords[i] = texCoord;
            }
            Color[] colors = new Color[] { Color.White, Color.White, Color.White, Color.White };

            Vertices verts = new Vertices(points, texCoords, colors);
            _sliceData.Add(new Vector2i(x, y), verts);
          }
        }
      }
    }

    public override bool Load(XmlNode node)
    {
      string value = node.GetTagValue("offset");
      if (value != null)
      {
        if (!Vector2f.TryParse(value, ref _offset))
        {
          OkuManagers.Logger.LogError("Could not parse offset for backdrop! " + node.OuterXml);
          return false;
        }
      }

      value = node.GetTagValue("image");
      if (value != null)
      {
        int imageId = 0;
        if (!int.TryParse(value, out imageId))
        {
          OkuManagers.Logger.LogError("Could not parse image for backdrop! " + node.OuterXml);
          return false;
        }

        _image = OkuData.Images[imageId];
        if (_image == null)
        {
          OkuManagers.Logger.LogError("Could not find image with id " + imageId + "! " + node.OuterXml);
          return false;
        }
      }
      else
      {
        OkuManagers.Logger.LogError("No image specified for backdrop! " + node.OuterXml);
        return false;
      }

      XmlNode shapesNode = node["shapes"];
      if (shapesNode != null)
      {
        List<Polygon> shapes = new List<Polygon>();
        XmlNode polyNode = shapesNode.FirstChild;
        while (polyNode != null)
        {
          if (polyNode.NodeType == XmlNodeType.Element && polyNode.Name.Trim().ToLower() == "polygon")
          {
            Polygon poly = new Polygon();
            if (!poly.Load(polyNode))
              return false;
            shapes.Add(poly);
          }

          polyNode = polyNode.NextSibling;
        }
        _shapes = shapes.ToArray();
      }

      if (_shapes == null || _shapes.Length == 0 || _image == null)
      {
        OkuManagers.Logger.LogError("FreeFormBackdrop has no shape and no image! " + node.OuterXml);
      }

      InitializeSlices();
      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      throw new NotImplementedException();
    }
  }
}
