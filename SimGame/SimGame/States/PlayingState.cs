using System;
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
    private BuildingObject _building = null;

    private OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }

    public void Enter(IGameDataProvider data)
    {
      _content = new ContentCache(data.GetContentPath());
      _surfaceImage = _content.GetImage("surface");

      Oku.Graphics.Viewport.SetValues(0, GameConstants.ViewPortWidth, 0, GameConstants.ViewPortHeight - 32);
      Oku.Graphics.BackgroundColor = GameConstants.ColorBackground;

      _building = new BuildingObject();
      data.ObjectManager.Register(_building.CreateGameObject("building"));

      //TODO: THIS IS SHIT!!! When are the states objects initialized and by whom?
      data.ObjectManager.Initialize();
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
      _content.Clear();
    }
  }
}
