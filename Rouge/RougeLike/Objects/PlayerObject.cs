using System;
using System.Collections.Generic;
using System.IO;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike.Objects
{
  public class PlayerObject : GameObjectBase
  {
    private Orientation _orientation = Orientation.Down;
    

    public override string ObjectType
    {
      get { return "player"; }
    }

    public Orientation Orientation
    {
      get { return _orientation; }
      set { _orientation = value; }
    }

    
    
    public override void Init()
    {
    }
    
    public override void Update(float dt)
    {
    }

    public override void Render()
    {
      
    }

    public override void Finish()
    {
    }

    protected override StringPairMap DoSave()
    {
      //Nothing to do at the moment
      return new StringPairMap();
    }

    protected override void DoLoad(StringPairMap data)
    {
      //Nothing to do at the moment
    }

    public override string ToString()
    {
      return ObjectType;
    }
    
  }
}
