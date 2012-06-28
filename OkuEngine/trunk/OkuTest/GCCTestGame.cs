using System;
using System.Collections.Generic;
using System.Xml;
using OkuEngine;
using OkuEngine.GCC.Actor;
using OkuEngine.GCC.Processes;
using OkuEngine.GCC.Resources;

namespace OkuTest
{
  public class GCCTestGame : OkuGame
  {
    //private Actor _actor = null;
    //private ProcessManager _manager = null;

    public override void Setup(ref RendererParams renderParams)
    {
      base.Setup(ref renderParams);
    }

    public override void Initialize()
    {
      //Actor loading test
      /*
      XmlDocument doc = new XmlDocument();
      doc.Load(".\\content\\actor.xml");

      ActorFactory factory = new ActorFactory();
      _actor = factory.CreateActor(doc.DocumentElement);
      */

      //Process test
      /*
      _manager = new ProcessManager();
      Process p = new DelayProcess(1.0f);
      p.AttachChild(new DelayProcess(2.0f));
      _manager.AttachProcess(p);
      */

      //ResourceCache test
      FileSystemResourceFile file = new FileSystemResourceFile("D:\\temp");
      ResourceCache cache = new ResourceCache(2, file);
      if (cache.Init())
      {
        Resource res = new Resource("AnjaFolie01.psd");
        ResourceHandle handle = cache.GetHandle(res);

        res = new Resource("Samus.wav");
        handle = cache.GetHandle(res);
      }
    }

    public override void Update(float dt)
    {
      //_manager.UpdateProcesses(dt);
    }

    public override void Render(int pass)
    {
      base.Render(pass);
    }

  }
}
