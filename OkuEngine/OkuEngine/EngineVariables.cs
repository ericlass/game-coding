using System;
using System.Collections.Generic;
using OkuEngine.Collections;

namespace OkuEngine
{
  public class EngineVariables
  {
    private BlackBoard _blackBoard = new BlackBoard();
    private float _deltaTime = 0.0f;

    public BlackBoard Blackboard
    {
      get { return _blackBoard; }
    }

    public float DeltaTime
    {
      get { return _deltaTime; }
      set { _deltaTime = value; }
    }

  }
}
