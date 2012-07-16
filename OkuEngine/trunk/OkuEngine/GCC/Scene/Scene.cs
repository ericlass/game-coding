using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public class Scene
  {
    protected ISceneNode Root { get; set; }
    protected CameraNode Camera { get; set; }
    protected Dictionary<int, ISceneNode> _actorMap = new Dictionary<int, ISceneNode>();

    private Stack<Matrix3> _matrixStack = new Stack<Matrix3>();
    private Matrix3 _current = Matrix3.Indentity;

    public Scene()
    {
      Root = new RootNode();
      Camera = new CameraNode(Matrix3.Indentity, new AABB());
    }

    public bool Render()
    {
      if (Root != null && Camera != null)
      {
        //Update camera?
        if (Root.PreRender(this))
        {
          Root.Render(this);
          Root.RenderChildren(this);
          Root.PostRender(this);
          return true;
        }
      }
      return false;
    }

    public bool Restore()
    {
      return Root.Restore(this);
    }

    public Boolean Update(float dt)
    {
      return Root.Update(this, dt);
    }

    public ISceneNode FindActor(int actorId)
    {
      ISceneNode result = null;
      _actorMap.TryGetValue(actorId, out result);
      return result;
    }

    public bool AddChild(int actorId, ISceneNode node)
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
