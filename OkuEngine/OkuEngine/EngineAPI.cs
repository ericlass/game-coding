using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Input;
using OkuBase.Graphics;
using OkuEngine.Events;
using OkuEngine.Components;
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

    public Image LoadImage(string filename)
    {
      ImageData data = ImageData.FromFile(filename);
      Image result = OkuManager.Instance.Graphics.NewImage(data);
      return result;
    }

    public void QueueEvent(string eventName, params object[] eventData)
    {
      //We don't care about events that occur before and during level initialization
      if (_level.Initialized)
        _level.EventQueue.QueueEvent(eventName, eventData);
    }

    public void TriggerEvent(string eventName, params object[] eventData)
    {
      //We don't care about events that occur before and during level initialization
      if (_level.Initialized)
        _level.EventQueue.TriggerEvent(eventName, eventData);
    }

    public void AddEntity(Entity entity)
    {
      _level.Entities.Add(entity);
      QueueEvent(EventNames.LevelEntityAdded, entity);

      entity.OnAddComponent += Entity_OnAddComponent;
      entity.OnRemoveComponent += Entity_OnRemoveComponent;
      entity.OnClearComponents += Entity_OnClearComponents;
    }

    public void RemoveEntity(Entity entity)
    {
      bool result = _level.Entities.Remove(entity);
      if (result)
        QueueEvent(EventNames.LevelEntityRemoved, entity);

      entity.OnAddComponent -= Entity_OnAddComponent;
      entity.OnRemoveComponent -= Entity_OnRemoveComponent;
      entity.OnClearComponents -= Entity_OnClearComponents;
    }    

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

    public void AddEventListener(EventListener eventListener)
    {
      _level.EventListeners.Add(eventListener);

      foreach (var eventName in eventListener.EventNames)
        _level.EventQueue.AddListener(eventName, eventListener.Handler);

      QueueEvent(EventNames.LevelEventListenerAdded, eventListener);
    }

    public void RemoveEventListener(EventListener eventListener)
    {
      bool result = _level.EventListeners.Remove(eventListener);

      foreach (var eventName in eventListener.EventNames)
        _level.EventQueue.RemoveListener(eventName, eventListener.Handler);

      if (result)
        QueueEvent(EventNames.LevelEventListenerRemoved, eventListener);
    }

    public void ClearEventListeners()
    {
      _level.EventListeners.Clear();
      QueueEvent(EventNames.LevelEventListenersCleared);
    }

  }
}
