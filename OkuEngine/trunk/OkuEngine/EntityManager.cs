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
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public class EntityManager<T> : IStoreable where T : StoreableEntity, new()
  {
    protected Dictionary<int, T> _entities = new Dictionary<int, T>();
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

    [JsonPropertyAttribute]
    public List<T> Entities
    {
      get { return new List<T>(_entities.Values); }
      set
      {
        _entities.Clear();
        if (value != null)
        {
          foreach (T entity in value)
            _entities.Add(entity.Id, entity);
        }
      }
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
    public bool Add(T entity)
    {
      if (!_entities.ContainsKey(entity.Id))
      {
        _entities.Add(entity.Id, entity);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Removes the given entity from the manager.
    /// </summary>
    /// <param name="entity">The entity to be removed.</param>
    /// <returns>True if the entity was removed, false if the manager did not contain the entity.</returns>
    public bool Remove(T entity)
    {
      return _entities.Remove(entity.Id);
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
        if (_entities.ContainsKey(id))
          return _entities[id];

        return null;
      }
    }

    /// <summary>
    /// Loads a list of entities from the given XML node.
    /// </summary>
    /// <param name="node">The xml node to load from.</param>
    /// <returns>True if the entities where loaded, else false.</returns>
    public virtual bool Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        if (child.Name.ToLower() == _entityName)
        {
          T entity = new T();
          if (!entity.Load(child))
          {
            OkuManagers.Logger.LogError("Could not load " + _entityName + " from XML!\n" + child.OuterXml);
          }
          if (!Add(entity))
          {
            OkuManagers.Logger.LogError("The id " + entity.Id + " is used twice for " + _entityName + "!");
          }
          if (_sequenceName != null)
            KeySequence.SetCurrentValue(_sequenceName, entity.Id);
        }

        child = child.NextSibling;
      }

      return true;
    }

    /// <summary>
    /// Saves the entities in the manager to the given XML writer.
    /// </summary>
    /// <param name="writer">The write to save to.</param>
    /// <returns>True if the entities where saved successfully, else false.</returns>
    public virtual bool Save(XmlWriter writer)
    {
      writer.WriteStartElement(_groupName);

      foreach (KeyValuePair<int, T> entity in _entities)
      {
        if (!entity.Value.Save(writer))
        {
          OkuManagers.Logger.LogError("Could not save " + _entityName + " with the id " + entity.Value.Id + "!");
          return false;
        }
      }

      writer.WriteEndElement();

      return true;
    }

  }
}
