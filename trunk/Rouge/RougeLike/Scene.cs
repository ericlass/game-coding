using System;
using System.Collections.Generic;

namespace RougeLike
{
  public class Scene : IIdObject, IUpdatable
  {
    private string _id = null;
    private EntityMap _entities = null;
    private ProcessManager _processes = null;

    public Scene(string id)
    {
      _id = id;
      _entities = new EntityMap();
      _processes = new ProcessManager();
    }

    public Scene(string id, EntityMap entities, ProcessManager processes)
    {
      _id = id;
      _entities = entities;
      _processes = processes;
    }

    public string Id
    {
      get { return _id; }
      set { _id = value; }
    }

    public EntityMap Entities
    {
      get { return _entities; }
      set { _entities = value; }
    }

    public ProcessManager Processes
    {
      get { return _processes; }
      set { _processes = value; }
    }

    public void Update(float dt)
    {
      _entities.Update(dt);
      _processes.Update(dt);
    }

    public void Activate()
    {
      _processes.InitAll();
    }

    public void Deactivate()
    {
      _processes.DestroyAll();
    }

  }
}
