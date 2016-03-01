using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Base class for all behavior tree nodes.
  /// Manages entering/leaving of the node.
  /// </summary>
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

    /// <summary>
    /// Can be overriden to do processing when the node gets activated. This happens before the first update.
    /// </summary>
    public virtual void OnEnter()
    {
    }

    /// <summary>
    /// Can be overriden to do processing when the node gets deactivated after it succeeded or failed.
    /// </summary>
    public virtual void OnLeave()
    {
    }

    public abstract BehaviorResult OnUpdate(float dt);
  }
}
