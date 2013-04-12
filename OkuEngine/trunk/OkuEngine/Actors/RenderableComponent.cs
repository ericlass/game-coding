using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.States;
using OkuEngine.Rendering;
using Newtonsoft.Json;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a state component that contains a renderable
  /// for rendering.
  /// </summary>
  public class RenderableComponent : IStateComponent
  {
    public const string ComponentName = "renderable";

    private State _owner = null;
    private IRenderable _renderable = null;

    /// <summary>
    /// Gets or sets the owning state of the component.
    /// </summary>
    public State Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    /// <summary>
    /// Gets or sets the renderable of the component.
    /// </summary>
    [JsonPropertyAttribute]
    public IRenderable Renderable
    {
      get { return _renderable; }
      set { _renderable = value; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public string ComponentTypeName
    {
      get { return ComponentName; }
    }

    public bool AfterLoad()
    {
      return _renderable.AfterLoad();
    }

  }
}
