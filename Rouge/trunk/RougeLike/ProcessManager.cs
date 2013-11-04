using System;
using System.Collections.Generic;
using OkuBase;

namespace RougeLike
{
  public class ProcessManager : IUpdatable
  {
    private HashSet<ProcessBase> _processes = new HashSet<ProcessBase>();
    private HashSet<ProcessBase> _stopped = new HashSet<ProcessBase>();

    public ProcessManager()
    {
    }

    public bool Add(ProcessBase process)
    {
      return _processes.Add(process);
    }

    public bool Remove(ProcessBase process)
    {
      return _processes.Remove(process);
    }

    public void Update(float dt)
    {
      foreach (ProcessBase process in _processes)
      {
        if (process.Update(dt))
          _stopped.Add(process);
      }

      foreach (ProcessBase process in _stopped)
      {
        _processes.Remove(process);
        if (process.Result == ProcessResult.Finished && process.Successor != null)
        {
          _processes.Add(process.Successor);
        }
        process.Destroy();
      }
      _stopped.Clear();
    }

  }
}
