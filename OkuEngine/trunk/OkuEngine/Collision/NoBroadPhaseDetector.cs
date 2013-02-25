using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision
{
  public class NoBroadPhaseDetector<T> : BroadPhaseDetector<T>
  {
    private List<Body<T>> _bodies = new List<Body<T>>();

    public override void AddBody(Body<T> body)
    {
      _bodies.Add(body);
    }

    public override void UpdateBody(Body<T> body)
    {     
    }

    public override void RemoveBody(Body<T> body)
    {
      _bodies.Remove(body);
    }

    public override List<Body<T>> GetCollisionCandidates(Body<T> body)
    {
      List<Body<T>> result = new List<Body<T>>();

      foreach (Body<T> cand in _bodies)
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
