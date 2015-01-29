using System;
using System.Collections.Generic;
using System.IO;
using OkuBase;
using OkuBase.Graphics;
using SimGame.Content;
using SimGame.Game;

namespace SimGame.States
{
  public class PlayingState : IGameState
  {
    private const int ViewPortWidth = 960;
    private const int ViewPortHeight = 540;
    private const int FloorWidth = 14;

    private Dictionary<RoomType, Color> _roomColors = new Dictionary<RoomType, Color>() 
    {
      { RoomType.Administration, Color.Silver },
      { RoomType.Empty, Color.Black },
      { RoomType.Entrance, Color.Green },
      { RoomType.Facility, Color.Yellow },
      { RoomType.Laboratory, Color.Blue },
      { RoomType.Security, Color.Red },
      { RoomType.Stairway, Color.Cyan },
      { RoomType.Storage, Color.Magenta }
    };

    private ContentCache _content = null;

    private Image _backgroundImage = null;
    private Color _backgroundColor = new Color(0, 101, 189);

    private List<List<Room>> _rooms = null;

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
      _backgroundImage = _content.GetImage("background");
      
      Oku.Graphics.Viewport.SetValues(0, ViewPortWidth, 0, ViewPortHeight);
      Oku.Graphics.BackgroundColor = _backgroundColor;

      _rooms = new List<List<Room>>();

      var firstFloor = NewEmptyFloor();
      firstFloor[7] = new Room(RoomDefinitions.Entrance);
      _rooms.Add(firstFloor);
    }

    public void Update(IGameDataProvider data, float dt)
    {
    }

    public void Render(IGameDataProvider data)
    {
      Oku.Graphics.DrawImage(_backgroundImage, ViewPortWidth / 2, ViewPortHeight / 2);
    }

    public void Leave(IGameDataProvider data)
    {
      _content.Clear();
    }
  }
}
