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

namespace SimGame.States
{
  public class PlayingState : IGameState
  {
    private const int ViewPortWidth = 960;
    private const int ViewPortHeight = 540;
    private const int FloorWidth = 13;
    private const int RoomSize = 64;

    private ContentCache _content = null;

    private Image _surfaceImage = null;
    private Color _backgroundColor = new Color(0, 101, 189);

    private List<List<Room>> _rooms = null;

    private Room _hoveredRoom = null;
    private Room _selectedRoom = null;

    private OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }

    private List<Room> NewEmptyFloor()
    {
      var result = new List<Room>();

      for (int i = 0; i < FloorWidth; i++)
        result.Add(new Room(RoomDefinitions.Empty));

      return result;
    }

    public void Enter(IGameDataProvider data)
    {
      _content = new ContentCache(data.GetContentPath());
      _surfaceImage = _content.GetImage("surface");
      
      Oku.Graphics.Viewport.SetValues(0, ViewPortWidth, -32, ViewPortHeight - 32);
      Oku.Graphics.BackgroundColor = _backgroundColor;

      _rooms = new List<List<Room>>();

      var firstFloor = new List<Room>();
      firstFloor.Add(new Room(RoomDefinitions.LabMedium));
      firstFloor.Add(new Room(RoomDefinitions.FacilityLarge));
      firstFloor.Add(new Room(RoomDefinitions.Empty));
      firstFloor.Add(new Room(RoomDefinitions.Entrance));
      for (int i = 0; i < 6; i++)
        firstFloor.Add(new Room(RoomDefinitions.Empty));

      _rooms.Add(firstFloor);

      
      var secondFloor = NewEmptyFloor();
      secondFloor[6] = new Room(RoomDefinitions.Stairway);
      _rooms.Add(secondFloor);
    }

    private Room RoomUnderMouse()
    {
      Vector2f pos = Oku.Graphics.ScreenToWorld(Oku.Input.Mouse.X, Oku.Input.Mouse.Y);
      int x = (int)(pos.X - RoomSize);
      int y = (int)(pos.Y - 32);

      if (x < 0 || x > (FloorWidth * RoomSize) || y < 0 || y >= (_rooms.Count * RoomSize))
      {
        return null;
      }
      else
      {
        x /= RoomSize;
        y /= RoomSize;

        var roomsOnFloor = _rooms[y];
        Room result = null;
        int cell = 0;
        foreach (var room in roomsOnFloor)
        {
          cell += room.Definition.NumberOfSpaces;
          if (cell > x)
          {
            result = room;
            break;
          }
        }

        return result;
      }
    }

    public void Update(IGameDataProvider data, float dt)
    {
      _hoveredRoom = RoomUnderMouse();
      if (Oku.Input.Mouse.ButtonPressed(MouseButton.Left))
        _selectedRoom = _hoveredRoom;

      if (Oku.Input.Keyboard.KeyIsDown(Keys.Up))
        Oku.Graphics.Viewport.Bottom = Math.Min(_rooms.Count * 64 - 32, Oku.Graphics.Viewport.Bottom + (128 * dt));
      if (Oku.Input.Keyboard.KeyIsDown(Keys.Down))
        Oku.Graphics.Viewport.Bottom = Math.Max(-32, Oku.Graphics.Viewport.Bottom - (128 * dt));
    }

    public void Render(IGameDataProvider data)
    {
      //Surface
      Oku.Graphics.DrawImage(_surfaceImage, ViewPortWidth / 2, _surfaceImage.Height / 2);

      //Rooms
      float y = 32.0f;
      foreach (var floor in _rooms)
      {
        Oku.Graphics.DrawRectangle(32, 64, y, y + RoomSize, Color.Silver);
        Oku.Graphics.DrawRectangle(896, 928, y, y + RoomSize, Color.Silver);

        float x = 64.0f;
        foreach (var room in floor)
        {
          float roomWidth = room.Definition.NumberOfSpaces * RoomSize;
          float left = x;
          float right = x + roomWidth;
          float top = y + RoomSize;
          float bottom = y;

          Oku.Graphics.DrawRectangle(left, right, bottom, top, room.Definition.BaseColor);
          Oku.Graphics.DrawLine(left, bottom, left, top, 1.0f, Color.Black);
          Oku.Graphics.DrawLine(left, bottom, right, bottom, 1.0f, Color.Black);

          Color frameColor = Color.Black;
          float lineWidth = 4.0f;
          if (room == _selectedRoom)
            frameColor = Color.Magenta;
          else if (room == _hoveredRoom)
            frameColor = Color.White;

          if (room == _hoveredRoom || room == _selectedRoom)
          {
            float halfWidth = lineWidth / 4;
            left += halfWidth;
            bottom += halfWidth;
            right -= halfWidth;
            top -= halfWidth;

            Oku.Graphics.DrawLine(left, bottom, left, top, lineWidth, frameColor);
            Oku.Graphics.DrawLine(left, bottom, right, bottom, lineWidth, frameColor);
            Oku.Graphics.DrawLine(right, bottom, right, top, lineWidth, frameColor);
            Oku.Graphics.DrawLine(left, top, right, top, lineWidth, frameColor);
          }

          x += roomWidth;          
        }
        y += RoomSize;
      }

      //Roof
      Oku.Graphics.DrawRectangle(32, 928, y, y + 16, Color.Silver);

      //GUI
      Oku.Graphics.DrawRectangle(Oku.Graphics.Viewport.Left, Oku.Graphics.Viewport.Right, Oku.Graphics.Viewport.Bottom, Oku.Graphics.Viewport.Bottom + 32, new Color(128, 128, 128));
      Oku.Graphics.DrawRectangle(Oku.Graphics.Viewport.Left, Oku.Graphics.Viewport.Right, Oku.Graphics.Viewport.Top - 32, Oku.Graphics.Viewport.Top, new Color(128, 128, 128));
    }

    public void Leave(IGameDataProvider data)
    {
      _content.Clear();
    }
  }
}
