using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public class Scene
  {
    private Dictionary<int, SceneNode> _actorMap = new Dictionary<int, SceneNode>();
    private ViewPort _viewport = new ViewPort(1024, 768);

    public Scene()
    {
    }

    public bool Render()
    {
      foreach (SceneNode node in _actorMap.Values)
      {
        node.PreRender(this);
        node.Render(this);
        node.PostRender(this);
      }

      return true;
    }

    public bool Restore()
    {
      foreach (SceneNode node in _actorMap.Values)
      {
        node.Restore(this);
      }
      return true;
    }

    public Boolean Update(float dt)
    {
      foreach (SceneNode node in _actorMap.Values)
      {
        node.Update(this, dt);
      }
      return true;
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

    public ViewPort Viewport
    {
      get { return _viewport; }
      set { _viewport = value; }
    }

  }
}
