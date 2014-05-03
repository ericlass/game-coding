using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.States
{
  public class StateMachine
  {
    private StateMap _states = new StateMap();
    private List<Transition> _transitions = new List<Transition>();
    private string _initialState = null;
    private GameObjectBase _gameObject = null;

    private Dictionary<string, Transition> _transitionMap = null;
    private string _currentState = null;
    private OnEventDelegate _eventListener = null;
    private bool _initialized = false;

    public StateMachine()
    {
    }

    public StateMachine(GameObjectBase gameObject)
    {
      _gameObject = gameObject;
    }

    private OnEventDelegate GetEventListener()
    {
      if (_eventListener == null)
        _eventListener = new OnEventDelegate(OnEvent);

      return _eventListener;
    }

    public StateMap States
    {
      get { return _states; }
    }

    public List<Transition> Transitions
    {
      get { return _transitions; }
    }

    public string InitialState
    {
      get { return _initialState; }
      set { _initialState = value; }
    }

    public GameObjectBase GameObject
    {
      get { return _gameObject; }
      set { _gameObject = value; }
    }

    public string CurrentState
    {
      get { return _currentState; }
      set
      {
        if (_currentState != null)
          _states[_currentState].Leave(_gameObject);

        if (!_states.ContainsKey(value))
          throw new OkuBase.OkuException("State '" + value + "' is not available in this state machine!");

        _currentState = value;
        _states[_currentState].Enter(_gameObject);
      }
    }

    public void Init()
    {
      if (_initialized)
        throw new OkuBase.OkuException("Cannot initialize a state machine that has already been initialized!");

      _currentState = _initialState;

      //Not sure if should be done. If a state plays a sound on entering, than the scene will make a lot of noise when it is loaded.
      //if (_currentState != null)
        //_states[_currentState].Enter();

      foreach (StateBase state in _states.Values)
        state.Init();

      _transitionMap = new Dictionary<string, Transition>();
      foreach (Transition transition in _transitions)
      {
        GameData.Instance.EventQueue.AddListener(transition.EventId, GetEventListener());
        _transitionMap.Add(transition.EventId, transition);
      }

      _initialized = true;
    }

    private void OnEvent(string eventId, object data, string objectId)
    {
      if (!_initialized)
        throw new OkuBase.OkuException("Event received in a non-initialized state machine!");

      if (_transitionMap.ContainsKey(eventId))
      {
        Transition trans = _transitionMap[eventId];

        if (_gameObject != null && trans.ForOwningObject)
        {
          if (_gameObject.Id != objectId)
            return;
        }

        if (trans.Conditions != null)
        {
          foreach (Condition cond in trans.Conditions)
          {
            if (!cond.Matches(_gameObject))
              return;
          }
        }

        if (trans.TransitAction != null)
          trans.TransitAction();

        _states[_currentState].Leave(_gameObject);
        _currentState = trans.TargetState;
        _states[_currentState].Enter(_gameObject);
      }
    }

    public void Finish()
    {
      if (!_initialized)
        throw new OkuBase.OkuException("Cannot finish a state machine that has not been initialized!");

      foreach (Transition trans in _transitionMap.Values)
        GameData.Instance.EventQueue.RemoveListener(trans.EventId, GetEventListener());

      foreach (StateBase state in _states.Values)
        state.Finish();

      _transitionMap = null;

      _initialized = false;
    }

    public void Clear()
    {
      if (_initialized)
        throw new OkuBase.OkuException("Cannot clear a state machine that is already initialized! Finish it first!");

      _states.Clear();
      _transitions.Clear();
    }

    //Continue: How is the state machine initialized. It has to know all states and transitions to register for the events. In the end they will be loaded from a file.
    //-> When a scene is set active, all game objects Init() methods are called. So, the state machines Init() method can be called there too.

    //How to get states to register themselves to the state factory? Maybe via reflections?
    //-> With Reflections, just like the other factories.

  }
}
