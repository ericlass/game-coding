using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Scenes
{
  public class SceneManager : EntityManager<Scene>
  {
    private Scene _activeScene = null;

    public SceneManager() : base("scenes", "scene", KeySequence.SceneSequence)
    {
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
      foreach (Scene scene in _entityMap.Values)
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
      if (_entityMap.ContainsKey(sceneId))
      {
        Scene scene = _entityMap[sceneId];
        SetActiveScene(scene);
      }
    }

    public override bool AfterLoad()
    {
      if (!base.AfterLoad())
        return false;
      SetActiveScene(OkuData.Instance.GameProperties.StartSceneId);
      return _activeScene != null;
    }

  }
}
