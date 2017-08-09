using System;
using OkuMath;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a position either in world or screen space coordinates.
  /// </summary>
  public class PositionComponent : Component
  {
    private Vector2f _position = Vector2f.Zero;
    private Vector2f _previousPosition = Vector2f.Zero;
    private bool _screenSpace = false;

    /// <summary>
    /// Creates a new position component with position [0,0] in world space.
    /// </summary>
    public PositionComponent()
    {
    }

    /// <summary>
    /// Create a new position component with the given position.
    /// </summary>
    /// <param name="position">The position.</param>
    /// <param name="screenSpace">Determines if the position is treated and screen space coordinates or not.</param>
    public PositionComponent(Vector2f position, bool screenSpace)
    {
      _position = position;
      _screenSpace = screenSpace;
    }

    /// <summary>
    /// Gets or sets the position.
    /// </summary>
    public Vector2f Position
    {
      get { return _position; }
      set
      {
        _position = value;
        QueueEvent(EventNames.EntityMoved);
      }
    }

    /// <summary>
    /// Gets or sets the position of the entity from the last frame.
    /// </summary>
    public Vector2f PreviousPosition
    {
      get { return _previousPosition; }
      set { _previousPosition = value; }
    }

    /// <summary>
    /// Gets or sets if the position is treated as screen space coordinates (true) or world coordinates (false).
    /// </summary>
    public bool ScreenSpace
    {
      get { return _screenSpace; }
      set { _screenSpace = value; }
    }

    /// <summary>
    /// Gets if the component can be assigned multiple times to the same entity.
    /// </summary>
    public override bool IsMultiAssignable
    {
      get { return false; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public override string Name
    {
      get{ return "position"; }
    }

    /// <summary>
    /// Creates a deep copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public override Component Copy()
    {
      return new PositionComponent(_position, _screenSpace);
    }

  }
}
