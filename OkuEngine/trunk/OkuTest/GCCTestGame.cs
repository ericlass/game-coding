using System;
using System.Collections.Generic;
using System.Xml;
using OkuEngine;
using OkuEngine.GCC;

namespace OkuTest
{
  public class GCCTestGame : OkuGame
  {
    private Actor _actor = null;

    public override void Setup(ref RendererParams renderParams)
    {
      base.Setup(ref renderParams);
    }

    public override void Initialize()
    {
      XmlDocument doc = new XmlDocument();
      doc.Load(".\\content\\actor.xml");

      ActorFactory factory = new ActorFactory();
      _actor = factory.CreateActor(doc.DocumentElement);
    }

    public override void Update(float dt)
    {
      base.Update(dt);
    }

    public override void Render(int pass)
    {
      base.Render(pass);
    }

  }
}
