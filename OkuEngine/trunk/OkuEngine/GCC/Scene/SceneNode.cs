﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.GCC.Actors;
using OkuEngine.GCC.Actors.Components;

namespace OkuEngine.GCC.Scene
{
  /// <summary>
  /// A single scene node in the scene graph.
  /// Defines several virtual methods that can be overriden
  /// by special scene node. If you override one of these methods
  /// make sure to call the base method.
  /// </summary>
  public class SceneNode : IStoreable
  {
    protected SceneNodeProperties _props = null;
    protected SceneNode _parent = null;
    protected List<SceneNode> _children = new List<SceneNode>();
    private RenderComponent _renderComp = null;

    /// <summary>
    /// Creates a new scene node.
    /// </summary>
    internal SceneNode()
    {
      _props = new SceneNodeProperties();
    }

    /// <summary>
    /// Creates a new scene node with the given paramters.
    /// </summary>
    /// <param name="actorId">The id of the actor that is connected to the scene node.</param>
    /// <param name="name">The name of the scene node.</param>
    internal SceneNode(int actorId)
    {
      _props = new SceneNodeProperties(actorId);
    }

    /// <summary>
    /// Gets the properties of the scene node.
    /// </summary>
    public SceneNodeProperties Properties
    {
      get { return _props; }
    }

    /// <summary>
    /// Gets or sets the parent node of the node.
    /// Setting automatically removes the node
    /// from the previous parents child nodes
    /// and adds it to the new parents child nodes.
    /// </summary>
    public SceneNode Parent
    {
      get { return _parent; }
    }

    /// <summary>
    /// Sets the parent of the node.
    /// Automatically removes the node
    /// from the previous parents child nodes
    /// and adds it to the new parents child nodes.
    /// </summary>
    /// <param name="parent">The new parent of the node.</param>
    internal void SetParent(SceneNode parent)
    {
      if (_parent != null)
      {
        _parent.RemoveChild(this);
      }
      _parent = parent;
      if (_parent != null)
      {
        _parent.AddChild(this);
      }
    }

    public List<SceneNode> Children
    {
      get { return _children; }
    }

    /// <summary>
    /// Adds the given node as a child node of this node.
    /// </summary>
    /// <param name="node">The node to be added as child node.</param>
    /// <returns>True if the node was added as a child, false if it already is a child of the node.</returns>
    public virtual bool AddChild(SceneNode node)
    {
      _children.Add(node);
      return true;
    }

    /// <summary>
    /// Removes the given child node from the node.
    /// </summary>
    /// <param name="node">The child node to be removed.</param>
    /// <returns>True if the child node was removed, false if it was not a child of the node.</returns>
    public virtual bool RemoveChild(SceneNode node)
    {
      return _children.Remove(node);
    }

    /// <summary>
    /// Updates the scene node and all child nodes recursively.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <param name="dt">The time delta since the last frame.</param>
    /// <returns>True if the update was successful, else false.</returns>
    public virtual bool Update(Scene scene, float dt)
    {
      foreach (SceneNode child in _children)
      {
        child.Update(scene, dt);
      }
      return true;
    }

    /// <summary>
    /// Restores the scene node and all child nodes recursively.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the restore was successful, else false.</returns>
    public virtual bool Restore(Scene scene)
    {
      foreach (SceneNode child in _children)
      {
        child.Restore(scene);
      }
      return true;
    }

    private RenderComponent GetRenderComponent()
    {
      if (_renderComp == null)
      {
        Actor actor = OkuData.Actors[_props.ActorId];
        if (actor != null)
        {
          ActorComponent comp = actor.Type.GetComponent(RenderComponent.ComponentId);
          if (comp != null && comp is RenderComponent)
          {
            _renderComp = comp as RenderComponent;
          }
        }
      }
      return _renderComp;
    }

    /// <summary>
    /// Is called just before th node is rendered so it can set up
    /// rendering parameters.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the process was successful, else false.</returns>
    public virtual bool PreRender(Scene scene)
    {
      foreach (SceneNode child in _children)
      {
        child.PreRender(scene);
      }
      return true;
    }

    /// <summary>
    /// Checks if the scene node is visible through the
    /// current active camera by using the bounding box.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the node is visible, else false.</returns>
    public virtual bool IsVisible(Scene scene)
    {
      return Intersections.AABBs(_props.Area, scene.Viewport.GetArea());
    }

    /// <summary>
    /// Renders the scene node.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the node was rendered successfully, else false.</returns>
    public virtual bool Render(Scene scene)
    {
      scene.ApplyAndPushTransform(_props.Transform);
      try
      {
        //TODO: Add visibility check
        RenderComponent renderComp = GetRenderComponent();
        if (renderComp != null)
        {
          renderComp.PreRender();
          OkuManagers.Renderer.DrawMesh(renderComp.Points, renderComp.TexCoords, renderComp.Colors, renderComp.Points.Length, renderComp.Mode, renderComp.Image);
          renderComp.PostRender();
        }
      }
      finally
      {
        scene.PopTransform();
      }

      return true;
    }

    /// <summary>
    /// Renders all children of the scene node recursively.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the children were rendered, else false.</returns>
    public virtual bool RenderChildren(Scene scene)
    {
      scene.ApplyAndPushTransform(_props.Transform);
      try
      {
        foreach (SceneNode child in _children)
        {
          child.Render(scene);
        }
      }
      finally
      {
        scene.PopTransform();
      }
      return true;
    }

    /// <summary>
    /// Is called right after the rendering of the node and it's children.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the process was successfull, else false.</returns>
    public virtual bool PostRender(Scene scene)
    {
      foreach (SceneNode child in _children)
      {
        child.PostRender(scene);
      }
      return true;
    }

    /// <summary>
    /// Adds all children of this scene node recursively to the given list.
    /// This does not include the scene node itself.
    /// </summary>
    /// <param name="allChildren">Will contain all child nodes of this node.</param>
    public void GetAllChildren(List<SceneNode> allChildren)
    {
      foreach (SceneNode child in _children)
      {
        allChildren.Add(child);
        child.GetAllChildren(allChildren);
      }
    }

    public bool Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "actor":
            _props.ActorId = int.Parse(child.FirstChild.Value);
            break;

          case "tint":
            Color tint = Color.Black;
            if (Color.TryParse(child.FirstChild.Value, out tint))
              _props.Tint = tint;
            break;

          case "aabb":
            Vector[] minMax = Converter.ParseVectors(child.FirstChild.Value);
            if (minMax.Length == 2)
              _props.Area = new AABB(minMax[0], minMax[1]);
            else
            {
              OkuManagers.Logger.LogError("AABB '" + child.FirstChild.Value + "' has wrong format!");
            }
            break;

          case "transform":
            _props.Transform.Load(child);
            break;

          case "node":
            SceneNode kid = new SceneNode();
            kid.Load(child);
            kid.SetParent(this);
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      if (_props.ActorId == Actor.InvalidId)
      {
        OkuManagers.Logger.LogError("No actor specified for scene node!");
        return false;
      }

      return true;
    }

    public void Save(XmlWriter writer)
    {
      writer.WriteStartElement("node");

      writer.WriteStartElement("actor");
      writer.WriteValue(_props.ActorId);
      writer.WriteEndElement();

      writer.WriteStartElement("tint");
      writer.WriteValue(_props.Tint.ToString());
      writer.WriteEndElement();

      writer.WriteStartElement("aabb");
      writer.WriteValue(_props.Area.ToString());
      writer.WriteEndElement();

      _props.Transform.Save(writer);

      writer.WriteEndElement();
    }

  }
}
