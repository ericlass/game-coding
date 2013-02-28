using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Processes
{
  public class Process
  {
    private ProcessState _state = ProcessState.Uninitialized;
    private Process _child = null;

    public Process()
    {
    }

    public virtual void OnInit()
    {
      _state = ProcessState.Running;
    }

    public virtual void OnUpdate(float dt)
    {
    }

    public virtual void OnSuccess()
    {
    }

    public virtual void OnFail()
    {
    }

    public virtual void OnAbort()
    {
    }

    public void Succeed()
    {
      if (_state != ProcessState.Running && _state != ProcessState.Paused)
        throw new OkuException();

      _state = ProcessState.Succeeded;
    }

    public void Fail()
    {
      if (_state != ProcessState.Running && _state != ProcessState.Paused)
        throw new OkuException();

      _state = ProcessState.Failed;
    }

    public void Pause()
    {
      if (_state == ProcessState.Running)
        _state = ProcessState.Paused;
      else
        OkuManagers.Instance.Logger.LogInfo("Trying to pause a running process!");
    }

    public void UnPause()
    {
      if (_state == ProcessState.Paused)
        _state = ProcessState.Running;
      else
        OkuManagers.Instance.Logger.LogInfo("Trying to resume an unpaused process!");
    }

    public ProcessState State
    {
      get { return _state; }
    }

    public bool IsAlive
    {
      get { return _state == ProcessState.Running || _state == ProcessState.Paused; }
    }

    public bool IsDead
    {
      get { return _state == ProcessState.Succeeded || _state == ProcessState.Failed || _state == ProcessState.Aborted; }
    }

    public bool IsRemoved
    {
      get { return _state == ProcessState.Removed; }
    }

    public bool IsPaused
    {
      get { return _state == ProcessState.Paused; }
    }

    public void AttachChild(Process child)
    {
      if (_child != null)
        _child.AttachChild(child);
      else
        _child = child;
    }

    public Process RemoveChild()
    {
      Process result = _child;
      _child = null;
      return result;
    }

    public Process PeekChild()
    {
      return _child;
    }

    internal void SetState(ProcessState state)
    {
      _state = state;
    }

  }
}
