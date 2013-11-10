using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Manages actors.
  /// </summary>
  public class ActorManager : HashSet<Actor>, IStoreable
  {
    private Dictionary<int, Actor> _actorMap = new Dictionary<int, Actor>();

    /// <summary>
    /// Create a new actor manager.
    /// </summary>
    public ActorManager()
    {
      _actorMap = new Dictionary<int, Actor>();
    }

    /// <summary>
    /// Adds a actor to the manager.
    /// </summary>
    /// <param name="actor">The actor to add.</param>
    /// <returns>True if the actor was added, false if there already is a actor with the same id.</returns>
    public new bool Add(Actor actor)
    {
      if (_actorMap.ContainsKey(actor.Id))
        return false;

      base.Add(actor);
      _actorMap.Add(actor.Id, actor);

      return true;
    }

    /// <summary>
    /// Removes the given actor from the manager.
    /// </summary>
    /// <param name="actor">The actor to be removed.</param>
    /// <returns>True if the actor was removed, false if the manager did not contain the actor.</returns>
    public new bool Remove(Actor actor)
    {
      base.Remove(actor);
      return _actorMap.Remove(actor.Id);
    }

    /// <summary>
    /// Gets the actor with the given id.
    /// </summary>
    /// <param name="id">The id of the actor.</param>
    /// <returns>The actor with the given id or null if the manager does not contain a actor with this id.</returns>
    public Actor this[int id]
    {
      get
      {
        if (_actorMap.ContainsKey(id))
          return _actorMap[id];
        else
          return null;
      }
    }

    public bool AfterLoad()
    {
      int maxId = -1;
      foreach (Actor actor in this)
      {
        if (!actor.AfterLoad())
          return false;
        _actorMap.Add(actor.Id, actor);
        if (actor.Id > maxId)
          maxId = actor.Id;
      }
      KeySequence.SetCurrentValue(KeySequence.ActorSequence, maxId);

      return true;
    }

  }
}
