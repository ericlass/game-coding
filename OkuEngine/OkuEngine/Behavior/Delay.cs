using System;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Does nothing but waiting for a given amount of time and then succeeds.
  /// </summary>
  public class Delay : BehaviorTreeNode
  {
    private float _delay;
    private float _current;

    /// <summary>
    /// Creates a new delay node with the given delay.
    /// </summary>
    /// <param name="delay">The delay in seconds.</param>
    public Delay(float delay)
    {
      _delay = delay;
    }

    public override void OnEnter()
    {
      _current = _delay;
    }

    public override BehaviorResult OnUpdate(float dt)
    {
      _current -= dt;
      if (_current <= 0.0f)
        return BehaviorResult.Success;

      return BehaviorResult.None;
    }

  }
}
