using System;
using OkuEngine.Levels;

namespace OkuEngine
{
  /// <summary>
  /// Defines an observable mesh cache that caches all meshes in the current level.
  /// This cache already queues change notifications to the levels event queue.
  /// </summary>
  public class MeshCache : ObservableCache<Mesh>
  {
    private Level _level = null;

    /// <summary>
    /// Creates a new mesh cache for the given level.
    /// </summary>
    /// <param name="level">The level this cache belongs to. Can be null, but then no events are queued.</param>
    public MeshCache(Level level)
    {
      _level = level;

      OnCreateEntry += MeshCache_OnCreateEntry;
      OnBufferData += MeshCache_OnBufferData;
      OnRemoveEntry += MeshCache_OnRemoveEntry;
    }

    private void MeshCache_OnRemoveEntry(int obj)
    {
      _level?.API.QueueEvent(EventNames.MeshCacheEntryRemoved, obj);
    }

    private void MeshCache_OnBufferData(int obj)
    {
      _level?.API.QueueEvent(EventNames.MeshCacheDataBuffered, obj);
    }

    private void MeshCache_OnCreateEntry(int obj)
    {
      _level?.API.QueueEvent(EventNames.MeshCacheEntryAdded, obj);
    }

  }
}
