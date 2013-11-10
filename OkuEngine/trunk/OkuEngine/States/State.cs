using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine.States
{
  /// <summary>
  /// Defines the base for states.
  /// State definition and instance share a lot of data and this base defines them.
  /// </summary>
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public class State : IStoreable
  {
    protected string _name = null;
    protected ComponentManager _components = new ComponentManager();

    /// <summary>
    /// Gets the name of the state.
    /// </summary>
    [JsonPropertyAttribute]
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    /// <summary>
    /// Gets or sets the components of the state.
    /// </summary>
    [JsonPropertyAttribute]
    public ComponentManager Components
    {
      get { return _components; }
      set { _components = value; }
    }

    /// <summary>
    /// Sets the name of the state.
    /// </summary>
    /// <param name="name">The new name of the state.</param>
    internal void SetName(string name)
    {
      _name = name;
    }

    public bool AfterLoad()
    {
      return _components.AfterLoad();
    }

  }
}
