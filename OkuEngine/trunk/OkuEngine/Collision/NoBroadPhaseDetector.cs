using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision
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

    public override List<Body> GetCollisionCandidates(Body body)
    {
      List<Body> result = new List<Body>();

      foreach (Body cand in _bodies)
      {
        if (cand != body && cand.GroupId == body.GroupId)
        {
          result.Add(cand);
        }
      }

      return result;
    }

    public override void Clear()
    {
      _bodies.Clear();
    }

  }
}
