using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Input;
using OkuBase.Settings;

namespace OkuBaseTest
{
  public class TestManager : OkuGame
  {
    private List<TestGame> _tests = new List<TestGame>();

    public override OkuSettings Configure()
    {
      OkuSettings result = new OkuSettings();

      result.Audio.DriverName = "null";
      result.Graphics.Width = 1024;
      result.Graphics.Height = 768;

      return result;
    }

    public override void Initialize()
    {
    }

    public override void Update(float dt)
    {
      
    }

    public override void Render()
    {
      
    }

  }
}
