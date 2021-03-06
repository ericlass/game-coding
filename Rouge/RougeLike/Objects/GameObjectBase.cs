﻿using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;

namespace RougeLike.Objects
{
  public abstract partial class GameObjectBase
  {
    private Vector2f _position = Vector2f.Zero;
    private Vector2f _scale = Vector2f.One;
    private RenderDescription _renderDesc = new RenderDescription();
    
    public GameObjectBase()
    {
    }

    public abstract string ObjectType { get; }
    public abstract void Init();
    public abstract void Update(float dt);
    public abstract void Finish();
    protected abstract StringPairMap DoSave();
    protected abstract void DoLoad(StringPairMap data);
    
    public string Id { get; set; }
    public int ZIndex { get; set; }
    public int GroupIndex { get; set; }

    public Vector2f Position
    {
      get { return _position; }
      set { _position = value; }
    }

    public Vector2f Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }

    public RenderDescription RenderDescription
    {
      get { return _renderDesc; }
      set { _renderDesc = value; }
    }

    public OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }   

    public StringPairMap Save()
    {
      StringPairMap result = DoSave();
      result.Add("id", Id);

      if (ZIndex != 0)
        result.Add("zindex", ZIndex.ToString());

      if (GroupIndex != 0)
        result.Add("groupindex", GroupIndex.ToString());

      if (Position != Vector2f.Zero)
        result.Add("position", Position.ToString());

      AddDynamicAttributes(result);

      return result;
    }

    public void Load(StringPairMap data)
    {
      if (data.ContainsKey("id"))
        Id = data["id"];
      else
        throw new OkuException("Objects have to have an id property!");

      if (data.ContainsKey("zindex"))
        ZIndex = int.Parse(data["zindex"]);

      if (data.ContainsKey("groupindex"))
        GroupIndex = int.Parse(data["groupindex"]);

      if (data.ContainsKey("position"))
        Position = Vector2f.Parse(data["position"]);
      
      data.Remove("id");
      data.Remove("zindex");
      data.Remove("groupindex");
      data.Remove("position");

      DoLoad(data);

      ExtractDynamicAttributes(data);
    }

  }
}
