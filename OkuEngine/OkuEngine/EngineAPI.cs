using System.Collections.Generic;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine.Assets;
using OkuEngine.Events;
using OkuEngine.Input;
using OkuEngine.Levels;
using OkuEngine.Systems;

namespace OkuEngine
{
  public class EngineAPI
  {
    private Level _level = null;

    public EngineAPI(Level level)
    {
      _level = level;
    }

    /// <summary>
    /// Loads an image from the given file.
    /// </summary>
    /// <param name="filename">The full path to the file containing the image.</param>
    /// <returns>The loaded image.</returns>
    public Image LoadImage(string filename)
    {
      return OkuBase.OkuManager.Instance.Graphics.NewImage(ImageData.FromFile(filename));
    }

    #region Event Queue

    /// <summary>
    /// Queues a new event to the levels event queue.
    /// When queueing an event, the listeners are called the next time the event queue is processed, which happens once each frame.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="eventData">The event's data.</param>
    public void QueueEvent(string eventName, params object[] eventData)
    {
      //We don't care about events that occur before and during level initialization
      if (_level.Initialized)
        _level.EventQueue.QueueEvent(eventName, eventData);
    }

    /// <summary>
    /// Triggers an event immediately.
    /// When triggering an event, it is not queued and the listeners are called immediately.
    /// Only use when really required and you know what you do!
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="eventData">The event's data.</param>
    public void TriggerEvent(string eventName, params object[] eventData)
    {
      //We don't care about events that occur before and during level initialization
      if (_level.Initialized)
        _level.EventQueue.TriggerEvent(eventName, eventData);
    }

    #endregion

    #region Entities

    /// <summary>
    /// Adds a new entity to the level.
    /// </summary>
    /// <param name="entity">The entity to be added.</param>
    public void AddEntity(Entity entity)
    {
      entity.Engine = this;
      _level.Entities.Add(entity);
      QueueEvent(EventNames.LevelEntityAdded, entity);
    }

    /// <summary>
    /// Removes the given entity from the level.
    /// </summary>
    /// <param name="entity">The entity to be removed.</param>
    public void RemoveEntity(Entity entity)
    {
      entity.Engine = null;
      bool result = _level.Entities.Remove(entity);
      if (result)
        QueueEvent(EventNames.LevelEntityRemoved, entity);
    }

    /// <summary>
    /// Removes all entities from the level.
    /// </summary>
    public void ClearEntities()
    {
      _level.Entities.Clear();
    }

    #endregion

    #region Event Listener

    /// <summary>
    /// Adds a new event listener.
    /// </summary>
    /// <param name="eventListener">The event listener to be added.</param>
    public void AddEventListener(EventListener eventListener)
    {
      _level.EventListeners.Add(eventListener);

      foreach (var eventName in eventListener.EventNames)
        _level.EventQueue.AddListener(eventName, eventListener.Handler);

      QueueEvent(EventNames.LevelEventListenerAdded, eventListener);
    }

    /// <summary>
    /// Removes the given event listener.
    /// </summary>
    /// <param name="eventListener">The event listener to be removed.</param>
    public void RemoveEventListener(EventListener eventListener)
    {
      bool result = _level.EventListeners.Remove(eventListener);

      foreach (var eventName in eventListener.EventNames)
        _level.EventQueue.RemoveListener(eventName, eventListener.Handler);

      if (result)
        QueueEvent(EventNames.LevelEventListenerRemoved, eventListener);
    }

    /// <summary>
    /// Removes all event listeners.
    /// </summary>
    public void ClearEventListeners()
    {
      _level.EventListeners.Clear();
      QueueEvent(EventNames.LevelEventListenersCleared);
    }

    #endregion

    #region Input Contexts

    //Input contexts are sorted by priority (0 = highest). The engine processes
    //the contexts from highest to lowest priority.

    /// <summary>
    /// Sets the input context with the given priority.
    /// If there already was an input context with the same priority, it is overwritten.
    /// </summary>
    /// <param name="priority">The priority.</param>
    /// <param name="context">The input context.</param>
    public void SetInputContext(int priority, InputContext context)
    {
      List<InputContext> contexts = _level.InputContexts;

      if (priority >= contexts.Count)
      {
        for (int i = contexts.Count; i <= priority; i++)
          contexts.Add(null);
      }

      contexts[priority] = context;
    }

    /// <summary>
    /// Gets the input context with the given priority.
    /// </summary>
    /// <param name="priority">The priority.</param>
    /// <returns>The input context with the given priority. Maybe null if there is no input context with the given priority.</returns>
    public InputContext GetInputContext(int priority)
    {
      if (priority < _level.InputContexts.Count)
        return _level.InputContexts[priority];

      return null;
    }

    /// <summary>
    /// Gets the number of existing input context priority slots.
    /// This must not be the number of existing input contexts.
    /// Some priorities might not have an input context associated.
    /// </summary>
    /// <returns>The number of input context priority slots.</returns>
    public int GetInputContextCount()
    {
      return _level.InputContexts.Count;
    }

    /// <summary>
    /// Removes the input context with the given priority.
    /// Actually just sets the context for this priority to null.
    /// </summary>
    /// <param name="priority">The priority.</param>
    public void RemoveInputContext(int priority)
    {
      if (priority < _level.InputContexts.Count)
        _level.InputContexts[priority] = null;
    }

    /// <summary>
    /// Removes all input contexts.
    /// </summary>
    public void ClearInputContexts()
    {
      _level.InputContexts.Clear();
    }

    #endregion

    #region Input

    /// <summary>
    /// Gets the current value of the input axis with the given name.
    /// </summary>
    /// <param name="name">The name of the input axis.</param>
    /// <returns>The current value of the input axis.</returns>
    public float GetAxisValue(string name)
    {
      foreach (var context in _level.InputContexts)
      {
        foreach (var mapping in context.AxisMappings)
        {
          if (mapping.Name == name)
          {
            float value = 0.0f;
            foreach (var axis in mapping.Axes)
            {
              value = OkuMath.BasicMath.SignedMax(value, axis.GetCurrentValue());
            }
            return value;
          }
        }
      }

      return 0.0f;
    }

    #endregion

    #region Timers

    /// <summary>
    /// Sets a new timer that queues the given event once after the given time.
    /// </summary>
    /// <param name="time">The time to wait.</param>
    /// <param name="eventName">The name of the event.</param>
    /// <returns>The id of the timer that can be used with the ClearTimer method to stop the timer.</returns>
    public int SetTimer(float time, string eventName)
    {
      Timer timer = new Timer(time, eventName, false);
      _level.Timers.Add(timer);
      return timer.ID;
    }

    /// <summary>
    /// Sets a new interval that queues the given event periodically after the given time has passed.
    /// </summary>
    /// <param name="time">The time to wait between queueing the event.</param>
    /// <param name="eventName">The name of the event.</param>
    /// <returns>The id of the interval that can be used with the ClearInterval method to stop the interval.</returns>
    public int SetInterval(float time, string eventName)
    {
      Timer timer = new Timer(time, eventName, true);
      _level.Timers.Add(timer);
      return timer.ID;
    }

    /// <summary>
    /// Clears the timer with the given id. This can be used to stop a timer before it fires.
    /// </summary>
    /// <param name="timerId">The id of the timer.</param>
    /// <returns>True if the timer was removed, false if there is no timer with the given id.</returns>
    public bool ClearTimer(int timerId)
    {
      for (int i = _level.Timers.Count; i >= 0; i--)
      {
        if (_level.Timers[i].ID == timerId)
        {
          _level.Timers.RemoveAt(i);
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Clears the interval with the given id. This can be used to stop an interval firing the event over and over.
    /// </summary>
    /// <param name="timerId">The id of the interval.</param>
    /// <returns>True if the interval was removed, false if there is no interval with the given id.</returns>
    public bool ClearInterval(int intervalId)
    {
      return ClearTimer(intervalId);
    }

    #endregion

    #region Meshes

    /// <summary>
    /// Creates a new mesh asset that can be used for rendering the given image in original size
    /// </summary>
    /// <param name="width">The width of the image.</param>
    /// <param name="height">The height of the image.</param>
    /// <param name="isStatic">Create a static (true) or dynamic (false) mesh.</param>
    /// <returns>The mesh asst for the given image.</returns>
    public MeshAsset GetMeshForImage(int width, int height, bool isStatic)
    {
      float halfWidth = width / 2;
      float halfHeight = height / 2;

      Vector2f[] pos = new Vector2f[4] {
        new Vector2f(-halfWidth, -halfHeight),
        new Vector2f(-halfWidth, halfHeight),
        new Vector2f(halfWidth, -halfHeight),
        new Vector2f(halfWidth, halfHeight)
      };

      Vector2f[] tex = new Vector2f[4] {
        new Vector2f(0, 0),
        new Vector2f(0, 1),
        new Vector2f(1, 0),
        new Vector2f(1, 1)
      };

      MeshAsset result;
      if (isStatic)
        result = new StaticMeshAsset(pos, tex, null, PrimitiveType.TriangleStrip);
      else
        result = new DynamicMeshAsset(pos, tex, null, PrimitiveType.TriangleStrip);

      return result;
    }

    #endregion

  }
}
