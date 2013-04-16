using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.Collections;
using OkuEngine.Events;
using OkuEngine.Scenes;

namespace OkuEngine.Collision
{
  public class CollisionWorld
  {
    private HashSet<Body> _bodies = new HashSet<Body>();
    private BroadPhaseDetector _broadDetector = null;
    private PrecisePhaseDetector _preciseDetector = null;
    private HashSet<Body> _updatedBodies = new HashSet<Body>();
    private PairList<Body> _collidedPairs = new PairList<Body>();
    private Dictionary<int, Body> _actorBodyMap = new Dictionary<int, Body>();

    public CollisionWorld(BroadPhaseDetector broadDetector, PrecisePhaseDetector preciseDetector)
    {
      _broadDetector = broadDetector;
      _preciseDetector = preciseDetector;

      OkuManagers.Instance.EventManager.AddListener(EventTypes.SceneNodeMoved, new EventListenerDelegate(SceneNodeMovedEventHandler));
    }

    private void SceneNodeMovedEventHandler(int eventType, params object[] eventData)
    {
      if (eventType == EventTypes.SceneNodeMoved)
      {
        SceneNode node = eventData[0] as SceneNode;
        if (_actorBodyMap.ContainsKey(node.ActorId))
        {
          Body body = _actorBodyMap[node.ActorId];
          _broadDetector.UpdateBody(body);
          _updatedBodies.Add(body);
        }
      }
    }

    public void AddBody(Body body)
    {
      _bodies.Add(body);
      _updatedBodies.Add(body);
      _broadDetector.AddBody(body);
      _actorBodyMap.Add(body.SceneNode.ActorId, body);
    }

    public void RemoveBody(Body body)
    {
      _broadDetector.RemoveBody(body);
      _updatedBodies.Remove(body);
      _bodies.Remove(body);
      _actorBodyMap.Remove(body.SceneNode.ActorId);
    }

    public void Clear()
    {
      _bodies.Clear();
      _updatedBodies.Clear();
      _collidedPairs.Clear();
      _broadDetector.Clear();
      _actorBodyMap.Clear();
    }

    public bool GetCollisions(List<CollisionInfo> collisions)
    {
      collisions.Clear();
      _collidedPairs.Clear();
      foreach (Body body in _updatedBodies)
      {
        List<Body> candidates = _broadDetector.GetCollisionCandidates(body);
        foreach (Body candidate in candidates)
        {
          if (!_collidedPairs.Contains(body, candidate))
          {
            CollisionInfo info = _preciseDetector.GetCollisionInfo(body, candidate);
            if (info != null)
            {
              collisions.Add(info);
              _collidedPairs.Add(info.BodyA, info.BodyB);
            }
          }
        }
      }

      //Clear updated bodies list
      _updatedBodies.Clear();
      //Make sure that currently colliding bodies are also checked next time!
      _collidedPairs.GetDistinctValues(ref _updatedBodies);

      return collisions.Count > 0;
    }

  }
}
