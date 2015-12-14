using System;

namespace OkuEngine.Behavior
{
  public class Sequence : Composite
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
          result = BehaviorResult.Fail;
          return -1;

        case BehaviorResult.Success:
          result = BehaviorResult.None;
          return lastIndex++;

        default:
          throw new ArgumentException("Unknown BehaviorResult: " + lastResult.ToString());
      }
    }
  }
}
