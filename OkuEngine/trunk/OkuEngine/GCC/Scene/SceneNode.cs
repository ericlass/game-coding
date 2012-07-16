using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public class SceneNode : ISceneNode
  {
    protected bool _enabled = true;
    protected ISceneNode _parent = null;
    protected List<ISceneNode> _children = new List<ISceneNode>();
    protected SceneNodeProperties _props = new SceneNodeProperties();

    public SceneNode(int actorId, string name, RenderPass pass, Color color, Matrix3 transform)
    {
      _props.ActorId = actorId;
      _props.Name = name;
      _props.RenderPass = pass;
      _props.Matrix = transform;
      _props.Material.Color = color;
    }

    public bool Enabled
    {
      get { return _enabled; }
      set { _enabled = value; }
    }

    public SceneNodeProperties Properties
    {
      get { return _props; }
    }

    public void SetTransform(out Matrix3 toWorld)
    {
      toWorld = _props.Matrix;
    }

    public virtual bool Update(Scene scene, float dt)
    {
      foreach (ISceneNode child in _children)
      {
        child.Update(scene, dt);
      }
      return true;
    }

    public virtual bool Restore(Scene scene)
    {
      foreach (ISceneNode child in _children)
      {
        child.Restore(scene);
      }
      return true;
    }

    public virtual bool PreRender(Scene scene)
    {
      scene.PushAndSetMatrix(_props.Matrix);
      return true;
    }

    public virtual bool IsVisible(Scene scene)
    {
      /*
      Vector pos = _props.Matrix.Transform(Vector.Zero);
      scene.Camera.Matrix.Transform(ref pos);
      return scene.Camera.Area.IsInside(pos);
       */
      return true;
    }

    public virtual bool Render(Scene scene)
    {
      throw new NotImplementedException();
    }

    public virtual bool RenderChildren(Scene scene)
    {
      foreach (ISceneNode child in _children)
      {
        if (child.PreRender(scene))
        {
          if (child.IsVisible(scene))
          {
            child.Render(scene);
          }
        }
        child.RenderChildren(scene);
      }
      return true;
    }

    public virtual bool PostRender(Scene scene)
    {
      scene.PopMatrix();
      return true;
    }

    public virtual bool AddChild(ISceneNode node)
    {
      _children.Add(node);
      _props.Area = _props.Area.Add(node.Properties.Area);
      return true;
    }

    public virtual bool RemoveChild(ISceneNode node)
    {
      return _children.Remove(node);
    }

    public virtual bool RemoveChild(int actorId)
    {
      bool result = false;
      for (int i = _children.Count - 1; i >= 0; i--)
      {
        if (_children[i].Properties.ActorId == actorId)
        {
          _children.RemoveAt(i);
          result = true;
        }
      }
      return result;
    }

    public bool OnLostDevice(Scene scene)
    {
      throw new NotImplementedException();
    }

  }
}
