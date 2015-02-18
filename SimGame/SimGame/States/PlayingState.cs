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
    private enum InternalState
    {
      Building,
      NewRoom
    }

    private GameObject _surfaceImage = null;
    private GameObject _building = null;

    private InputContext _mainContext = new InputContext();
    private InputContext _menuContext = new InputContext();
    private InternalState _state = InternalState.Building;

    private OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }

    public void Enter()
    {
      Oku.Graphics.Viewport.SetValues(0, GameConstants.ViewPortWidth, 0, GameConstants.ViewPortHeight);
      Oku.Graphics.BackgroundColor = GameConstants.ColorBackground;

      if (_surfaceImage == null)
      {
        _surfaceImage = new GameObject("surface", new ImageObject(Global.Content.GetImage("surface")));
        _surfaceImage.Initialize();
      }

      //This has to be done for every object that is in the state
      if (_building == null)
      {
        BuildingObject build = new BuildingObject(_mainContext);
        build.OnRoomSelect += build_OnRoomSelect;

        _building = new GameObject("building", build);
        _building.Transform.Translation = new Vector2f(GameConstants.BuildingClearance, GameConstants.TerrainHeight);
        _building.Initialize();
      }

      Global.Objects.RegisterAll(_surfaceImage, _building);
    }

    private void build_OnRoomSelect(Room room)
    {
      if (room.Definition.BaseType == RoomType.Empty)
      {
        _state = InternalState.NewRoom;
        _mainContext.Enabled = false;
        _menuContext.Enabled = true;
      }
    }

    public void Update(float dt)
    {
      float speed = 128 * dt;
      if (_mainContext.KeyIsDown(Keys.Up))
      {
        Oku.Graphics.Viewport.Bottom = Math.Min(
          _building.Bounds.Max.Y - GameConstants.RoomHeight / 2,
          Oku.Graphics.Viewport.Bottom + speed);
      }

      if (_mainContext.KeyIsDown(Keys.Down))
        Oku.Graphics.Viewport.Bottom = Math.Max(0, Oku.Graphics.Viewport.Bottom - speed);
    }

    public void Render()
    {
    }

    public void Leave()
    {
      Global.Objects.UnregisterAll(_building, _surfaceImage);
    }

  }
}
