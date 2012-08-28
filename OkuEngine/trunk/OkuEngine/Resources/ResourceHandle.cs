using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OkuEngine.Resources
{
  public class ResourceHandle
  {
    private Resource _resource = null;
    private Stream _buffer = null;
    private IResourceExtraData _extras = null;
    private ResourceCache _cache = null;

    public ResourceHandle(Resource resource, Stream buffer, ResourceCache cache)
    {
      _resource = resource;
      _buffer = buffer;
      _cache = cache;
    }

    ~ResourceHandle()
    {
      _cache.MemoryHasBeenFreed(_buffer.Length);
      _buffer.Close();
    }

    public long Size
    {
      get { return _buffer.Length; }
    }

    public Stream Buffer
    {
      get { return _buffer; }
    }

    public ResourceCache Cache
    {
      get { return _cache; }
    }

    public Resource Resource
    {
      get { return _resource; }
    }

    public IResourceExtraData Extras
    {
      get { return _extras; }
      set { _extras = value; }
    }

  }
}
