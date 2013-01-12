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

namespace OkuTest
{
  public class TestGame : OkuGame
  {
    protected override string GetConfigFileName()
    {
      return "okugame.xml";
    }

    protected override void SetupResourceCache(ref ResourceCacheParams resourceParams)
    {
      resourceParams.ResourceFile = new FileSystemResourceFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "content"));
      resourceParams.SizeInMb = 64;
    }

    //Old, unused override methods. Will be removed!
    public override void Initialize()
    {
      RegularGrid grid = new RegularGrid(1000, 1000, 256);
      grid.Centered = true;
      AABB test;
      grid.GetCellBounds(3, 3, true, out test);
    }

    public override void Update(float dt) { }
    public override void Render(int pass) { }

  }
}
