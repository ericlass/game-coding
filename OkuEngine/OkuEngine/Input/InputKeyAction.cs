using System;

namespace OkuEngine.Input
{
  /// <summary>
  /// Combines an input key with an input action.
  /// Instances are immutable.
  /// </summary>
  public class InputKeyAction
  {
    private InputKey _key;
    private InputAction _action;

    private int _code = 0;

    /// <summary>
    /// Creates a new input key action with the given parameters.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="action">The action.</param>
    public InputKeyAction(InputKey key, InputAction action)
    {
      _key = key;
      _action = action;

      _code = (int)_key | (int)_action;
    }

    /// <summary>
    /// Gets the key.
    /// </summary>
    public InputKey Key
    {
      get { return _key; }
    }

    /// <summary>
    /// Gets the type of action.
    /// </summary>
    public InputAction Action
    {
      get { return _action; }
    }    

    /// <summary>
    /// Gets the internal key action code.
    /// </summary>
    internal int Code
    {
      get { return _code; }
    }

  }
}
