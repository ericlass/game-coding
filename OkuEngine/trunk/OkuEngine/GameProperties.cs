using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class GameProperties
  {
    private string _name = "Oku Game";
    private int _startSceneId = 0;

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public int StartSceneId
    {
      get { return _startSceneId; }
      set { _startSceneId = value; }
    }

  }
}
