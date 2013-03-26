using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Drawing;
using OkuEngine.Events;
using OkuEngine.Collision;
using Newtonsoft.Json;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// Mananges a single scene with layers.
  /// </summary>
  public class Scene : StoreableEntity
  {
    private HashSet<SceneLayer> _layers = new HashSet<SceneLayer>();

    private SortedDictionary<int, SceneLayer> _layerMap = new SortedDictionary<int, SceneLayer>();
    private Stack<Matrix3> _matrixStack = new Stack<Matrix3>();
    private Matrix3 _currentTransform = Matrix3.Identity;
    private ViewPort _viewport = new ViewPort(1024, 768);
    private bool _active = false;
    private CollisionWorld<SceneNode> _collisionWorld = null;    

    public Scene()
    {
      Init();
    }

    /// <summary>
    /// Create a new scene with the given id and name.
    /// <param name="id">The id of the new scene.</param>
    /// <param name="name">The name of the new scene.</param>
    /// </summary>
    public Scene(int id, string name)
    {
      _id = id;
      _name = name;
      Init();
    }

    private void Init()
    {
      _viewport.Change += new ViewPortChangeEventHandler(_viewport_Change);
      _collisionWorld = new CollisionWorld<SceneNode>(new NoBroadPhaseDetector<SceneNode>(), new AABBPrecisePhaseDetector<SceneNode>());
    }

    [JsonPropertyAttribute]
    public HashSet<SceneLayer> Layers
    {
      get { return _layers; }
      set { _layers = value; }
    }

    /// <summary>
    /// If the viewport is changed and the scene is active, the viewport change
    /// event is triggered.
    /// </summary>
    /// <param name="sender">The viewport that was changed</param>
    private void _viewport_Change(ViewPort sender)
    {
      if (_active)
        OkuManagers.Instance.EventManager.TriggerEvent(EventTypes.ViewPortChanged, sender);
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

      List<CollisionInfo<SceneNode>> collisions = new List<CollisionInfo<SceneNode>>();
      if (_collisionWorld.GetCollisions(collisions))
      {
        foreach (CollisionInfo<SceneNode> collision in collisions)
        {
          OkuManagers.Instance.EventManager.QueueEvent(EventTypes.CollisionOccurred, collision.BodyA.Data.Properties.ActorId, collision.BodyB.Data.Properties.ActorId);
          OkuManagers.Instance.Logger.LogInfo(Environment.TickCount + " - COLLISION: " + collision.BodyA.Data.Properties.ActorId + " <> " + collision.BodyB.Data.Properties.ActorId);
          //collision.BodyA.Data.Properties.Transform.Translation = collision.BodyA.Data.Properties.Transform.Translation + collision.MTD;
        }
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
      _matrixStack.Push(_currentTransform);
      _currentTransform = transform.AsMatrix() * _currentTransform;
      OkuDrivers.Instance.Renderer.ApplyAndPushTransform(transform);
    }

    /// <summary>
    /// Overwrites the current transform with the value on top of the stack.
    /// </summary>
    public void PopTransform()
    {
      _currentTransform = _matrixStack.Pop();
      OkuDrivers.Instance.Renderer.PopTransform();
    }

    /// <summary>
    /// Gets the current transform.
    /// </summary>
    public Matrix3 CurrentTransform
    {
      get { return _currentTransform; }
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
    public Vector2f ScreenToWorld(int x, int y)
    {
      Point client = OkuDrivers.Instance.Renderer.Display.PointToClient(new Point(x, y));
      return new Vector2f(client.X, OkuDrivers.Instance.Renderer.Display.ClientSize.Height - client.Y);
    }

    /// <summary>
    /// Converts the given screen space coordinates to display space.
    /// </summary>
    /// <param name="x">The x component of the position.</param>
    /// <param name="y">The y component of the position.</param>
    /// <returns>The converted display space position.</returns>
    public Vector2f ScreenToDisplay(int x, int y)
    {
      return Viewport.ScreenSpaceMatrix.Transform(ScreenToDisplay(x, y));
    }

    /// <summary>
    /// Is called when the scene is made the active scene.
    /// </summary>
    public void Activate()
    {
      OkuManagers.Instance.EventManager.TriggerEvent(EventTypes.ViewPortChanged, _viewport);
      _active = true;
    }

    /// <summary>
    /// Is called when another scene is activated and the scene is deactivated.
    /// </summary>
    public void Deactivate()
    {
      _active = false;
    }

    /// <summary>
    /// Checks if one of the layers of the scene contains the actor with the given id.
    /// </summary>
    /// <param name="objectId">The id of the object to find.</param>
    /// <param name="layerIndex">If the object is found, the id of the layer is returned here.</param>
    /// <returns>True if the ator was found, else false.</returns>
    public bool FindActor(int objectId, out int layerIndex)
    {
      layerIndex = 0;
      foreach (SceneLayer layer in _layerMap.Values)
      {
        if (layer.ContainsActor(objectId))
        {
          layerIndex = layer.Id;
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Check if the given AABB is in the visible part of the scene.
    /// </summary>
    /// <param name="boudingBox">The bounding box to be checked.</param>
    /// <returns>True if the given AABB is visible, else false.</returns>
    public bool IsVisible(AABB boudingBox)
    {
      return Intersections.AABBs(boudingBox, Viewport.GetBoundingBox());
    }

    public override bool AfterLoad()
    {
      foreach (SceneLayer layer in _layers)
      {
        if (!layer.AfterLoad())
          return false;
        _layerMap.Add(layer.Id, layer);
      }
      return true;
    }

  }
}
