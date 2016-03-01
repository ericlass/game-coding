using System;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Composite node that processes all childern until the first child fails or all children succeed.
  /// Succeeds if all children succeed. Fails as soon as the first child fails.
  /// </summary>
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
          int newIndex = lastIndex + 1;

          //If there are more children left, jump to the next one, else finish with success
          if (newIndex >= Children.Count)
            result = BehaviorResult.Success;
          else
            result = BehaviorResult.None;

          return newIndex;

        default:
          throw new ArgumentException("Unknown BehaviorResult: " + lastResult.ToString());
      }
    }

  }
}
