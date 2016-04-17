﻿using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;
using OkuEngine.Events;
using OkuEngine.Components;
using OkuEngine.Input;
using OkuEngine.Levels;

namespace OkuEngine
{
  public class EngineAPI
  {
    private Level _level = null;

    internal EngineAPI(Level level)
    {
      _level = level;
    }

    #region Entity component event handlers

    private void Entity_OnAddComponent(Entity arg1, IComponent arg2)
    {
      QueueEvent(EventNames.EntityComponentAdded, arg1, arg2);
    }

    private void Entity_OnRemoveComponent(Entity arg1, IComponent arg2)
    {
      QueueEvent(EventNames.EntityComponentRemoved, arg1, arg2);
    }

    private void Entity_OnClearComponents(Entity obj)
    {
      QueueEvent(EventNames.EntityComponentsCleared, obj);
    }

    #endregion

    /// <summary>
    /// Loads an image from the given file.
    /// </summary>
    /// <param name="filename">The full path to the file containing the image.</param>
    /// <returns>The loaded image.</returns>
    public Image LoadImage(string filename)
    {
      ImageData data = ImageData.FromFile(filename);
      Image result = OkuManager.Instance.Graphics.NewImage(data);
      return result;
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
      _level.Entities.Add(entity);
      QueueEvent(EventNames.LevelEntityAdded, entity);

      entity.OnAddComponent += Entity_OnAddComponent;
      entity.OnRemoveComponent += Entity_OnRemoveComponent;
      entity.OnClearComponents += Entity_OnClearComponents;
    }

    /// <summary>
    /// Removes the given entity from the level.
    /// </summary>
    /// <param name="entity">The entity to be removed.</param>
    public void RemoveEntity(Entity entity)
    {
      bool result = _level.Entities.Remove(entity);
      if (result)
        QueueEvent(EventNames.LevelEntityRemoved, entity);

      entity.OnAddComponent -= Entity_OnAddComponent;
      entity.OnRemoveComponent -= Entity_OnRemoveComponent;
      entity.OnClearComponents -= Entity_OnClearComponents;
    }

    /// <summary>
    /// Removes all entities from the level.
    /// </summary>
    public void ClearEntities()
    {
      foreach (Entity entity in _level.Entities)
      {
        entity.OnAddComponent -= Entity_OnAddComponent;
        entity.OnRemoveComponent -= Entity_OnRemoveComponent;
        entity.OnClearComponents -= Entity_OnClearComponents;
      }

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

  }
}