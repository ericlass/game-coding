using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

    public static ImageBase LoadImage(string fileName)
    {
      string fullPath = Path.Combine(".\\Content\\Graphics", fileName);
      if (!File.Exists(fullPath))
        throw new OkuException("There is no file called " + fileName + " in the content folder!");

      ImageData data = ImageData.FromFile(fullPath);
      Image image = OkuManager.Instance.Graphics.NewImage(data);

      return image;
    }

    public static List<ImageBase> LoadSpriteSheet(string fileName, int spriteWidth, int spriteHeight)
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
        //int tpx = x % spriteWidth;
        //int tpy = y % spriteHeight;
        //int tpIndex = (tpy * spriteWidth) + tpx;
        int tpIndex = ((y % spriteHeight) * spriteWidth) + (x % spriteWidth);

        tilePixels[tileIndex][tpIndex] = pixels[i];
      }

      List<ImageBase> result = new List<ImageBase>();

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

    public static JSONObjectValue ParseJsonFile(string filePath)
    {
      StreamReader reader = new StreamReader(filePath);
      string jsonStr = reader.ReadToEnd();
      reader.Close();

      JSONParser parser = new JSONParser();
      return parser.Parse(jsonStr);
    }

    public static float Saturate(float value)
    {
      return Math.Min(1.0f, Math.Max(0.0f, value));
    }

    public static float Clamp(float value, float min, float max)
    {
      return Math.Min(max, Math.Max(min, value));
    }

    /// <summary>
    /// Gets all types from the given assembly that implement the given interface type and are not abtract.
    /// </summary>
    /// <param name="interfaceType">The interface type.</param>
    /// <param name="assembly">The assembly to search types in.</param>
    /// <returns>A list of types that implement the interface, never null.</returns>
    public static List<Type> GetTypesImplementingInterface(Type interfaceType, Assembly assembly)
    {
      Type[] allTypes = assembly.GetTypes();

      List<Type> result = new List<Type>();
      foreach (Type t in allTypes)
      {
        if (t.IsAbstract)
          continue;

        Type[] interfaces = t.GetInterfaces();
        foreach (Type itf in interfaces)
        {
          if (itf.Equals(interfaceType))
          {
            result.Add(t);
            break;
          }
        }
      }

      return result;
    }

    /// <summary>
    /// Gets all types from the given assembly that inherit from the given base class.
    /// The base class itself is never returned. Only non-abstract types are returned.
    /// </summary>
    /// <param name="baseClass">The base class to check for.</param>
    /// <param name="assembly">The assembly to search types in.</param>
    /// <returns>A list of all type that inherit from the given base class, never null.</returns>
    public static List<Type> GetTypesInhertingFromClass(Type baseClass, Assembly assembly)
    {
      Type[] allTypes = assembly.GetTypes();

      List<Type> result = new List<Type>();
      foreach (Type t in allTypes)
      {
        if (t.IsAbstract)
          continue;

        Type toCheck = t.BaseType;
        while (toCheck != null)
        {
          if (toCheck.Equals(baseClass))
          {
            result.Add(t);
            break;
          }
          toCheck = toCheck.BaseType;
        }
      }

      return result;
    }
    
    /// <summary>
    /// Returns the value that is closest to zero. For positive values this is the minimum value.
    /// For negative values this is the maximum value.
    /// Only works properly if both values are positive or negative!
    /// </summary>
    /// <param name="v1">The first value.</param>
    /// <param name="v2">The second value.</param>
    /// <returns>The value that is closest to zero.</returns>
    public static float ClosestToZero(float v1, float v2)
    {
      if (v1 > 0)
        return Math.Min(v1, v2);
      else
        return Math.Max(v1, v2);
    }
    
    /// <summary>
    /// Returns the value that is farthest from zero. For positive values this is the maximum value.
    /// For negative values this is the minimum value.
    /// Only works properly if both values are positive or negative!
    /// </summary>
    /// <param name="v1">The first value.</param>
    /// <param name="v2">The second value.</param>
    /// <returns>The value that is farthest from zero.</returns>
    public static float FarthestFromZero(float v1, float v2)
    {
      if (v1 > 0)
        return Math.Max(v1, v2);
      else
        return Math.Min(v1, v2);
    }

  }
}
