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

      Matrix3 test = Matrix3.Identity;
      Matrix3 r = Matrix3.CreateRotation(10);
      Matrix3 s = Matrix3.CreateScale(0.9f, 1.1f);
      Matrix3 t = Matrix3.CreateTranslation(5, 5);

      test = r * t * r;

      Matrix3 invert = test.Invert();

      Matrix3 resu = Matrix3.Multiply(test, invert);

      Vector dings = new Vector(1, 1);
      test.Transform(ref dings);
      invert.Transform(ref dings);

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
