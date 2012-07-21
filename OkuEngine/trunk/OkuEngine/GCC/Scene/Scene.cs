using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public class Scene
  {
    private Dictionary<int, SceneNode> _actorMap = new Dictionary<int, SceneNode>();
    private Stack<Matrix3> _matrixStack = new Stack<Matrix3>();
    private Matrix3 _current = Matrix3.Identity;

    private RootNode _root = new RootNode();
    private CameraNode _camera = new CameraNode(Matrix3.Identity, new AABB());

    public Scene()
    {
    }

    public RootNode Root
    {
      get { return _root; }
      set { _root = value; }
    }

    public CameraNode Camera
    {
      get { return _camera; }
      set { _camera = value; }
    }

    public bool Render()
    {
      if (_root != null && _camera != null)
      {
        //Update camera?
        if (_root.PreRender(this))
        {
          _root.Render(this);
          _root.RenderChildren(this);
          _root.PostRender(this);
          return true;
        }
      }
      return false;
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
      SceneNode result = null;
      _actorMap.TryGetValue(actorId, out result);
      return result;
    }

    public bool AddChild(int actorId, SceneNode node)
    {
      if (!_actorMap.ContainsKey(actorId))
      {
        _actorMap.Add(actorId, node);
        return true;
      }

      return false;
    }

    public bool RemoveChild(int actorId)
    {
      return _actorMap.Remove(actorId);
    }
    
    public void PushAndSetMatrix(Matrix3 matrix)
    {
      _matrixStack.Push(_current);
      _current.Multiply(matrix);
      OkuManagers.Renderer.SetTransform(_current);
    }

    public void PopMatrix()
    {
      _current = _matrixStack.Pop();
      OkuManagers.Renderer.SetTransform(_current);
    }

    public Matrix3 GetTopMatrix()
    {
      return _matrixStack.Peek();
    }

  }
}
