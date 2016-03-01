using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Decorator that inverts the result of the child node.
  /// Fail becomes Success, Success becomes fail while None stays None.
  /// </summary>
  public class Inverter : Decorator
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
          return BehaviorResult.Fail;

        default:
          throw new ArgumentException("Unknown BehaviorResult: " + result.ToString());
      }
    }
  }
}
