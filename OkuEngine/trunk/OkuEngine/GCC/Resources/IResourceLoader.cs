using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OkuEngine.GCC.Resources
{
  public interface IResourceLoader
  {
    string Pattern { get; }
    bool UseRawFile { get; }
    long GetLoadedResourceSize(Stream rawBuffer);
    bool LoadResource(Stream rawBuffer, ResourceHandle handle);
  }
}
