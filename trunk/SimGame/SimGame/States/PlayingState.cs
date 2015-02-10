﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Geometry;
using OkuBase.Input;
using SimGame.Content;
using SimGame.Game;
using SimGame.Objects;

namespace SimGame.States
{
  public class PlayingState : IGameState
  {
    private ContentCache _content = null;
    private Image _surfaceImage = null;
    private GameObject _building = null;

    private OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }

    public void Enter(IGameDataProvider data)
    {
      Oku.Graphics.Viewport.SetValues(0, GameConstants.ViewPortWidth, 0, GameConstants.ViewPortHeight);
      Oku.Graphics.BackgroundColor = GameConstants.ColorBackground;
    
      if (_content == null)
        _content = new ContentCache(data.GetContentPath());
        
      if (_surfaceImage == null)
        _surfaceImage = _content.GetImage("surface");

      //This has to be done for every object that is in the state
      if (_building == null)
      {
        BuildingObject obj = new BuildingObject();
        _building = obj.CreateGameObject("building");
        _building.Initialize();
      }
      
      data.ObjectManager.Register(_building);
    }

    public void Update(IGameDataProvider data, float dt)
    {
      float speed = 128 * dt;
      if (Oku.Input.Keyboard.KeyIsDown(Keys.Up))
      {
        Oku.Graphics.Viewport.Bottom = Math.Min(
          GameConstants.ViewPortHeight, //TODO: Limit to building
          Oku.Graphics.Viewport.Bottom + speed);
      }

      if (Oku.Input.Keyboard.KeyIsDown(Keys.Down))
        Oku.Graphics.Viewport.Bottom = Math.Max(0, Oku.Graphics.Viewport.Bottom - speed);
    }

    public void Render(IGameDataProvider data)
    {
      //Surface
      Oku.Graphics.DrawImage(_surfaceImage, GameConstants.ViewPortWidth / 2, _surfaceImage.Height / 2);
    }

    public void Leave(IGameDataProvider data)
    {
      data.ObjectManager.Unregister(_building);
    }
  }
}
