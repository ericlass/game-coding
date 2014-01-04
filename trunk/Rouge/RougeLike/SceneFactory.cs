﻿using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace RougeLike
{
  public class SceneFactory
  {
    private static SceneFactory _instance = null;

    public static SceneFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new SceneFactory();
        return _instance;
      }
    }

    private SceneFactory()
    {
    }

    public SceneList GetHardCodedScene()
    {
      SceneList result = new SceneList();

      PlayerObject player = new PlayerObject();

      SquareObject square = new SquareObject();
      square.Position = new OkuBase.Geometry.Vector2f(0, 100);

      TileMapObject tilemap = new TileMapObject();
      tilemap.Position = new OkuBase.Geometry.Vector2f(0, -100);

      Scene scene = new Scene();
      scene.Name = "Test";

      scene.GameObjects.Add(player);
      scene.GameObjects.Add(square);
      scene.GameObjects.Add(tilemap);

      result.Add(scene);
      return result;
    }

  }
}