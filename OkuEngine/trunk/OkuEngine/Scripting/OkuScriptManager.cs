using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using OkuEngine.Api;

namespace OkuEngine.Scripting
{
  /// <summary>
  /// Provides special script manager function that only make sense in the game engine.
  /// </summary>
  public class OkuScriptManager : ScriptManager
  {
    /// <summary>
    /// Initializes the basic runtime environment for the scripts.
    /// Sets up classes and functions to be used by scripts.
    /// </summary>
    public void Initialize()
    {
      _engine.SetGlobalFunction("print", new Action<string>((message) => OkuManagers.Logger.LogInfo(message)));

      ExposeApi();

      StreamReader reader = new StreamReader(Assembly.GetAssembly(typeof(OkuScriptManager)).GetManifestResourceStream("OkuEngine.OkuRuntime.js"));
      string code = null;
      try
      {
        code = reader.ReadToEnd();
      }
      finally
      {
        reader.Close();
      }
      _engine.Execute(code);
    }

    /// <summary>
    /// Checks if the given type is supported by the javascript engine.
    /// </summary>
    /// <param name="type">The type to check.</param>
    /// <returns>True if the type is supported, else false.</returns>
    public static bool IsSupportedType(Type type)
    {
      return type == typeof(int) || type == typeof(double) || type == typeof(string) || type == typeof(bool);
    }

    /// <summary>
    /// Exposes all public methods of OkuApi to the javascript engine.
    /// The names of the methods are prefixed by "oku". Methods with unsupported
    /// parameter or return types are skipped.
    /// </summary>
    private void ExposeApi()
    {
      OkuApi api = OkuApi.Instance;

      MethodInfo[] allMethods = api.GetType().GetMethods(BindingFlags.InvokeMethod | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
      foreach (MethodInfo method in allMethods)
      {
        List<Type> types = new List<Type>();

        bool hasUnsupportedType = false;

        //Check that parameters types are supported
        foreach (ParameterInfo param in method.GetParameters())
        {
          if (!IsSupportedType(param.ParameterType))
            hasUnsupportedType = true;
          else
            types.Add(param.ParameterType);
        }

        //Check that return type is supported
        if (method.ReturnType != typeof(void))
        {
          if (!IsSupportedType(method.ReturnType))
            hasUnsupportedType = true;
          else
            types.Add(method.ReturnType);
        }

        if (hasUnsupportedType)
        {
          OkuManagers.Logger.LogError("API method " + method.Name + " has unsupported parameter types!");
          continue;
        }


        Type baseType = method.GetDelegateType();
        if (baseType != null)
        {
          string funcName = "oku" + method.Name;
          Type delType = baseType.MakeGenericType(types.ToArray());
          _engine.SetGlobalFunction(funcName, Delegate.CreateDelegate(delType, api, method));
        }
        else
        {
          OkuManagers.Logger.LogError("Method " + method.Name + " could not be converted to a delegate type!");
        }
      }
    }

    /// <summary>
    /// Is called every frame to update the script engine.
    /// </summary>
    /// <param name="dt">The time passed since the last frame.</param>
    public override void Update(float dt)
    {
      _engine.SetGlobalValue("timeDelta", (double)dt);
    }

  }
}
