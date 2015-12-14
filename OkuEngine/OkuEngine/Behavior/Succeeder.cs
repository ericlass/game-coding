using System;

namespace OkuEngine.Behavior
{
  public class Succeeder : Decorator
  {
    public override BehaviorResult Decorate(BehaviorResult result)
    {
      return BehaviorResult.Success;
    }
  }
}
