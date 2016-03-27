using System;
using System.Collections.Generic;
using OkuEngine.Collections;

namespace OkuEngine
{
  public class LevelEngineLocator
  {
    public EngineFunctions Functions
    {
      get { return Engine.Instance.Functions; }
    }

    public EngineVariables Variables
    {
      get { return Engine.Instance.Variables; }
    }

  }
}
