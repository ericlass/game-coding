using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  public abstract class BehaviorTreeNode
  {
    private bool _active = false;

    public BehaviorResult Update(float dt)
    {
      if (!_active)
      {
        OnEnter();
        _active = true;
      }

      BehaviorResult result = OnUpdate(dt);

      if (result != BehaviorResult.None)
      {
        OnLeave();
        _active = false;
      }

      return result;
    }

    public virtual void OnEnter()
    {
    }

    public virtual void OnLeave()
    {
    }

    public abstract BehaviorResult OnUpdate(float dt);
  }
}
