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

    /// <summary>
    /// Copies the component with all of its data.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public IStateComponent Copy()
    {
      RenderableComponent result = new RenderableComponent();
      result.Renderable = _renderable.Copy();
      return result;
    }

    /// <summary>
    /// Merges the data of the component with the given one.
    /// </summary>
    /// <param name="other">The component to merge into this component.</param>
    /// <returns>True if the merge was successfull, else false.</returns>
    public bool Merge(IStateComponent other)
    {
      if (other != null)
      {
        if (other is RenderableComponent)
        {
          RenderableComponent render = other as RenderableComponent;
          _renderable = render.Renderable.Copy();
        }
        else
          OkuManagers.Instance.Logger.LogError("Trying to merge a " + other.GetType().Name + " with a RenderableStateComponent!");
      }

      return true;
    }

    public bool AfterLoad()
    {
      return _renderable.AfterLoad();
    }

  }
}
