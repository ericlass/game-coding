using System;

namespace OkuEngine.Resources
{
  public class ResourceCacheParams
  {
    public long SizeInMb { get; set; }
    public IResourceFile ResourceFile { get; set; }
  }
}