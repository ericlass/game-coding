using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace OkuEngine.GCC.Resources
{
  public delegate void ResourceLoadProgressDelegate(int percent, out bool cancel);

  public class ResourceCache
  {
    private List<ResourceHandle> _leastRecentlyUsed = new List<ResourceHandle>();
    private Dictionary<String, ResourceHandle> _resources = new Dictionary<string, ResourceHandle>();
    private List<IResourceLoader> _loaders = new List<IResourceLoader>();

    private IResourceFile _resourceFile = null;

    //Saizes in bytes
    private long _maxSize = 0;
    private long _currentSize = 0;

    public ResourceCache(long sizeInMb, IResourceFile resourceFile)
    {
      _maxSize = sizeInMb * 1024 * 1024;
      _resourceFile = resourceFile;
    }

    private ResourceHandle Find(Resource resource)
    {
      ResourceHandle result;
      _resources.TryGetValue(resource.Name, out result);
      return result;
    }

    private void Update(ResourceHandle handle)
    {
      _leastRecentlyUsed.Remove(handle);
      _leastRecentlyUsed.Add(handle);
    }

    private bool WildcardMatch(string pattern, string str)
    {
      string regex = "^" + Regex.Escape(str).Replace("\\*", ".*").Replace("\\?", ".") + "$";
      return Regex.IsMatch(str, regex);
    }

    private ResourceHandle Load(Resource resource)
    {
      IResourceLoader loader = null;
      ResourceHandle handle = null;

      for (int i = _loaders.Count - 1; i >= 0; i--)
      {
        IResourceLoader current = _loaders[i];
        if (WildcardMatch(current.Pattern, resource.Name))
        {
          loader = current;
          break;
        }
      }

      if (loader == null)
      {
        //TODO: Log that default resource loader was not found
        return null;
      }

      long rawSize = _resourceFile.GetRawResourceSize(resource);
      Stream rawBuffer = loader.UseRawFile ? Allocate(rawSize) : new MemoryStream((int)rawSize);

      if (rawBuffer == null)
      {
        return null;
      }
      _resourceFile.GetRawResource(resource, rawBuffer);
      Stream buffer = null;

      if (loader.UseRawFile)
      {
        buffer = rawBuffer;
        handle = new ResourceHandle(resource, buffer, this);
      }
      else
      {
        long size = loader.GetLoadedResourceSize(rawBuffer);
        buffer = Allocate(size);
        if (rawBuffer == null || buffer == null)
        {
          return null;
        }
        handle = new ResourceHandle(resource, buffer, this);
        bool success = loader.LoadResource(rawBuffer, handle);
        if (!success)
        {
          return null;
        }
      }

      if (handle != null)
      {
        _leastRecentlyUsed.Remove(handle);
        _leastRecentlyUsed.Add(handle);

        if (!_resources.ContainsKey(resource.Name))
          _resources.Add(resource.Name, handle);
        else
          _resources[resource.Name] = handle;
      }

      return handle;
    }

    private void Free(ResourceHandle handle)
    {
      _leastRecentlyUsed.Remove(handle);
      _resources.Remove(handle.Resource.Name);
    }

    private bool MakeRoom(long size)
    {
      if (size > _maxSize)
      {
        return false;
      }

      while (size > (_maxSize - _currentSize))
      {
        if (_leastRecentlyUsed.Count == 0)
          return false;

        FreeOldestResource();
      }

      return true;
    }

    private Stream Allocate(long size)
    {
      if (!MakeRoom(size))
      {
        System.Diagnostics.Debug.WriteLine("RESOURCE CACHE IS OUT OF MEMORY!");
        return null;
      }

      Stream result = new MemoryStream((int)size);
      _currentSize += size;

      return result;
    }

    private void FreeOldestResource()
    {
      ResourceHandle handle = _leastRecentlyUsed[0];
      _leastRecentlyUsed.RemoveAt(0);
      _resources.Remove(handle.Resource.Name);
    }

    internal void MemoryHasBeenFreed(long size)
    {
      _currentSize -= size;
    }

    public bool Init()
    {
      bool result = false;
      if (_resourceFile.Open())
      {
        RegisterLoader(new DefaultResourceLoader());
        result = true;
      }
      return result;
    }

    public void RegisterLoader(IResourceLoader loader)
    {
      _loaders.Add(loader);
    }

    public ResourceHandle GetHandle(Resource resource)
    {
      ResourceHandle handle = Find(resource);
      if (handle == null)
        handle = Load(resource);
      else
        Update(handle);
      return handle;
    }

    public int PreLoad(string pattern, ResourceLoadProgressDelegate callback)
    {
      if (_resourceFile == null)
        return 0;

      int numFiles = _resourceFile.GetNumResources();
      int loaded = 0;
      bool cancel = false;

      for (int i = 0; i < numFiles; i++)
      {
        Resource resource = new Resource(_resourceFile.GetResourceName(i));

        if (WildcardMatch(pattern, resource.Name))
        {
          ResourceHandle handle = GetHandle(resource);
          loaded++;
        }

        if (callback != null)
        {
          callback((i / numFiles) * 100, out cancel);

          //Addition from me!
          if (cancel)
            return loaded;
        }
      }

      return loaded;
    }

    public void Flush()
    {
      foreach (ResourceHandle handle in _leastRecentlyUsed)
      {
        Free(handle);
      }
      _leastRecentlyUsed.Clear();
    }

  }
}
