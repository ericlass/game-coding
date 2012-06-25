using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OkuEngine.GCC.Resources
{
  public interface IResourceFile
  {
    bool Open();
    long GetRawResourceSize(Resource resource);
    long GetRawResource(Resource resource, Stream buffer);
    int GetNumResources();
    string GetResourceName(int index);
  }
}
