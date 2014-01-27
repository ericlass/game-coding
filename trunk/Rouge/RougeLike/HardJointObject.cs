using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class HardJointObject : GameObjectBase
  {
    private string _sourceId = null;
    private string _targetId = null;
    private GameObjectBase _source = null;
    private GameObjectBase _target = null;

    public GameObjectBase Source
    {
      get { return _source; }
      set { _source = value; }
    }

    public GameObjectBase Target
    {
      get { return _target; }
      set { _target = value; }
    }

    public override string ObjectType
    {
      get { return "hardjoint"; }
    }

    public override void Init()
    {
      _source = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_sourceId);
      _target = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_targetId);
    }

    public override void Update(float dt)
    {
      _target.Position = _source.Position;
    }

    public override void Render()
    {
    }

    public override void Finish()
    {
      _source = null;
      _target = null;
    }

    protected override StringPairMap DoSave()
    {
      StringPairMap result = new StringPairMap();
      result.Add("source", _source.Id);
      result.Add("target", _target.Id);
      return result;
    }

    protected override void DoLoad(StringPairMap data)
    {
      _sourceId = data["source"];
      _targetId = data["target"];
    }
  }
}
