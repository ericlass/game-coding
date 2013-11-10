using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision.Detectors
{
  public class NoBroadPhaseDetector : BroadPhaseDetector
  {
    private List<Body> _bodies = new List<Body>();

    public override void AddBody(Body body)
    {
      _bodies.Add(body);
    }

    public override void UpdateBody(Body body)
    {     
    }

    public override void RemoveBody(Body body)
    {
      _bodies.Remove(body);
    }

    public override void GetCollisionCandidates(Body body, ref List<Body> candidates)
    {
      foreach (Body cand in _bodies)
      {
        if (cand != body && cand.GroupId == body.GroupId)
        {
          candidates.Add(cand);
        }
      }
    }

    public override void Clear()
    {
      _bodies.Clear();
    }

  }
}
