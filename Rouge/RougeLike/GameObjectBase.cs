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
    protected abstract StringPairMap DoSave();
    protected abstract void DoLoad(StringPairMap data);

    public string Id { get; set; }
    public int ZIndex { get; set; }
    public int GroupIndex { get; set; }
    public Vector2f Position { get; set; }
    
    public OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }

    public GameObjectBase()
    {
    }

    public StringPairMap Save()
    {
      StringPairMap result = DoSave();
      result.Add("id", Id);
      result.Add("zindex", ZIndex.ToString());
      result.Add("groupindex", GroupIndex.ToString());
      result.Add("position", Position.ToString());
      return result;
    }

    public void Load(StringPairMap data)
    {
      Id = data["id"];
      ZIndex = int.Parse(data["zindex"]);
      GroupIndex = int.Parse(data["groupindex"]);
      Vector2f pos = Vector2f.Zero;
      if (Vector2f.TryParse(data["position"], ref pos))
        Position = pos;
      else
        throw new OkuException("Could not parse position vector!");
      
      data.Remove("id");
      data.Remove("zindex");
      data.Remove("groupindex");
      data.Remove("position");

      DoLoad(data);
    }

  }
}
