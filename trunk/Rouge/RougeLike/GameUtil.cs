using System;
using System.Collections.Generic;
using System.IO;
using OkuBase;
using OkuBase.Graphics;

namespace RougeLike
{
  public static class GameUtil
  {
    public static Animation LoadAnimation(string baseName)
    {
      // Load files that start with baseName and create animation for them
      string[] files = Directory.GetFiles(".\\Content\\Graphics", baseName + "*.png");
      Array.Sort(files);

      Animation result = new Animation();
      result.FrameTime = 100;
      result.Loop = true;

      foreach (string file in files)
      {
        ImageData data = ImageData.FromFile(file);
        Image image = OkuManager.Instance.Graphics.NewImage(data);
        result.Frames.Add(image);
      }

      return result;
    }

    public static List<Image> LoadSpriteSheet(string fileName, int spriteWidth, int spriteHeight)
    {
      string fullPath = Path.Combine(".\\Content\\Graphics", fileName);
      if (!File.Exists(fullPath))
        throw new OkuException("There is no file called " + fileName + " in the content folder!");

      ImageData data = ImageData.FromFile(fullPath);
      int[] pixels = data.PixelData;
      int tilesX = (data.Width / spriteWidth);
      int tilesY = (data.Height / spriteHeight);
      int numTiles = tilesX * tilesY;
      int tileLength = spriteWidth * spriteHeight;
      int[][] tilePixels = new int[numTiles][];

      for (int i = 0; i < numTiles; i++)
        tilePixels[i] = new int[tileLength];

      for (int i = 0; i < pixels.Length; i++)
      {
        int x = i % data.Width;
        int y = i / data.Width;

        int tx = x / spriteWidth;
        int ty = y / spriteHeight;
        int tileIndex = (ty * tilesX) + tx;


      }

      return null;
    }

  }
}
