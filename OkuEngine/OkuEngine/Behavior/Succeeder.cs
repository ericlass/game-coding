using System;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Decorator that turns any result of the child node to Success.
  /// </summary>
  public class Succeeder : Decorator
  {
    public override BehaviorResult Decorate(BehaviorResult result)
    {
      return BehaviorResult.Success;
    }
  }
}
