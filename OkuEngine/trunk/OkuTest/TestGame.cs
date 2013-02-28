using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using OkuEngine;
using OkuEngine.Actors;
using OkuEngine.Processes;
using OkuEngine.Resources;
using OkuEngine.Scripting;
using OkuEngine.Geometry;
using OkuEngine.Collision;

namespace OkuTest
{
  public class TestGame : OkuGame
  {
    private class ColTest
    {
      public string Name { get; set; }

      public ColTest(string name)
      {
        Name = name;
      }
    }

    protected override string GetConfigFileName()
    {
      return "okugame.json";
    }

    protected override void SetupResourceCache(ref ResourceCacheParams resourceParams)
    {
      resourceParams.ResourceFile = new FileSystemResourceFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "content"));
      resourceParams.SizeInMb = 1024;
    }

    //Old, unused override methods. Will be removed!
    public override void Initialize()
    {
      CollisionWorld<ColTest> world = new CollisionWorld<ColTest>(new NoBroadPhaseDetector<ColTest>(), new AABBPrecisePhaseDetector<ColTest>());
      
      Body<ColTest> body = new Body<ColTest>();
      body.BoundingBox = new AABB(-10.0f, -10.0f, 20, 20);
      body.Data = new ColTest("body1");
      body.GroupId = 0;
      body.Transform = new Transformation(new Vector2f(10, 10), Vector2f.One, 0.0f);
      world.AddBody(body);

      body = new Body<ColTest>();
      body.BoundingBox = new AABB(-10.0f, -10.0f, 20, 20);
      body.Data = new ColTest("body2");
      body.GroupId = 0;
      body.Transform = new Transformation(new Vector2f(15, 15), Vector2f.One, 0.0f);
      world.AddBody(body);

      List<CollisionInfo<ColTest>> cols = new List<CollisionInfo<ColTest>>();
      world.GetCollisions(cols);
      foreach (CollisionInfo<ColTest> col in cols)
      {
        OkuManagers.Instance.Logger.LogInfo(col.MTD.ToString());
      }
    }

    public override void Update(float dt) { }
    public override void Render(int pass) { }

  }
}
