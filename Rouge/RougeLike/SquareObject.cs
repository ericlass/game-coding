using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;

namespace RougeLike
{
  public class SquareObject : GameObjectBase
  {
    public override string ObjectType
    {
      get { return "square"; }
    }

    public override void Init()
    {
    }

    public override void Update(float dt)
    {
    }

    public override void Render()
    {
      OkuManager.Instance.Graphics.DrawRectangle(Position.X - 6, Position.X + 6, Position.Y - 8, Position.Y + 8, Color.Green);
    }

    public override void Finish()
    {
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
