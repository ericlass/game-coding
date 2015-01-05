using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public class EventManager
  {
    //Used to create new instances of actions
    private ActionFactory _factory = new ActionFactory();
    //Defines event handlers
    private Dictionary<string, HashSet<EventHandler>> _eventHandlers = new Dictionary<string, HashSet<EventHandler>>();
    //Simple logger
    private ILogger _logger = null;

    //Contains the queued events
    private Queue<string> _events = new Queue<string>();
    //Contains the currently running actions
    private List<IAction> _runningActions = new List<IAction>();

    public EventManager(ActionFactory factory)
    {
      _factory = factory;
    }

    public ActionFactory ActionFactory
    {
      get { return _factory; }
      set { _factory = value; }
    }

    public ILogger Logger
    {
      get { return _logger; }
      set { _logger = value; }
    }

    public bool RegisterHandler(string eventId, EventHandler eventHandler)
    {
      HashSet<EventHandler> actions = null;
      if (_eventHandlers.ContainsKey(eventId))
        actions = _eventHandlers[eventId];
      else
      {
        actions = new HashSet<EventHandler>();
        _eventHandlers.Add(eventId, actions);
      }

      if (actions.Contains(eventHandler))
        return false;

      actions.Add(eventHandler);
      return true;
    }

    public bool RemoveHandler(string eventId, EventHandler eventHandler)
    {
      if (!_eventHandlers.ContainsKey(eventId))
        return false;

      if (!_eventHandlers[eventId].Contains(eventHandler))
        return false;

      _eventHandlers[eventId].Remove(eventHandler);

      if (_eventHandlers[eventId].Count == 0)
        _eventHandlers.Remove(eventId);

      return true;
    }

    public void QueueEvent(string eventId)
    {
      if (!_eventHandlers.ContainsKey(eventId))
      {
        if (_logger != null)
          _logger.Log("Ignored : " + eventId);
        return;
      }

      _events.Enqueue(eventId);
      if (_logger != null)
        _logger.Log("Enqueued: " + eventId);
    }

    public void Update(float dt)
    {
      //Dequeue events and start actions
      while (_events.Count > 0)
      {
        string ev = _events.Dequeue();
        if (_eventHandlers.ContainsKey(ev))
        {
          foreach (EventHandler handler in _eventHandlers[ev])
          {
            _runningActions.Add(_factory.Create(handler.ActionId, handler.Parameters));
            if (_logger != null)
              _logger.Log("Started : " + handler);
          }
        }
      }

      //Update running actions and remove them when they are finished
      for (int i = _runningActions.Count - 1; i >= 0; i--)
      {
        IAction action = _runningActions[i];
        if (action.Update(dt))
          _runningActions.RemoveAt(i);
      }
    }  
  }
}
