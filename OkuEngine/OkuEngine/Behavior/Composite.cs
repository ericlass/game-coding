using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  public abstract class Composite : BehaviorTreeNode
  {
    private List<BehaviorTreeNode> _children = null;

    private int _childIndex = 0;

    public List<BehaviorTreeNode> Children
    {
      get { return _children; }
      set { _children = value; }
    }

    public override void OnEnter()
    {
      _childIndex = GetFirstChildIndex();
    }

    public override BehaviorResult OnUpdate(float dt)
    {
      BehaviorTreeNode current = _children[_childIndex];
      BehaviorResult lastResult = current.Update(dt);

      if (lastResult != BehaviorResult.None)
      {
        BehaviorResult newResult;
        int nextIndex = GetNextChildIndex(_childIndex, lastResult, out newResult);
        if (newResult != BehaviorResult.None)
          return newResult;
        else
          _childIndex = nextIndex;
      }

      return BehaviorResult.None;
    }

    public abstract int GetFirstChildIndex();

    // Should calculate the next child index from the given data.
    // It is called whenever a child fails or succeeds.
    // The "result" out-parameter controls what happens after this.
    // If "result" is null, the next child (given by the returned index) is activated.
    // If "result" is not null, the composite returns it and therefore finishes processing.
    public abstract int GetNextChildIndex(int lastIndex, BehaviorResult lastResult, out BehaviorResult result);
  }
}
