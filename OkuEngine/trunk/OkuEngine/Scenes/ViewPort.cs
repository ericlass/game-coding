using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// Specified the delegate for a viewport change event handler. Should only be implemented by the Renderer.
  /// </summary>
  /// <param name="sender">The view port that fired the change event.</param>
  public delegate void ViewPortChangeEventHandler(ViewPort sender);

  /// <summary>
  /// Species the part of the world space that is currently shown on screen.
  /// </summary>
  public class ViewPort
  {
    private Vector2f _center = Vector2f.Zero;
    private Vector2f _scale = Vector2f.One;
    private float _halfWidth = 0;
    private float _halfHeight = 0;

    private bool _valid = false;
    private Matrix3 _screenToWorld = Matrix3.Identity;
    private Rectangle2f _boundingBox;

    /// <summary>
    /// Create a new viewport centered at the world space coordinate (0,0)
    /// and width the given width and height.
    /// </summary>
    /// <param name="width">The width of the viewport in world space units.</param>
    /// <param name="height">The height of the viewport in world space units.</param>
    public ViewPort(int width, int height)
    {
      _halfWidth = width / 2.0f;
      _halfHeight = height / 2.0f;
    }

    /// <summary>
    /// Creates a new viewport with the given boundaries.
    /// The boundaries are inclusive.
    /// </summary>
    /// <param name="left">The left bound of the viewport.</param>
    /// <param name="top">The top bound of the viewport.</param>
    /// <param name="right">The right bound of the viewport.</param>
    /// <param name="bottom">The bottom bound of the viewport.</param>
    public ViewPort(int left, int top, int right, int bottom)
    {
      _halfWidth = (right - left) / 2.0f;
      _halfHeight = (top - bottom) / 2.0f;
      _center = new Vector2f(left + _halfWidth, bottom + _halfHeight);
    }

    /// <summary>
    /// Event that is triggered when any parameter of the viewport is changed.
    /// The renderer should listen to this event and change the view of the scene
    /// accordingly.
    /// </summary>
    public event ViewPortChangeEventHandler Change = null;

    /// <summary>
    /// Is called when any of the viewport parameters is changed.
    /// </summary>
    /// <param name="sender">The viewport that triggered the event.</param>
    public virtual void OnChange(ViewPort sender)
    {
      _valid = false;
      if (Change != null)
        Change(sender);
    }

    /// <summary>
    /// Gets or sets the center of the viewport.
    /// </summary>
    public Vector2f Center
    {
      get { return _center; }
      set 
      {
        _center = value;
        OnChange(this);
      }
    }

    /// <summary>
    /// Gets or sets the scale of the viewport.
    /// </summary>
    public Vector2f Scale
    {
      get { return _scale; }
      set
      { 
        _scale = value;
        OnChange(this);
      }
    }

    /// <summary>
    /// Gets or sets the left border of the viewport taking into account scale.
    /// </summary>
    public float Left
    {
      get { return _center.X - (_halfWidth * _scale.X); }
      set 
      { 
        _center.X = value + (_halfWidth * _scale.X);
        OnChange(this);
      }
    }

    /// <summary>
    /// Gets or sets the top border of the viewport taking into account scale.
    /// </summary>
    public float Top
    {
      get { return _center.Y + (_halfHeight * _scale.Y); }
      set 
      { 
        _center.Y = value - (_halfHeight * _scale.Y);
        OnChange(this);
      }
    }

    /// <summary>
    /// Gets or sets the right border of the viewport taking into account scale.
    /// </summary>
    public float Right
    {
      get { return _center.X + (_halfWidth * _scale.X); }
      set
      {
        _center.X = value - (_halfWidth * _scale.X);
        OnChange(this);
      }
    }

    /// <summary>
    /// Gets or sets the bottom border of the viewport taking into account scale.
    /// </summary>
    public float Bottom
    {
      get { return _center.Y - (_halfHeight * _scale.Y); }
      set
      {
        _center.Y = value + (_halfHeight * _scale.Y);
        OnChange(this);
      }
    }

    /// <summary>
    /// Gets the width of the viewport in world space units.
    /// </summary>
    public float Width
    {
      get { return _halfWidth * 2; }
    }

    /// <summary>
    /// Gets the height of the viewport in world space units.
    /// </summary>
    public float Height
    {
      get { return _halfHeight * 2; }
    }

    /// <summary>
    /// Gets the screen space matrix which can be used to tranform coordinates
    /// from screen space to world space. This is really handy for GUI.
    /// </summary>
    public Matrix3 ScreenSpaceMatrix
    {
      get
      {
        if (!_valid)
        {
          //Matrix3 m = Matrix3.CreateScale(1.0f, -1.0f);

          _screenToWorld.LoadIdentity();
          _screenToWorld.Translate(Left, Bottom);
          _screenToWorld.Scale(_scale);

          //_screenToWorld = Matrix3.Multiply(m, _screenToWorld);

          _valid = true;
        }
        return _screenToWorld;
      }
    }

    /// <summary>
    /// Check if the given point is inside of the viewport.
    /// </summary>
    /// <param name="p">The point to check.</param>
    /// <returns>True if the point is inside the viewport, else False.</returns>
    public bool Contains(Vector2f p)
    {
      if (p.X > Right)
        return false;
      if (p.X < Left)
        return false;
      if (p.Y > Top)
        return false;
      if (p.Y < Bottom)
        return false;

      return true;
    }

    /// <summary>
    /// Gets the bounding box of the area the viewport shows.
    /// </summary>
    /// <returns>The bounding box the viewport shows.</returns>
    public Rectangle2f GetBoundingBox()
    {
      if (!_valid)
        _boundingBox = new Rectangle2f(Left, Bottom, Width, Height);
      return _boundingBox;
    }

  }
}
