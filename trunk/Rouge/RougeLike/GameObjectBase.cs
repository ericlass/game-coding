using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;

namespace RougeLike
{
  public abstract class GameObjectBase
  {
    public abstract string ObjectType { get; }
    public abstract void Init();
    public abstract void Update(float dt);
    public abstract void Render();
    public abstract void Finish();
    public abstract StringPairMap DoSave();
    public abstract void DoLoad(StringPairMap data);

    public string Id { get; set; }
    public int ZIndex { get; set; }
    public int GroupIndex { get; set; }
    public Vector2f Position { get; set; }

    public GameObjectBase()
    {
    }

    public StringPairMap Save()
    {
      StringPairMap result = DoSave();
      result.Add("Id", Id);
      result.Add("ZIndex", ZIndex.ToString());
      result.Add("GroupIndex", GroupIndex.ToString());
      result.Add("Position", Position.ToString());
      return result;
    }

    public void Load(StringPairMap data)
    {
      Id = data["Id"];
      ZIndex = int.Parse(data["ZIndex"]);
      GroupIndex = int.Parse(data["GroupIndex"]);
      Vector2f pos = Vector2f.Zero;
      if (Vector2f.TryParse(data["Position"], ref pos))
        Position = pos;
      else
        throw new OkuException("Could not parse position vector!");
      
      data.Remove("Id");
      data.Remove("ZIndex");
      DoLoad(data);
    }

  }
}
