using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Base class for all composite nodes. A composite node is a node that itself contains a list of child nodes.
  /// Those child nodes are processed in some order. The result of the composite node depends on the results
  /// of the children.
  /// </summary>
  public abstract class Composite : BehaviorTreeNode
  {
    private List<BehaviorTreeNode> _children = new List<BehaviorTreeNode>();

    private int _childIndex = 0;

    /// <summary>
    /// Gets or sets the list of children of this composite node.
    /// </summary>
    public List<BehaviorTreeNode> Children
    {
      get { return _children; }
      set { _children = value; }
    }

    /// <summary>
    /// Adds a new child node at the end of the list.
    /// Return this composite node so that multiple Add calls can be chained.
    /// </summary>
    /// <param name="node">The child node to be added.</param>
    /// <returns>This composite node.</returns>
    public Composite Add(BehaviorTreeNode node)
    {
      _children.Add(node);
      return this;
    }

    public override void OnEnter()
    {
      _childIndex = GetFirstChildIndex();
    }

    public override BehaviorResult OnUpdate(float dt)
    {
      //Update currently active child node
      BehaviorTreeNode current = _children[_childIndex];
      BehaviorResult lastResult = current.Update(dt);

      if (lastResult != BehaviorResult.None)
      {
        //If child succeeded or failed, move to next node or fail/succeed.
        BehaviorResult newResult;
        int nextIndex = GetNextChildIndex(_childIndex, lastResult, out newResult);
        if (newResult != BehaviorResult.None)
          return newResult;
        else
          _childIndex = nextIndex;
      }

      return BehaviorResult.None;
    }

    /// <summary>
    /// Implementing classes implement this to specify the index of the first child node to be processed.
    /// </summary>
    /// <returns></returns>
    public abstract int GetFirstChildIndex();

    // Should calculate the next child index from the given data.
    // It is called whenever a child fails or succeeds.
    // The "result" out-parameter controls what happens after this.
    // If "result" is None, the next child (given by the returned index) is activated.
    // If "result" is not None, the composite returns it and therefore finishes processing.
    public abstract int GetNextChildIndex(int lastIndex, BehaviorResult lastResult, out BehaviorResult result);
  }
}
