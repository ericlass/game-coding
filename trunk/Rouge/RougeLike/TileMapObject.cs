using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;

namespace RougeLike
{
  public class TileMapObject : GameObjectBase
  {
    public override string ObjectType
    {
      get { return "tilemap"; }
    }

    public override void Init()
    {
      throw new NotImplementedException();
    }

    public override void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public override void Render()
    {
      throw new NotImplementedException();
    }

    public override void Finish()
    {
      throw new NotImplementedException();
    }

    public override StringPairMap DoSave()
    {
      throw new NotImplementedException();
    }

    public override void DoLoad(StringPairMap data)
    {
      throw new NotImplementedException();
    }
  }
}
