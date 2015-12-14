using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  public abstract class Decorator : BehaviorTreeNode
  {
    private BehaviorTreeNode _child = null;

    public BehaviorTreeNode Child
    {
      get { return _child; }
      set { _child = value; }
    }

    public override BehaviorResult OnUpdate(float dt)
    {
      BehaviorResult result = _child.Update(dt);
      if (result != BehaviorResult.None)
        return Decorate(result);

      return BehaviorResult.None;
    }

    public abstract BehaviorResult Decorate(BehaviorResult result);
  }
}
