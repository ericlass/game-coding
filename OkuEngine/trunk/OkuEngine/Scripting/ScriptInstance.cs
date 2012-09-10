using System;
using Jurassic;
using Jurassic.Library;

namespace OkuEngine.Scripting
{
  /// <summary>
  /// Defines a single script instance that can be used to execute a compiled script over and over.
  /// </summary>
  public class ScriptInstance
  {
    private FunctionInstance _function = null;

    /// <summary>
    /// Creates a new script instance that uses the given function instance.
    /// </summary>
    /// <param name="function">The compiled script function.</param>
    public ScriptInstance(FunctionInstance function)
    {
      _function = function;
    }

    /// <summary>
    /// Executes this script instance.
    /// </summary>
    public void Run()
    {
      _function.Call(null, null);
    }

  }
}
