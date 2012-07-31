using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OkuEngine.GCC.Scene
{
  public class Scene
  {
    private Stack<Matrix3> _matrixStack = new Stack<Matrix3>();
    private Matrix3 _current = Matrix3.Identity;

    private ViewPort _viewport = new ViewPort(1024, 768);
    private RootNode _root = new RootNode();
    private int test = 0;

    public Scene()
    {
    }

    public RootNode Root
    {
      get { return _root; }
    }

    public bool Render()
    {
      _root.PreRender(this);
      _root.Render(this);
      _root.RenderChildren(this);
      _root.PostRender(this);
      return true;
    }

    public bool Restore()
    {
      return _root.Restore(this);
    }

    public Boolean Update(float dt)
    {
      return _root.Update(this, dt);
    }

    public SceneNode FindActor(int actorId)
    {
      throw new NotImplementedException();
    }

    public void ApplyAndPushTransform(Transformation transform)
    {
      _matrixStack.Push(_current);
      _current = transform.AsMatrix() * _current;
      OkuManagers.Renderer.ApplyAndPushTransform(transform);
    }

    public void PopTransform()
    {
      _current = _matrixStack.Pop();
      OkuManagers.Renderer.PopTransform();
    }

    public Matrix3 CurrentTransform
    {
      get { return _current; }
    }

    public ViewPort Viewport
    {
      get { return _viewport; }
      set { _viewport = value; }
    }

    public Vector ScreenToWorld(int x, int y)
    {
      Point client = OkuManagers.Renderer.Display.PointToClient(new Point(x, y));
      return new Vector(client.X, OkuManagers.Renderer.Display.ClientSize.Height - client.Y);
    }

    public Vector ScreenToDisplay(int x, int y)
    {
      return Viewport.ScreenSpaceMatrix.Transform(ScreenToDisplay(x, y));
    }

  }
}
