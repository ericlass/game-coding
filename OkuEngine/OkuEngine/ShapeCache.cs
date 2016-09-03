using System;
using OkuEngine.Systems;
using OkuEngine.Levels;

namespace OkuEngine
{
  /// <summary>
  /// Defines an observable shape cache that caches all collision shapes in the current level.
  /// This cache already queues change notifications to the levels event queue.
  /// </summary>
  public class ShapeCache : ObservableCache<CollisionShape>
  {
    private Level _level = null;

    /// <summary>
    /// Creates a new shape cache for the given level.
    /// </summary>
    /// <param name="level">The level this cache belongs to. Can be null, but then no events are queued.</param>
    public ShapeCache(Level level)
    {
      _level = level;

      OnCreateEntry += ShapeCache_OnCreateEntry;
      OnBufferData += ShapeCache_OnBufferData;
      OnRemoveEntry += ShapeCache_OnRemoveEntry;
    }

    private void ShapeCache_OnRemoveEntry(int obj)
    {
      _level?.Engine.QueueEvent(EventNames.ShapeCacheEntryRemoved, obj);
    }

    private void ShapeCache_OnBufferData(int obj)
    {
      _level?.Engine.QueueEvent(EventNames.ShapeCacheDataBuffered, obj);
    }

    private void ShapeCache_OnCreateEntry(int obj)
    {
      _level?.Engine.QueueEvent(EventNames.ShapeCacheEntryAdded, obj);
    }
  }
}
