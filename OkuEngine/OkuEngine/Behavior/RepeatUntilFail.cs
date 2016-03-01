using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Decorator that repeats the child node until it fails.
  /// </summary>
  public class RepeatUntilFail : Decorator
  {
    public override BehaviorResult Decorate(BehaviorResult result)
    {
      switch (result)
      {
        case BehaviorResult.None:
          return BehaviorResult.None;

        case BehaviorResult.Fail:
          return BehaviorResult.Success;

        case BehaviorResult.Success:
          return BehaviorResult.None;

        default:
          throw new ArgumentException("Unknown BehaviorResult: " + result.ToString());
      }
    }
  }
}
