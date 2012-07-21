using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public class CameraNode : SceneNode
  {
    private bool _enabled = true;
    private bool _debugCamera = false;
    private SceneNode _target = null;

    public CameraNode(Matrix3 transform, AABB area) : base(-1, "Camera", transform)
    {
      _props.Tint = Color.Yellow;
      _props.Area = area;
    }

    public bool Enabled
    {
      get { return _enabled; }
      set { _enabled = value; }
    }

    public override bool Render(Scene scene)
    {
      if (_debugCamera)
      {
        //TODO: Draw debug stuff
      }

      return true;
    }

    public override bool Restore(Scene scene)
    {
      return true;
    }

    public override bool IsVisible(Scene scene)
    {
      return _enabled;
    }

    public bool SetViewTransform(Scene scene)
    {
      if (_target != null)
      {
        //TODO: Center camrea to target. It might be anywhere in the scene hierarchy.
      }
      OkuManagers.Renderer.SetViewTransform(_props.ToParent);

      return true;
    }

    /// <summary>
    /// Gets or sets the 
    /// </summary>
    public SceneNode Target
    {
      get { return _target; }
      set { _target = value; }
    }

    /// <summary>
    /// Calculates the matrix that transforms from world space into view space.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>The matrix that transforms from world space into view space.</returns>
    public Matrix3 GetWorldViewMatrix(Scene scene)
    {
      return GetFromWorld();
    }

    /// <summary>
    /// Gets the view matrix that transforms stuff from camera parent space to view space.
    /// </summary>
    public Matrix3 View
    {
      get { return _props.FromParent; }
    }

  }
}
