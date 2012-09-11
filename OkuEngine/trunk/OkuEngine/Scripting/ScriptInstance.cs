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
    private Parameter[] _parameters = null;
    private object[] _inputValues = null;
    private FunctionInstance _function = null;
    private ScriptEngine _engine = null;
    private Dictionary<string, Parameter> _parameterMap = null;

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
    /// Creates a new script instance that uses the given function instance.
    /// </summary>
    /// <param name="function">The compiled script function.</param>
    /// <param name="engine">The script engine that was used to compile the script.</param>
    /// <param name="source">The source code of the script.</param>
    /// <param name="inputs">The input parameters of the script.</param>
    /// <param name="outputs">The output parameters of the script.</param>
    public ScriptInstance(FunctionInstance function, string source, ScriptEngine engine, Parameter[] parameters)
    {
      _function = function;
      _source = source;
      _engine = engine;
      _parameters = parameters;
      Init();
    }

    public void Init()
    {
      if (_parameters != null && _parameters.Length > 0)
      {
        _parameterMap = new Dictionary<string, Parameter>();
        int inputs = 0;
        foreach (Parameter param in _parameters)
        {
          if (param.IsInput)
            inputs++;

          _parameterMap.Add(param.Name, param);
        }

        _inputValues = new object[inputs];
      }
    }

    public Parameter this[string name]
    {
      get { return _parameterMap[name]; }
    }

    private object[] GetInputValues()
    {
      if (_inputValues != null && _inputValues.Length > 0)
      {
        for (int i = 0; i < _parameters.Length; i++)
        {
          if (_parameters[i].IsInput)
            _inputValues[i] = _parameters[i].RawValue;
        }

        return _inputValues;
      }
      return null;
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
        //Create global variables for return parameters
        if (_parameters != null && _parameters.Length > 0)
        {
          foreach (Parameter param in _parameters)
          {
            if (!param.IsInput)
              _engine.SetGlobalValue(param.Name, Undefined.Value);
          }
        }

        //Call script
        _function.Call(null, GetInputValues());

        //Get values of return values after execution
        if (_parameters != null && _parameters.Length > 0)
        {
          foreach (Parameter param in _parameters)
          {
            if (!param.IsInput)
            {
              param.SetValue(_engine.GetGlobalValue(param.Name));
              _engine.SetGlobalValue(param.Name, Undefined.Value);
            }
          }
        }
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
