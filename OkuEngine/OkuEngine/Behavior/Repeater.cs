using System;

namespace OkuEngine.Behavior
{
  public class Repeater : Decorator
  {
    public int numRuns = 0;

    public int Repititions { get; set; }

    public override void OnEnter()
    {
      numRuns = 0;
    }

    public override BehaviorResult Decorate(BehaviorResult result)
    {
      numRuns++;
      if (numRuns < Repititions)
        return BehaviorResult.None;
      else
        return result;
    }
  }
}
