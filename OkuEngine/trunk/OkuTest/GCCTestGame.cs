﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using OkuEngine;
using OkuEngine.Actors;
using OkuEngine.Processes;
using OkuEngine.Resources;
using OkuEngine.Scripting;

namespace OkuTest
{
  public class GCCTestGame : OkuGame
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

    public override void Initialize()
    {
    }

    public override void Update(float dt)
    {
    }

    public override void Render(int pass)
    {
    }

  }
}
