using System;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Composite node that processes all children in order until the first child succeeds or all children failed.
  /// Succeeds as soon as the first child succeeds. Fails if all children fail.
  /// </summary>
  public class Selector : Composite
  {
    public override int GetFirstChildIndex()
    {
      return 0;
    }

    public override int GetNextChildIndex(int lastIndex, BehaviorResult lastResult, out BehaviorResult result)
    {
      switch (lastResult)
      {
        case BehaviorResult.Fail:
          int newIndex = lastIndex + 1;

          //If there are more children left, jump to the next one, else finish with fail
          if (newIndex >= Children.Count)
            result = BehaviorResult.Fail;
          else
            result = BehaviorResult.None;

          return newIndex;

        case BehaviorResult.Success:
          result = BehaviorResult.Success;
          return -1;

        default:
          throw new ArgumentException("Unknown BehaviorResult: " + lastResult.ToString());
      }
    }
  }
}
