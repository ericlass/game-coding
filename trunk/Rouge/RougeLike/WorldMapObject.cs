using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class WorldMapObject : TileMapObjectBase
  {
    public override string ObjectType
    {
      get { return "worldmap"; }
    }

    public override void Update(float dt)
    {
    }

    protected override void DoLoad(StringPairMap data)
    {
    }

    protected override StringPairMap DoSave()
    {
      return new StringPairMap();
    }

    public override void Init()
    {
    }

  }
}
