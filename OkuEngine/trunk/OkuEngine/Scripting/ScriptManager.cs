using System;
using System.Text;
using Jurassic;
using Jurassic.Library;

namespace OkuEngine.Scripting
{
  /// <summary>
  /// Handles compiling and error checking of scripts.
  /// </summary>
  public class ScriptManager
  {
    private const string ScriptFunctionName = "okuscriptfunc";
    private const string ScriptCheckFunctionName = "okucompileckeckfunc";

    protected ScriptEngine _engine = null;

    /// <summary>
    /// Creates a new script manager.
    /// </summary>
    public ScriptManager()
    {
      _engine = new ScriptEngine();
      _engine.ForceStrictMode = true; //Strict mode must be used to force local variables
    }

    private string GetNextFunctionName()
    {
      return ScriptFunctionName + KeySequence.NextValue(KeySequence.ScriptSequence);
    }

    private string GetFinalScript(string scriptCode, string functionName, Parameter[] parameters)
    {
      StringBuilder parameterList = new StringBuilder();
      if (parameters != null && parameters.Length > 0)
      {
        bool first = true;
        foreach (Parameter param in parameters)
        {
          if (param.IsInput)
          {
            if (!first)
              parameterList.Append(", ");
            else
              first = false;

            parameterList.Append(param.Name);
          }
        }
      }

      //Create script function around code
      string finalCode =
        "function " + functionName + "(" + parameterList.ToString() + ")" +
        Environment.NewLine + "{" + Environment.NewLine + scriptCode + Environment.NewLine + "}";

      return finalCode;
    }

    /// <summary>
    /// Compiles the given script and returns the result of the compilation
    /// that can be used to run the script.
    /// </summary>
    /// <param name="code">The code of the script.</param>
    /// <returns>The compiled script or null if an error occured.</returns>
    public ScriptInstance CompileScript(string code, Parameter[] parameters)
    {
      string functionName = GetNextFunctionName();

      //Compile script
      try
      {
        _engine.Execute(GetFinalScript(code, functionName, parameters));
      }
      catch (Exception ex)
      {
        OkuManagers.Logger.LogError("Script could not be compiled! Cause: " + ex.Message + Environment.NewLine + code);
        return null;
      }

      //Get handle to compiled function
      FunctionInstance funcInst = (FunctionInstance)_engine.GetGlobalValue(functionName);

      return new ScriptInstance(funcInst, code, _engine, parameters);
    }

    /// <summary>
    /// Checks if the given script code is compilable.
    /// </summary>
    /// <param name="code">The code to be checked.</param>
    /// <param name="parameters">The parameters of the function.</param>
    /// <returns>Null if the script is compiler clean, else the compiler error message.</returns>
    public string CheckScript(string code, Parameter[] parameters)
    {
      try
      {
        _engine.Execute(GetFinalScript(code, ScriptCheckFunctionName, parameters));
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
      return null;
    }

  }
}
