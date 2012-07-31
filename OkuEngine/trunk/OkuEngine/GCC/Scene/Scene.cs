using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OkuEngine.GCC.Scene
{
  /// <summary>
  /// Mananges a single scene with layers.
  /// </summary>
  public class Scene
  {
    private Stack<Matrix3> _matrixStack = new Stack<Matrix3>();
    private Matrix3 _current = Matrix3.Identity;

    private ViewPort _viewport = new ViewPort(1024, 768);
    private int _id = 0;
    private string _name = null;

    private SortedDictionary<int, SceneLayer> _layerMap = new SortedDictionary<int, SceneLayer>();

    /// <summary>
    /// Create a new scene with the given id and name.
    /// <param name="id">The id of the new scene.</param>
    /// <param name="name">The name of the new scene.</param>
    /// </summary>
    public Scene(int id, string name)
    {
      _id = id;
      _name = name;
    }

    /// <summary>
    /// Gets the id of the scene.
    /// </summary>
    public int Id
    {
      get { return _id; }
    }

    /// <summary>
    /// Gets or sets the name of the scene.
    /// </summary>
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    /// <summary>
    /// Add a new layer to the scene with the given id and name.
    /// </summary>
    /// <param name="id">The id of the new layer.</param>
    /// <param name="name">The name of the new layer.</param>
    /// <returns>The newly created layer.</returns>
    public SceneLayer AddLayer(int id, string name)
    {
      if (!_layerMap.ContainsKey(id))
      {
        SceneLayer layer = new SceneLayer(id, name);
        _layerMap.Add(id, layer);
        return layer;
      }
      throw new ArgumentException("You cannot add two layers with the same id to a scene! Layer ID = " + id);
    }

    /// <summary>
    /// Removes the layer with the given id from the scene.
    /// </summary>
    /// <param name="layerId">The id of the layer to be removed.</param>
    /// <returns>True if the layer was removed, false if the scene does not contain a layer with the given id.</returns>
    public bool RemoveLayer(int layerId)
    {
      return _layerMap.Remove(layerId);
    }

    /// <summary>
    /// Gets the number of layers in this scene.
    /// </summary>
    public int LayerCount
    {
      get { return _layerMap.Count; }
    }

    /// <summary>
    /// Gets the layer with the given id.
    /// </summary>
    /// <param name="layerId">The id of the layer.</param>
    /// <returns>The layer with the given id, or null if the scene does not contain a layer with the given id.</returns>
    public SceneLayer GetLayer(int layerId)
    {
      if (_layerMap.ContainsKey(layerId))
        return _layerMap[layerId];

      return null;
    }

    /// <summary>
    /// Renders the scene with all its layers.
    /// </summary>
    /// <returns>True if the scene was rendered properly.</returns>
    public bool Render()
    {
      foreach (KeyValuePair<int, SceneLayer> item in _layerMap)
      {
        item.Value.Render(this);
      }
      return true;
    }

    /// <summary>
    /// Restores the scene and all of tis layers.
    /// </summary>
    /// <returns>True if the scenen was restored, else false.</returns>
    public bool Restore()
    {
      foreach (KeyValuePair<int, SceneLayer> item in _layerMap)
      {
        item.Value.Restore(this);
      }
      return true;
    }

    /// <summary>
    /// Updates the scene and all of its layers.
    /// </summary>
    /// <param name="dt">The time passed since the last frame.</param>
    /// <returns>True if the scene was update, else false.</returns>
    public Boolean Update(float dt)
    {
      foreach (KeyValuePair<int, SceneLayer> item in _layerMap)
      {
        item.Value.Update(this, dt);
      }
      return true;
    }

    /// <summary>
    /// Moves the actor with the given id to another layer.
    /// </summary>
    /// <param name="actorId">The id of the actor to move.</param>
    /// <param name="newLayerId">The id of the layer to move the actor to.</param>
    /// <param name="newParent">The new parent node of the actor after moving it to the new layer. Can be null to add it below the root.</param>
    /// <returns>True if the actor was moved successful, else false.</returns>
    public bool MoveActorToLayer(int actorId, int newLayerId, SceneNode newParent)
    {
      foreach (KeyValuePair<int, SceneLayer> item in _layerMap)
      {
        SceneNode node = item.Value.GetNode(actorId);
        if (node != null)
        {
          item.Value.Remove(actorId);
          SceneNode newNode = _layerMap[newLayerId].Add(actorId, newParent);
          newNode.Properties.Area = node.Properties.Area;
          newNode.Properties.Tint = node.Properties.Tint;
          newNode.Properties.Transform = node.Properties.Transform;
          //TODO: What about the children of the node?
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Pushes the current transorm matrix to the stack and applies the given transform.
    /// </summary>
    /// <param name="transform">The transform to be applied.</param>
    public void ApplyAndPushTransform(Transformation transform)
    {
      _matrixStack.Push(_current);
      _current = transform.AsMatrix() * _current;
      OkuManagers.Renderer.ApplyAndPushTransform(transform);
    }

    /// <summary>
    /// Overwrites the current transform with the value on top of the stack.
    /// </summary>
    public void PopTransform()
    {
      _current = _matrixStack.Pop();
      OkuManagers.Renderer.PopTransform();
    }

    /// <summary>
    /// Gets the current transform.
    /// </summary>
    public Matrix3 CurrentTransform
    {
      get { return _current; }
    }

    /// <summary>
    /// Gets or sets the viewport for the scene.
    /// </summary>
    public ViewPort Viewport
    {
      get { return _viewport; }
      set { _viewport = value; }
    }

    /// <summary>
    /// Converts the given screen space coordinates to world space.
    /// </summary>
    /// <param name="x">The x component of the position.</param>
    /// <param name="y">The y component of the position.</param>
    /// <returns>The converted world space position.</returns>
    public Vector ScreenToWorld(int x, int y)
    {
      Point client = OkuManagers.Renderer.Display.PointToClient(new Point(x, y));
      return new Vector(client.X, OkuManagers.Renderer.Display.ClientSize.Height - client.Y);
    }

    /// <summary>
    /// Converts the given screen space coordinates to displayer space.
    /// </summary>
    /// <param name="x">The x component of the position.</param>
    /// <param name="y">The y component of the position.</param>
    /// <returns>The converted display space position.</returns>
    public Vector ScreenToDisplay(int x, int y)
    {
      return Viewport.ScreenSpaceMatrix.Transform(ScreenToDisplay(x, y));
    }

  }
}
