using System;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Decorator that repeats the child node for the given amount of times.
  /// This works by changing the result of the child to None until it was
  /// executed a given amount of times.
  /// </summary>
  public class Repeater : Decorator
  {
    private int _repititions = 0;
    private int _numRuns = 0;

    public Repeater(int repititions)
    {
      _repititions = repititions;
    }

    public override void OnEnter()
    {
      _numRuns = 0;
    }

    public override BehaviorResult Decorate(BehaviorResult result)
    {
      _numRuns++;
      if (_numRuns < _repititions)
        return BehaviorResult.None;
      else
        return result;
    }
  }
}
