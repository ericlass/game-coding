using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace OkuEngine
{
  public class EngineFunctions
  {
    public Image LoadImage(string filename)
    {
      ImageData data = ImageData.FromFile(filename);
      Image result = Engine.Instance.Oku.Graphics.NewImage(data);
      return result;
    }
  }
}
