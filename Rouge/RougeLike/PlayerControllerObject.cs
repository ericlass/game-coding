using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Geometry;

namespace RougeLike
{
  public class PlayerControllerObject : GameObjectBase
  {
    private string _playerId = null;
    private string _tilemapId = null;

    private PlayerObject _player = null;
    private TileMapObjectBase _tileMap = null;

    public override string ObjectType
    {
      get { return "playercontroller"; }
    }

    public override void Init()
    {
      _player = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_playerId) as PlayerObject;
      _tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_tilemapId) as TileMapObjectBase;
    }

    public override void Update(float dt)
    {
    }

    public override void Render()
    {
    }

    public override void Finish()
    {
      _player = null;
      _tileMap = null;
    }

    protected override StringPairMap DoSave()
    {
      StringPairMap result = new StringPairMap();
      result.Add("playerid", _player.Id);
      result.Add("tilemapid", _tileMap.Id);
      return result;
    }

    protected override void DoLoad(StringPairMap data)
    {
      if (data.ContainsKey("playerid"))
        _playerId = data["playerid"];
      else
        throw new OkuBase.OkuException("The 'playerid' property is mandatory for player controllers!");

      if (data.ContainsKey("tilemapid"))
        _tilemapId = data["tilemapid"];
      else
        throw new OkuBase.OkuException("The 'tilemapid' property is mandatory for player controllers!");
    }

    public override string ToString()
    {
      return ObjectType;
    }

  }
}
