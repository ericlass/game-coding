using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class PlayerControllerObject : GameObjectBase
  {
    private PlayerObject _player = null;
    private TileMapObject _tileMap = null;

    public override string ObjectType
    {
      get { return "playercontroller"; }
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

    protected override StringPairMap DoSave()
    {
      throw new NotImplementedException();
    }

    protected override void DoLoad(StringPairMap data)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      return ObjectType;
    }

  }
}
