using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Driver.Graphics;

namespace OkuBase.Graphics
{
  public class GraphicsManager : Manager
  {
    private IGraphicsDriver _driver = null;

    internal IGraphicsDriver Driver
    {
      get { return _driver; }
    }

    internal void Begin()
    {
    }

    internal void End()
    {
    }

    public override void Initialize(OkuSettings settings)
    {
      throw new NotImplementedException();
    }

    public override void Finish()
    {
      throw new NotImplementedException();
    }

    public override void Update(float dt)
    {
      throw new NotImplementedException();
    }

  }
}
