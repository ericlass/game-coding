using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace OkuEngine.GCC.Resources
{
  public class TextureResourceLoader : IResourceLoader
  {
    public string Pattern
    {
      get { return "*.png"; }
    }

    public bool UseRawFile
    {
      get { return false; }
    }

    public long GetLoadedResourceSize(Stream rawBuffer)
    {
      Bitmap image = new Bitmap(rawBuffer);
      return image.Width * image.Height * 4;
    }

    public bool LoadResource(Stream rawBuffer, ResourceHandle handle)
    {
      try
      {
        Bitmap image = new Bitmap(rawBuffer);
        TextureExtraData extra = new TextureExtraData(image);
      }
      catch (Exception)
      {
        //TODO: Log exception message
        return false;
      }
      
      return true;
    }

    public bool DiscardRawBufferAfterLoad
    {
      get { throw new NotImplementedException(); }
    }

  }
}
