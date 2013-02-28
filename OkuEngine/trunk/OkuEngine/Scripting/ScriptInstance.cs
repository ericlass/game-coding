using System;
using System.Xml;
using System.Collections.Generic;
using Jurassic;
using Jurassic.Library;
using Newtonsoft.Json;

namespace OkuEngine.Scripting
{
  /// <summary>
  /// Defines a single script instance that can be used to execute a compiled script over and over.
  /// </summary>
  [JsonObjectAttribute(MemberSerialization.OptIn)]
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
    [JsonPropertyAttribute]
    public string Source
    {
      get { return _source; }
      set { _source = value; }
    }

    /// <summary>
    /// Gets the script engine that the script is running in.
    /// </summary>
    internal ScriptEngine Engine
    {
      get { return _engine; }
      set { _engine = value; }
    }

    internal FunctionInstance Function
    {
      get { return _function; }
      set { _function = value; }
    }

    /// <summary>
    /// Executes this script instance.
    /// </summary>
    public bool Run()
    {
      try
      {
        /*long tick1, tick2, freq;
        Kernel32.QueryPerformanceFrequency(out freq);
        Kernel32.QueryPerformanceCounter(out tick1);*/

        //Call script
        _function.Call(null, null);

        /*Kernel32.QueryPerformanceCounter(out tick2);
        float time = (tick2 - tick1) / ((float)freq / 1000);
        OkuManagers.Instance.Logger.LogInfo("Script execution took " + time.ToString("0.######") + "ms");*/
      }
      catch (Exception ex)
      {
        OkuManagers.Instance.Logger.LogError("Error while executing script! Cause: " + ex.Message);
        return false;
      }
      return true;
    }

    /// <summary>
    /// Executes this script instance with the given parameters.
    /// The parameters must all be of a type that is supported
    /// the script engine.
    /// </summary>
    /// <param name="parameters">The parameters to pass to the script.</param>
    /// <returns>True if the script was executed successfully, else false.</returns>
    public bool Run(params object[] parameters)
    {
      bool result = false;
      try
      {
        int paramNum = 1;
        foreach (object param in parameters)
        {
          if (OkuScriptManager.IsSupportedType(param.GetType()))
          {
            _engine.SetGlobalValue("param" + paramNum, param);
          }
          else
          {
            OkuManagers.Instance.Logger.LogError("Parameter " + paramNum + " is of a type that is not supported by the script engine! Script: " + _source);
            return false;
          }
          paramNum++;
        }

        result = Run();

        paramNum = 1;
        foreach (object param in parameters)
        {
          _engine.SetGlobalValue("param" + paramNum, Undefined.Value);
        }
      }
      catch (Exception ex)
      {
        OkuManagers.Instance.Logger.LogError("Error while executing script! Cause: " + ex.Message);
        return false;
      }

      return result;
    }

  }
}
