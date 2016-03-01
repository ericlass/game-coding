using System;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Behavior node that simply logs a text to the debug output and then succeeds.
  /// </summary>
  public class LogText : BehaviorTreeNode
  {
    private string _text = null;

    /// <summary>
    /// Creates a new LogText behavior node that logs the given text.
    /// </summary>
    /// <param name="text">The text to be logged.</param>
    public LogText(string text)
    {
      _text = text;
    }

    public override BehaviorResult OnUpdate(float dt)
    {
      System.Diagnostics.Debug.WriteLine(_text);
      return BehaviorResult.Success;
    }

  }
}
