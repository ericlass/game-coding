using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OkuEngine.GCC.Scene
{
  public class Scene
  {
    private class SceneNodeZIndexSorter : IComparer<SceneNode>
    {
      public int Compare(SceneNode x, SceneNode y)
      {
        if (x == null)
        {
          if (y == null)
            return 0;
          else
            return -1;
        }
        else
        {
          if (y == null)
            return 1;
          else
            return x.Properties.ZIndex - y.Properties.ZIndex;
        }        
      }
    }

    private Dictionary<int, SceneNode> _actorMap = new Dictionary<int, SceneNode>();
    private SortedDictionary<int, List<SceneNode>> _renderPasses = new SortedDictionary<int, List<SceneNode>>();
    private ViewPort _viewport = new ViewPort(1024, 768);
    private SceneNodeZIndexSorter _sorter = new SceneNodeZIndexSorter();

    public Scene()
    {
    }

    public bool Render()
    {
      foreach (KeyValuePair<int, List<SceneNode>> pass in _renderPasses)
      {
        pass.Value.Sort(_sorter);
        foreach (SceneNode node in pass.Value)
        {
          node.PreRender(this);
          node.Render(this);
          node.PostRender(this);
        }
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

    public void AddChild(SceneNode node)
    {
      if (!_actorMap.ContainsKey(node.Properties.ActorId))
      {
        _actorMap.Add(node.Properties.ActorId, node);
      }

      if (!_renderPasses.ContainsKey(node.Properties.RenderPass))
      {
        _renderPasses.Add(node.Properties.RenderPass, new List<SceneNode>());
      }
      _renderPasses[node.Properties.RenderPass].Add(node);
    }

    public void RemoveChild(SceneNode node)
    {
      _actorMap.Remove(node.Properties.ActorId);
      _renderPasses[node.Properties.RenderPass].Remove(node);
    }

    public void RemoveChild(int actorId)
    {
      SceneNode node = null;
      if (_actorMap.ContainsKey(actorId))
      {
        node = _actorMap[actorId];
      }
      if (node != null)
      {
        _renderPasses[node.Properties.RenderPass].Remove(node);
      }
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
