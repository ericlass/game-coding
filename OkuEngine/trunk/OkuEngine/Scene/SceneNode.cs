using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// The scene node is the most basic item of the Oku engine scene. Do not instanciate this node
  /// directly. Use the functions provided by the <code>SceneGraph</code> class to manage
  /// scene nodes.
  /// </summary>
  public class SceneNode
  {
    private SceneNode _parent = null;
    private SceneNodeList _children = new SceneNodeList();
    private Transformation _transform = new Transformation();
    private ActionHandler _actionHandler = new ActionHandler();
    private VisualContent _content = null;
    private Matrix3 _worldMatrix = Matrix3.Indentity;

    /// <summary>
    /// Creates a new empty scene node.
    /// </summary>
    public SceneNode()
    {
    }

    /// <summary>
    /// Creates a new scene node with the given content.
    /// </summary>
    /// <param name="content">The content of the new scene node.</param>
    public SceneNode(VisualContent content)
    {
      _content = content;
    }

    /// <summary>
    /// Creates a new scene node with the given parent and the given content.
    /// </summary>
    /// <param name="parent">The parent node of the new scene node.</param>
    /// <param name="content">The content of the new scene node.</param>
    public SceneNode(SceneNode parent, VisualContent content)
    {
      _parent = parent;
      _content = content;
    }

    /// <summary>
    /// Gets or sets the parent of the scene node. Trying to set the parent of
    /// a system node throws an <code>InvalidOperationException</code>.
    /// </summary>
    public SceneNode Parent
    {
      get { return _parent; }
      set 
      {
        if (_content != null && _content.ContentId < 0)
          throw new InvalidOperationException("Changing the parent of a system node (Key: " + _content.ContentId + ") is not allowed!");
        _parent = value; 
      }
    }

    /// <summary>
    /// Gets or sets the list of children of the scene node. Don't mess around with this
    /// unless you really know what you are doing. This list is automatically managed
    /// by the <code>SceneGraph</code> node.
    /// </summary>
    public SceneNodeList Children
    {
      get { return _children; }
      set { _children = value; }
    }

    public Transformation Transform
    {
      get { return _transform; }
      set { _transform = value; }
    }

    /// <summary>
    /// Gets or sets the action handler associated with the scenen node.
    /// </summary>
    public ActionHandler ActionHandler
    {
      get { return _actionHandler; }
      set { _actionHandler = value; }
    }

    /// <summary>
    /// Gets or sets the content associated with the scene node. 
    /// Trying to set the content to null throws an <code>ArgumentException</code>.
    /// </summary>
    public VisualContent Content
    {
      get { return _content; }
      set 
      {
        if (_content != null && value == null)
          throw new ArgumentException("The content of a scene node cannot be set to null when it was not null before!");
        _content = value; 
      }
    }

    /// <summary>
    /// Gets or sets the matrix that can be used to transform the scene node to world space coordinates.
    /// This property is calculated and updated by the engine every frame. If you mess with it you really
    /// need to know what you are doing!
    /// </summary>
    public Matrix3 WorldMatrix
    {
      get { return _worldMatrix; }
      set { _worldMatrix = value; }
    }

    /// <summary>
    /// Checks if the scene node is a leaf which means that is has no children.
    /// </summary>
    /// <returns>True if the node is a leaf, else false.</returns>
    public bool IsLeaf()
    {
      return _children.Count == 0;
    }

    /// <summary>
    /// Checks if the scenen node has children.
    /// </summary>
    /// <returns>True if the node has children, else false.</returns>
    public bool HasChildren()
    {
      return _children.Count != 0;
    }

    /// <summary>
    /// Checks if the scene node is a system node. System nodes have a content key
    /// less than 0. The parent and content key of system nodes cannot be changed.
    /// </summary>
    /// <returns>True if the node is a system node, else false.</returns>
    public bool IsSystemNode()
    {
      return _content != null && _content.ContentId < 0;
    }

    /// <summary>
    /// Checks if the scene node is a null node that has no content.
    /// </summary>
    /// <returns>True if the scene node is a Null node, else false.</returns>
    public bool IsNullNode()
    {
      return _content == null;
    }

    /// <summary>
    /// Gets a list of scene nodes representing the parent chain
    /// of this node. This list also includes the node itself. The first node
    /// in the list is the node itself, the last node is always the system
    /// root node.
    /// </summary>
    /// <returns>The parent chain of the node as a list.</returns>
    public SceneNodeList GetParentChain()
    {
      SceneNodeList result = new SceneNodeList();
      SceneNode node = this;
      while (node.Parent != null)
      {
        result.Add(node);
        node = node.Parent;
      }
      return result;
    }

    /// <summary>
    /// Checks if an action handler is assigned to the scene node.
    /// </summary>
    /// <returns>True if an action is assigned, else false.</returns>
    public bool HasAction()
    {
      return _actionHandler.OnAction != null;
    }

    /// <summary>
    /// Executes the action assigned to the scene node with the action type set to Update.
    /// </summary>
    public void ExecuteUpdateAction()
    {
      _actionHandler.OnAction(this, ActionType.Update);
    }

  }
}
