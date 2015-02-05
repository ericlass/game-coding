using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame.Interpolators
{
  public class Interpolator
  {
    private List<KeyValuePair<float, float>> _stops = new List<KeyValuePair<float, float>>();
    private Action<float> _action = null;

    private float time = 0;

    public Interpolator(Action<float> action)
    {
      _action = action;
    }

    public List<KeyValuePair<float, float>> Stops
    {
      get { return _stops; }
      set { _stops = value; }
    }

    public Action<float> Action
    {
      get { return _action; }
      set { _action = value; }
    }

    public bool Update(float dt)
    {
      if (_stops.Count == 0)
        return true;

      time += dt;

      if (_stops.Count == 1)
      {
        _action(_stops[0].Value);
        if (time >= _stops[0].Key)
          return true;
      }
      else
      {
        int i = 0;
        KeyValuePair<float, float> two = _stops[0];
        while (two.Key < time)
        {
          i++;
          two = _stops[i];
        }
        int prevIndex = Math.Max(0, Math.Min(_stops.Count - 1, i - 1));
        KeyValuePair<float, float> one = _stops[prevIndex];

        float value = 0;
        if (one.Key == two.Key)
        {
          value = one.Value;
        }
        else
        {
          float ratio = (time - one.Key) / (two.Key - one.Key);
          value = (1 - ratio) * one.Value + ratio * two.Value; //Accurate lerp
        }

        _action(value);
      }

      return false;
    }

  }
}
