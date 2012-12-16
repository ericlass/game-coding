using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Actors;
using OkuEngine.Collision;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// Factory for scene object like actors and brushes.
  /// </summary>
  public class SceneObjectFactory
  {
    private static SceneObjectFactory _instance = null;

    /// <summary>
    /// Gets the static singleton instance of the scene object factory.
    /// </summary>
    public static SceneObjectFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new SceneObjectFactory();

        return _instance;
      }
    }

    /// <summary>
    /// Delegate for scene object constructors.
    /// </summary>
    /// <returns>A new scene object.</returns>
    private delegate SceneObject SceneObjectCreatorDelegate();

    private Dictionary<string, SceneObjectCreatorDelegate> _creators = null;

    /// <summary>
    /// Private constructor for scene object factory.
    /// </summary>
    private SceneObjectFactory()
    {
      _creators = new Dictionary<string, SceneObjectCreatorDelegate>();
      _creators.Add("actor", new SceneObjectCreatorDelegate(CreateActor));
      _creators.Add("brush", new SceneObjectCreatorDelegate(CreateBrush));
    }

    /// <summary>
    /// Creates a new actor.
    /// </summary>
    /// <returns>A new actor.</returns>
    private SceneObject CreateActor()
    {
      return new Actor();
    }

    /// <summary>
    /// Creates a new brush.
    /// </summary>
    /// <returns>A new brush.</returns>
    private SceneObject CreateBrush()
    {
      return new Brush();
    }

    /// <summary>
    /// Creates a scene object for the given XML node.
    /// </summary>
    /// <param name="node">The XML node of a scene object.</param>
    /// <returns>The created and loaded scene object, or null if something went wrong.</returns>
    public SceneObject CreateSceneObject(XmlNode node)
    {
      string tagName = node.Name.Trim().ToLower();
      if (_creators.ContainsKey(tagName))
      {
        SceneObject result = _creators[tagName]();
        if (!result.Load(node))
          return null;
        else
          return result;
      }
      else
      {
        OkuManagers.Logger.LogError("Unknown scene object type '" + tagName + "'! " + node.OuterXml);
      }

      return null;
    }

  }
}
