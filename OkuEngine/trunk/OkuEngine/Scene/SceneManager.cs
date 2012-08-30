using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Scene
{
  public class SceneManager : IStoreable
  {
    private Dictionary<int, Scene> _scenes = new Dictionary<int, Scene>();
    private Scene _activeScene = null;

    public SceneManager()
    {
    }

    public bool AddScene(Scene scene)
    {
      if (scene != null && !_scenes.ContainsKey(scene.Id))
      {
        _scenes.Add(scene.Id, scene);
        return true;
      }
      return false;
    }

    public bool RemoveScene(Scene scene)
    {
      if (scene != null && _scenes.ContainsKey(scene.Id))
      {
        _scenes.Remove(scene.Id);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Gets the scene with the given id.
    /// </summary>
    /// <param name="id">The id of the scene to find.</param>
    /// <returns>The scene with the given id or null if there is no scene with the given id.</returns>
    public Scene this[int id]
    {
      get
      {
        if (_scenes.ContainsKey(id))
          return _scenes[id];
        else
          return null;
      }
    }

    /// <summary>
    /// Searches for the actor with the given id in all scenes and their layers.
    /// If the actor is found somewhere, the corresponding scene and layer ids are
    /// returned in the sceneId and layerIndex out parameters.
    /// </summary>
    /// <param name="actorId">The id of the actor to find.</param>
    /// <param name="sceneId">If the actor is found, the id of the scene is returned here.</param>
    /// <param name="layerIndex">If the actor is found, the id of the layer is returned here.</param>
    /// <returns>True if the actor was found, else false.</returns>
    public bool FindActor(int actorId, out int sceneId, out int layerIndex)
    {
      sceneId = 0;
      layerIndex = 0;
      foreach (Scene scene in _scenes.Values)
      {
        if (scene.FindActor(actorId, out layerIndex))
        {
          sceneId = scene.Id;
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Gets the current active scene.
    /// </summary>
    public Scene ActiveScene
    {
      get { return _activeScene; }
    }

    /// <summary>
    /// Sets the current active scene. This automatically activates the
    /// new active scene and deactivates the previous active scene.
    /// </summary>
    /// <param name="scene">The scene to set active.</param>
    internal void SetActiveScene(Scene scene)
    {
      if (_activeScene != null)
        _activeScene.Deactivate();

      _activeScene = scene;
      _activeScene.Activate();
    }

    /// <summary>
    /// Sets the current active scene. This automatically activates the
    /// new active scene and deactivates the previous active scene.
    /// </summary>
    /// <param name="scene">The id of the scene to set active.</param>
    internal void SetActiveScene(int sceneId)
    {
      if (_scenes.ContainsKey(sceneId))
      {
        Scene scene = _scenes[sceneId];
        SetActiveScene(scene);
      }
    }

    public bool Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "scene":
            Scene scene = new Scene();
            if (!scene.Load(child))
            {
              OkuManagers.Logger.LogError("Could not load scene '" + scene.Id + "'!");
              return false;
            }
            KeySequence.SetCurrentValue(KeySequence.SceneSequence, scene.Id);
            if (!AddScene(scene))
            {
              OkuManagers.Logger.LogError("The scene id '" + scene.Id + "' is used twice!");
              return false;
            }            
            break;

          default:
            break;
        }
        child = child.NextSibling;
      }

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("scenes");

      foreach (Scene scene in _scenes.Values)
      {
        scene.Save(writer);
      }

      writer.WriteEndElement();

      return true;
    }

  }
}
