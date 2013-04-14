using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine
{
  /// <summary>
  /// Basic manager class for storeable entities that provides
  /// management and loading and saving of entities.
  /// </summary>
  /// <typeparam name="T">The type of entities to be managed.</typeparam>
  public class EntityManager<T> : HashSet<T>, IStoreable where T : StoreableEntity, new()
  {
    protected Dictionary<int, T> _entityMap = new Dictionary<int, T>();
    private string _groupName = null;
    private string _entityName = null;
    private string _sequenceName = null;

    /// <summary>
    /// Creates a new entity manager with the given parameters.
    /// </summary>
    /// <param name="groupName">Name of the gourp tag.</param>
    /// <param name="entityName">Name of the tag for the single entities.</param>
    /// <param name="sequenceName">Name of the sequence that manages the ids.</param>
    public EntityManager(string groupName, string entityName, string sequenceName)
    {
      _groupName = groupName;
      _entityName = entityName;
      _sequenceName = sequenceName;
    }

    /// <summary>
    /// Gets the name of the group tag.
    /// </summary>
    public string GroupName
    {
      get { return _groupName; }
    }

    /// <summary>
    /// Gets the name of the single entity tag.
    /// </summary>
    public string EntityName
    {
      get { return _entityName; }
    }

    /// <summary>
    /// Gets the name of the sequence that is used for the ids.
    /// </summary>
    public string SequenceName
    {
      get { return _sequenceName; }
    }

    /// <summary>
    /// Adds the given entity to the manager.
    /// </summary>
    /// <param name="entity">The entity to be added.</param>
    /// <returns>True if the entity was added, false if there already is an entity with the same id.</returns>
    public new bool Add(T entity)
    {
      if (!_entityMap.ContainsKey(entity.Id))
      {
        base.Add(entity);
        _entityMap.Add(entity.Id, entity);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Removes the given entity from the manager.
    /// </summary>
    /// <param name="entity">The entity to be removed.</param>
    /// <returns>True if the entity was removed, false if the manager did not contain the entity.</returns>
    public new bool Remove(T entity)
    {
      return _entityMap.Remove(entity.Id) || base.Remove(entity);
    }

    /// <summary>
    /// Gets the entity with the given id.
    /// </summary>
    /// <param name="id">The id of the entity.</param>
    /// <returns>The entity with the given id or null if there is no entity with the given id.</returns>
    public T this[int id]
    {
      get
      {
        if (_entityMap.ContainsKey(id))
          return _entityMap[id];

        return null;
      }
    }

    public virtual bool AfterLoad()
    {
      _entityMap.Clear();
      int maxId = -1;
      foreach (T entity in this)
      {
        if (!entity.AfterLoad())
          return false;
        _entityMap.Add(entity.Id, entity);
        if (entity.Id > maxId)
          maxId = entity.Id;
      }
      KeySequence.SetCurrentValue(_sequenceName, maxId);

      return true;
    }

  }
}
