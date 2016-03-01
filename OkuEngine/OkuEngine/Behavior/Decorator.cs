using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Base class for all decorator nodes.
  /// A decorator has exactly one child node and somehow changes the result of this child node.
  /// </summary>
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

    /// <summary>
    /// Implementing classes can change the actual result the child node returned.
    /// </summary>
    /// <param name="result">The result of the child node.</param>
    /// <returns>The decorated result to return.</returns>
    public abstract BehaviorResult Decorate(BehaviorResult result);
  }
}
