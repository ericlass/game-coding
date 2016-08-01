using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine
{
  /// <summary>
  /// Cache that provides events for all changes to the attached data.
  /// You first have to create a chache entry. After that, you have to buffer
  /// data at least once, but as often as you want.
  /// After removing an entry, it cannot be reused again.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class ObservableCache<T>
  {
    private List<T> _entries = new List<T>();
    private SortedSet<int> _invalidEntries = new SortedSet<int>();

    public ObservableCache()
    {
    }

    /// <summary>
    /// Validates the given entry id. Throws an exception if it was already invalidated.
    /// </summary>
    /// <param name="entry"></param>
    private void validateEntryId(int entry)
    {
      if (_invalidEntries.Contains(entry))
        throw new InvalidOperationException("Trying to use cache entry " + entry + " which was already removed!");
    }

    /// <summary>
    /// Is called when a new cache entry is created.
    /// At this point, the entry does not have data yet.
    /// </summary>
    public event Action<int> OnCreateEntry;

    /// <summary>
    /// Is triggered whenever the data of an entry if buffered.
    /// </summary>
    public event Action<int> OnBufferData;

    /// <summary>
    /// Is triggered when a cache entry is removed and becomes invalid.
    /// The entry should not be used anymore afterwards.
    /// </summary>
    public event Action<int> OnRemoveEntry;

    /// <summary>
    /// Creates a new cache entry. The value returned is used to reference this entry.
    /// After an entry has been created, data has to be buffered using the BufferData method.
    /// </summary>
    /// <returns>The cache entry identifier.</returns>
    public int CreateEntry()
    {
      _entries.Add(default(T));
      int result = _entries.Count - 1;
      OnCreateEntry?.Invoke(result);
      return result;
    }

    /// <summary>
    /// Buffers data to the given entry.
    /// </summary>
    /// <param name="entry">The entry identifier.</param>
    /// <param name="data">The data to attach to the entry.</param>
    public void BufferData(int entry, T data)
    {
      validateEntryId(entry);
      _entries[entry] = data;
      OnBufferData?.Invoke(entry);
    }

    /// <summary>
    /// Removes the cache entry with the given identifier.
    /// If an identifier is used again after it was removed, an exception is thrown.
    /// </summary>
    /// <param name="entry">The entry to remove.</param>
    /// <returns>True if the entry was removed, False if an invalid entry identifier was given.</returns>
    public bool RemoveEntry(int entry)
    {
      if (entry < 0 || entry >= _entries.Count || _invalidEntries.Contains(entry))
        return false;

      _entries[entry] = default(T);
      _invalidEntries.Add(entry);

      OnRemoveEntry?.Invoke(entry);
      return true;
    }

    /// <summary>
    /// Gets the data cached for the given entry.
    /// </summary>
    /// <param name="entry">The entry identifier.</param>
    /// <returns>The data cached for the entry.</returns>
    public T this[int entry]
    {
      get
      {
        validateEntryId(entry);

        return _entries[entry];
      }
    }

  }
}
