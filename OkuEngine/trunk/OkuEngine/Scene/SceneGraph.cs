using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Every scene content of the uko engine must be part of the scene graph. The scene
  /// graph is a tree with exactly one root node. Adding additional root nodes is not allowed.
  /// The scene graph also contains some fixed system nodes that can not be moved.
  /// </summary>
  public class SceneGraph
  {
    private SceneNode _root = null;
    private SceneNode _game = null;
    private SceneNode _camera = null;
    private SceneNode _world = null;

    private SceneNodeList _nodes = new SceneNodeList();

    /// <summary>
    /// Creates a new scene graph including the system nodes.
    /// </summary>
    public SceneGraph()
    {
      Init();
    }

    private void Init()
    {
      _root = new SceneNode();
      _nodes.Add(_root);

      _game = AddInternal(null, null);
      _camera = AddInternal(null, null);
      _world = AddInternal(null, null);
    }

    /// <summary>
    /// Gets the internal root scene node. All other nodes a below this node and 
    /// it has no parent node. The content key for the root node is -1.
    /// </summary>
    public SceneNode Root
    {
      get { return _root; }
    }

    /// <summary>
    /// Gets the internal game scene node. It's action can be used for the main game
    /// logic. The content key for the game node is -2.
    /// </summary>
    public SceneNode Game
    {
      get { return _game; }
    }

    /// <summary>
    /// Gets the internal camera scene node. The camera scene node is used to specify
    /// the area of the game world that is shown on the screen. The action of this node
    /// can be used to handle automatic camera movements. The content key for the camera
    /// node is -3.
    /// </summary>
    public SceneNode Camera
    {
      get { return _camera; }
    }

    /// <summary>
    /// Gets the internal world scene node. Only the nodes that are below this node are handled
    /// by the renderer and all other parts of the engine. The content key for the root node is -4.
    /// </summary>
    public SceneNode World
    {
      get { return _world; }
    }

    /// <summary>
    /// Gets a list of all nodes in the scene graph. Note that this is the internal list so messing 
    /// it up will mess up the game.
    /// </summary>
    public SceneNodeList Nodes
    {
      get { return _nodes; }
    }

    /// <summary>
    /// Adds a new scene node with the given content without checking
    /// for validity of the content. Only used internaly.
    /// </summary>
    /// <param name="parent">The parent node of the new scene node. If null is given the internal root node is used.</param>
    /// <param name="content">The content.</param>
    /// <returns></returns>
    private SceneNode AddInternal(SceneNode parent, Content content)
    {
      if (parent == null)
        parent = _root;

      SceneNode result = new SceneNode(parent, content);
      parent.Children.Add(result);
      _nodes.Add(result);

      return result;
    }

    /// <summary>
    /// Clears teh scene graph by removing all user nodes. The system nodes will be 
    /// reset to the default. After calling clear the scene graph will be in the same
    /// state when it was created.
    /// </summary>
    public void Clear()
    {
      foreach (SceneNode node in _nodes)
      {
        node.Parent = null;
        node.Children.Clear();
      }
      _nodes.Clear();

      Init();
    }

    /// <summary>
    /// Adds a new scene node with the given content. The new scene node will be
    /// a child of the given parent node. If the given parent node is <code>null</code>,
    /// the internal root node is used as the parent.
    /// </summary>
    /// <param name="parent">The parent node a the new node or null to use the internal root node.</param>
    /// <param name="content">The content of the new scene node.</param>
    /// <returns>The newly created scene node.</returns>
    public SceneNode Add(SceneNode parent, Content content)
    {
      if (content != null && content.ContentId < 0)
        throw new ArgumentException("Content key \"" + content.ContentId + "\" cannot be added! Content keys < 0 are reserved for system use!");

      return AddInternal(parent, content);
    }

    /// <summary>
    /// Removes the given scene node from the scene graph. If the node has children the
    /// <code>includeChildren</code> parameter controls if the children are deleted also (true)
    /// or if the childrens parent is set to the parent of the removed node.
    /// </summary>
    /// <param name="node">The node to be removed.</param>
    /// <param name="includeChildren">Controls if the children are deleted (true) or if the childrens parent is set to the parent of the removed node.</param>
    /// <returns>True if the node was removed. False if the node is not part of the scene graph.</returns>
    public bool Remove(SceneNode node, bool includeChildren)
    {
      if (_nodes.Contains(node))
      {
        if (node.Parent != null)
        {
          node.Parent.Children.Remove(node);
          if (node.HasChildren())
          {
            foreach (SceneNode child in node.Children)
            {
              if (includeChildren)
                Remove(child, includeChildren);  //recurse
              else
                node.Parent.Children.Add(child);
            }
            node.Children.Clear();
          }          
        }
        _nodes.Remove(node);
        return true;
      }
      else
        return false;
    }

    /// <summary>
    /// Move the given node in the scene graph from the current parent to
    /// the given new parent. This move also includes the children of the
    /// node that will be moved.
    /// </summary>
    /// <param name="node">The node to be moved.</param>
    /// <param name="newParent">The new parent node of the node.</param>
    /// <returns></returns>
    public bool Move(SceneNode node, SceneNode newParent)
    {
      if (_nodes.Contains(node))
      {
        if (node.Parent != null)
          node.Parent.Children.Remove(node);
        node.Parent = newParent;
        return true;
      }
      else
        return false;
    }

    /// <summary>
    /// Gets all nodes in the scenegraph with the given key. This is done by a 
    /// linear search, so it is slow.
    /// </summary>
    /// <param name="contentKey">The content key to find.</param>
    /// <returns>A list of all nodes with the given content key.</returns>
    public SceneNodeList GetNodes(int contentKey)
    {
      SceneNodeList result = new SceneNodeList();
      foreach (SceneNode node in _nodes)
      {
        if (node.Content.ContentId == contentKey)
          result.Add(node);
      }
      return result;
    }

  }
}
