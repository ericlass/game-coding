using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public class CameraNode : SceneNode
  {
    private bool _debugCamera = false;
    private ISceneNode _target = null;

    protected Matrix3 _projection = Matrix3.Indentity;
    protected Matrix3 _view = Matrix3.Indentity;
    protected Vector _offset = Vector.Zero;

    public AABB Area { get; set; }

    public CameraNode(Matrix3 transform, AABB area) : base(-1, "Camera", RenderPass.None, Color.Red, transform)
    {
      Area = area;
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
        //TODO: Make camera stick to target
      }

      //_TODO: view = _props.Matrix.Inverse;

      OkuManagers.Renderer.SetViewTransform(_props.Matrix);

      return true;
    }

    public ISceneNode Target
    {
      get { return _target; }
      set { _target = value; }
    }

    Matrix3 GetWorldViewProjection(Scene scene)
    {
      Matrix3 world = scene.GetTopMatrix();
      Matrix3 view = _props.Matrix;
      Matrix3 worldView = Matrix3.Multiply(world, view);
      //TODO: multiply worldview with projection and return
      return worldView;
    }

    public Matrix3 Projection
    {
      get { return _projection; }
    }

    public Matrix3 View
    {
      get { return View; }
    }

    public Vector Offset
    {
      get { return _offset; }
      set { _offset = value; }
    }

  }
}
