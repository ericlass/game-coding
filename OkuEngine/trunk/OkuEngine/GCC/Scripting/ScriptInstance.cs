using System;
using System.Reflection;

namespace OkuEngine.GCC.Scripting
{
  public class ScriptInstance
  {
    private Assembly _assembly = null;

    private Type _scriptType = null;
    private object _instance = null;
    private MethodInfo _mainMethod = null;

    public ScriptInstance(Assembly scriptAssembly)
    {
      _assembly = scriptAssembly;
    }

    public bool Init()
    {
      //Find script type
      Type scriptType = null;
      foreach (Type currentType in _assembly.GetTypes())
      {
        if (currentType.Name.StartsWith("Script"))
        {
          scriptType = currentType;
          break;
        }
      }

      //No script type found
      if (scriptType == null)
        return false;

      _scriptType = scriptType;

      //Find constructor
      ConstructorInfo constructor = _scriptType.GetConstructor(Type.EmptyTypes);

      //No default constuctor found
      if (constructor == null)
        return false;

      _instance = constructor.Invoke(null);

      //Find main method
      MethodInfo mainMethod = null;
      try
      {
        mainMethod = _scriptType.GetMethod("Main", BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null);
      }
      catch (AmbiguousMatchException)
      {
        //LOG: More than one method with the given parameters found
        return false;
      }

      if (mainMethod == null)
      {
        //LOG: No method found
        return false;
      }

      _mainMethod = mainMethod;

      return true;
    }

    public void Run()
    {
      if (_instance == null || _mainMethod == null)
        throw new Exception();

      _mainMethod.Invoke(_instance, null);

    }

    public void SetField<T>(string name, T value)
    {
      _scriptType.InvokeMember(name, BindingFlags.SetField, null, _instance, new Object[] { value });
    }

    public T GetField<T>(string name)
    {
      return (T)_scriptType.InvokeMember(name, BindingFlags.GetField, null, _instance, null);
    }

    public T SetProperty<T>(string name, T value)
    {
      return (T)_scriptType.InvokeMember(name, BindingFlags.SetProperty, null, _instance, new Object[] { value });
    }

    public T GetProperty<T>(string name)
    {
      return (T)_scriptType.InvokeMember(name, BindingFlags.GetProperty, null, _instance, null);
    }

    public T ExecuteMethod<T>(string name, object[] args)
    {
      return (T)_scriptType.InvokeMember(name, BindingFlags.InvokeMethod, null, _instance, args);
    }

    public void ExecuteMethod(string name, object[] args)
    {
      _scriptType.InvokeMember(name, BindingFlags.InvokeMethod, null, _instance, args);
    }

    public Delegate GetDelegate(string methodName, Type delegateType)
    {
      MethodInfo method = null;
      try
      {
        method = _scriptType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null);
      }
      catch (AmbiguousMatchException)
      {
        return null;
      }

      if (method == null)
        return null;

      return Delegate.CreateDelegate(delegateType, _instance, method);
    }
  }
}
