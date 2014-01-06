using System;
using System.Collections.Generic;
using System.IO;
using OkuBase;
using OkuBase.Graphics;
using JSONator;

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
        // Pixel coordinates in image space
        int x = i % data.Width;
        int y = i / data.Width;

        // Tile coordinates
        //int tx = x / spriteWidth;
        //int ty = y / spriteHeight;

        // Tile index
        //int tileIndex = (ty * tilesX) + tx;
        int tileIndex = ((y / spriteHeight) * tilesX) + (x / spriteWidth);
        
        // Pixel coordinate in tile space
        //int tpx = i % spriteWidth;
        //int tpy = (i / data.Height) % spriteHeight;
        //int tpIndex = (tpy * spriteWidth) + tpx;
        int tpIndex = (((i / data.Height) % spriteHeight) * spriteWidth) + (i % spriteWidth);

        tilePixels[tileIndex][tpIndex] = pixels[i];
      }

      List<Image> result = new List<Image>();

      for (int i = 0; i < tilePixels.Length; i++)
      {
        data = ImageData.FromRaw(tilePixels[i], spriteWidth, spriteHeight);
        Image image = OkuManager.Instance.Graphics.NewImage(data);
        result.Add(image);
      }

      return result;
    }

    public static StringPairMap JSONObjectToMap(JSONObjectValue jsonObj)
    {
      StringPairMap result = new StringPairMap();

      foreach (string member in jsonObj.Names)
      {
        result.Add(member, jsonObj[member].ToString());
      }

      return result;
    }

  }
}
