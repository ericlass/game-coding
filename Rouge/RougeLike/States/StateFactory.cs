using System;
using System.Collections.Generic;
using System.Reflection;

namespace RougeLike.States
{
  public class StateFactory
  {
    private static StateFactory _instance = null;

    public static StateFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new StateFactory();

        return _instance;
      }
    }

    private Dictionary<string, Func<StateBase>> _constructors = new Dictionary<string, Func<StateBase>>();

    private StateFactory()
    {
      Assembly assembly = this.GetType().Assembly;
      List<Type> types = GameUtil.GetTypesInhertingFromClass(typeof(StateBase), assembly);
      foreach (Type t in types)
      {
        StateBase state = assembly.CreateInstance(t.FullName) as StateBase;

        RegisterConstructor(state.Id, () => assembly.CreateInstance(t.FullName) as StateBase);
      }
    }

    public bool RegisterConstructor(string stateId, Func<StateBase> constructor)
    {
      if (_constructors.ContainsKey(stateId))
        return false;

      _constructors.Add(stateId, constructor);
      return true;
    }

    public StateBase CreateState(string stateId)
    {
      if (!_constructors.ContainsKey(stateId))
        throw new OkuBase.OkuException("Unknown state id: " + stateId);

      return _constructors[stateId]();
    }

  }
}
