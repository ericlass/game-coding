using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public abstract class ProcessBase
  {
    private ProcessResult _state = ProcessResult.None;
    private ProcessBase _successor = null;

    public ProcessResult Result
    {
      get { return _state; }
    }

    public ProcessBase Successor
    {
      get { return _successor; }
      set { _successor = value; }
    }

    public abstract void Initialize();
    public abstract bool Update(float dt);
    public abstract void Destroy();

  }
}
