using System;
using OkuBase.Graphics;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a color the entity is tinted with during rendering.
  /// </summary>
  public class ColorComponent : IComponent
  {
    private Color _color = Color.White;

    /// <summary>
    /// Creates a new color component with a all white tint.
    /// </summary>
    public ColorComponent()
    {
    }

    /// <summary>
    /// Creates a new color component with the given tint color.
    /// </summary>
    /// <param name="color">The tint color.</param>
    public ColorComponent(Color color)
    {
      _color = color;
    }

    /// <summary>
    /// Gets or sets the tint color of this component.
    /// </summary>
    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

    /// <summary>
    /// Gets if the component can be assigned multiple times to the same entity.
    /// </summary>
    public bool IsMultiAssignable
    {
      get{ return true; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public string Name
    {
      get{ return "vertexcolor"; }
    }

    /// <summary>
    /// Creates a deep copy of this component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public IComponent Copy()
    {
      return new ColorComponent(_color);
    }

  }
}
