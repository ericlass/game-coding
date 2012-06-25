using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OkuEngine.GCC.Resources
{
  public class DefaultResourceLoader : IResourceLoader
  {
    public string Pattern
    {
      get { return "*"; }
    }

    public bool UseRawFile
    {
      get { return true; }
    }

    public long GetLoadedResourceSize(Stream rawBuffer)
    {
      return rawBuffer.Length;
    }

    public bool LoadResource(Stream rawBuffer, ResourceHandle handle)
    {
      return true;
    }

  }
}
