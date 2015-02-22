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
using SimGame.Gui;

namespace SimGame.States
{
  public class PlayingState : IGameState
  {
    private GameObject _surfaceImage = null;
    private GameObject _building = null;
    private GameObject _dialog = null;

    private InputContext _mainContext = new InputContext();

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

      if (_dialog == null)
      {
        SimGame.Gui.Panel subPanel = new Gui.Panel("sub");
        subPanel.BackgroundColor = Color.Red;
        subPanel.Left = 5;
        subPanel.Bottom = 5;
        subPanel.Width = 40;
        subPanel.Height = 20;

        SimGame.Gui.Panel contentPanel = new Gui.Panel("content");
        contentPanel.BackgroundColor = Color.Silver;
        contentPanel.Add(subPanel);

        Dialog dialog = new Dialog(contentPanel, _mainContext);
        dialog.Width = 200;
        dialog.Height = 150;
        dialog.BorderColor = Color.Blue;
        dialog.DrawBorder = true;

        _dialog = new GameObject("dialog", dialog);
        _dialog.ZIndex = 2;
        _dialog.Transform.Translation = new Vector2f(200.0f, 120.0f);
        _dialog.Initialize();
      }

      Global.Objects.RegisterAll(_surfaceImage, _building, _dialog);
    }

    private void build_OnRoomSelect(Room room)
    {
      if (room.Definition.BaseType == RoomType.Empty)
      {
        //TODO: Show new room dialog
      }
    }

    public void Update(float dt)
    {
      _mainContext.Update();

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
      Global.Objects.UnregisterAll(_building, _surfaceImage, _dialog);
    }

  }
}
