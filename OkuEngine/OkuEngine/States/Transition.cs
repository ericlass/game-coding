using System;
using OkuEngine.Collections;

namespace OkuEngine.States
{
  public class Transition
  {
    public Transition()
    {
    }

    public Transition(string source, string target, int priority, Func<BlackBoard, bool> shouldTransition)
    {
      SourceState = source;
      TargetState = target;
      Priority = priority;
      ShouldTransition = shouldTransition;
    }

    public string SourceState { get; set; }
    public string TargetState { get; set; }
    public int Priority { get; set; }
    public Func<BlackBoard, bool> ShouldTransition { get; set; }
  }
}
