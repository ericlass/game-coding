using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Processes
{
  public class ProcessManager
  {
    private List<Process> _processes = new List<Process>();

    public ProcessManager()
    {
    }

    public int UpdateProcesses(float dt)
    {
      short successCount = 0;
      short failCount = 0;

      for (int i = _processes.Count - 1; i >= 0; i--)
      {
        Process currentProcess = _processes[i];

        if (currentProcess.State == ProcessState.Uninitialized)
          currentProcess.OnInit();

        if (currentProcess.State == ProcessState.Running)
          currentProcess.OnUpdate(dt);

        if (currentProcess.IsDead)
        {
          switch (currentProcess.State)
          {
            case ProcessState.Succeeded:
              currentProcess.OnSuccess();
              Process child = currentProcess.RemoveChild();
              if (child != null)
                AttachProcess(child);
              else
                successCount++;
              break;

            case ProcessState.Failed:
              currentProcess.OnFail();
              failCount++;
              break;

            case ProcessState.Aborted:
              currentProcess.OnAbort();
              failCount++;
              break;
          }

          _processes.RemoveAt(i);
        }
      }

      return (short)(successCount << 16) | failCount;
    }

    public void AttachProcess(Process process)
    {
      _processes.Add(process);
    }

    private void ClearAllProcesses()
    {
      _processes.Clear();
    }

    public void AbortAllProcesses(bool immediate)
    {
      for (int i = _processes.Count - 1; i >= 0; i--)
      {
        Process currentProcess = _processes[i];
        if (currentProcess.IsAlive)
        {
          currentProcess.SetState(ProcessState.Aborted);
          if (immediate)
          {
            currentProcess.OnAbort();
            _processes.RemoveAt(i);
          }
        }
      }
    }

    public int ProcessCount
    {
      get { return _processes.Count; }
    }

  }
}
