using System;
using OkuEngine.States;
using Newtonsoft.Json;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a component that provides a simple transformation
  /// </summary>
  public class TransformComponent : IStateComponent
  {
    public const string ComponentName = "transform";

    private ComponentManager _owner = null;
    private Transformation _transform = new Transformation();

    public ComponentManager Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public string ComponentTypeName
    {
      get { return ComponentName; }
    }

    [JsonPropertyAttribute]
    public Transformation Transform
    {
      get { return _transform; }
      set { _transform = value; }
    }

    public virtual bool AfterLoad()
    {
      return true;
    }

  }
}
