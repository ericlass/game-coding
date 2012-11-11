using System;
using System.Xml;
using System.Collections.Generic;
using Jurassic;
using Jurassic.Library;

namespace OkuEngine.Scripting
{
  /// <summary>
  /// Defines a single script instance that can be used to execute a compiled script over and over.
  /// </summary>
  public class ScriptInstance
  {
    private string _source = null;
    private FunctionInstance _function = null;
    private ScriptEngine _engine = null;

    /// <summary>
    /// Creates a new script instance that uses the given function instance.
    /// </summary>
    /// <param name="function">The compiled script function.</param>
    /// <param name="engine">The script engine that was used to compile the script.</param>
    /// <param name="source">The source code of the script.</param>
    public ScriptInstance(FunctionInstance function, string source, ScriptEngine engine)
    {
      _function = function;
      _source = source;
      _engine = engine;
    }

    /// <summary>
    /// Gets the script source code that was used to compile.
    /// </summary>
    public string Source
    {
      get { return _source; }
    }

    /// <summary>
    /// Executes this script instance.
    /// </summary>
    public bool Run()
    {
      try
      {
        long tick1, tick2, freq;
        Kernel32.QueryPerformanceFrequency(out freq);
        Kernel32.QueryPerformanceCounter(out tick1);

        //Call script
        _function.Call(null, null);

        Kernel32.QueryPerformanceCounter(out tick2);
        float time = (tick2 - tick1) / ((float)freq / 1000);
        OkuManagers.Logger.LogInfo("Script execution took " + time.ToString("0.######") + "ms");
      }
      catch (Exception ex)
      {
        OkuManagers.Logger.LogError("Error while executing script! Cause: " + ex.Message);
        return false;
      }
      return true;
    }

  }
}
