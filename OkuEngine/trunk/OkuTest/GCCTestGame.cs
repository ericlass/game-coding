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

      Matrix3 test = Matrix3.Indentity;
      test.Rotate(45);
      test.Scale(2.0f, 3.0f);
      test.Translate(7, 13);
      Matrix3 invert = test.GetInverse();

      Vector pos = new Vector(4.2f, 6.33f);
      Vector result = test.Transform(pos);
      result = invert.Transform(result);

      //ResourceCache test
      FileSystemResourceFile file = new FileSystemResourceFile("D:\\temp");
      ResourceCache cache = new ResourceCache(2, file);
      if (cache.Initialize())
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
