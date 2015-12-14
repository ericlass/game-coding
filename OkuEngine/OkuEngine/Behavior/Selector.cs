using System;

namespace OkuEngine.Behavior
{
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
          result = BehaviorResult.None;
          return lastIndex++;

        case BehaviorResult.Success:
          result = BehaviorResult.Success;
          return -1;

        default:
          throw new ArgumentException("Unknown BehaviorResult: " + lastResult.ToString());
      }
    }
  }
}
