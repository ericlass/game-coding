using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Input;
using SimGame.Game;
using SimGame.Mouse;

namespace SimGame.Objects
{
  public class BuildingObject : GameObjectBase
  {
    private List<List<Room>> _rooms = null;
    private MouseProcessor _mouse = null;
    private SortedList<string, Room> _roomMap = new SortedList<string, Room>();

    private Room _hoveredRoom = null;
    private Room _selectedRoom = null;

    public BuildingObject(InputContext input)
    {
      _mouse = new MouseProcessor(OnMouseEvent, input);
    }

    public override Rectangle2f GetBounds()
    {
      return new Rectangle2f(
        0, 0, 
        GameConstants.RoomWidth * GameConstants.RoomsPerFloor + (2 * GameConstants.BuildingWallWidth),
        _rooms.Count * GameConstants.RoomHeight + GameConstants.BuildingRoofHeight);
    }

    public override object GetAttributeValue(string attribute)
    {
      if (attribute == "selected_room")
        return _selectedRoom;

      return null;
    }

    private List<Room> NewEmptyFloor()
    {
      var result = new List<Room>();

      for (int i = 0; i < GameConstants.RoomsPerFloor; i++)
        result.Add(new Room(RoomDefinitions.Empty));

      return result;
    }

    private void UpdateRoomRegions(GameObject obj)
    {
      _mouse.ClearRegions();
      _roomMap.Clear();

      int bottom = (int)obj.Transform.Translation.Y;
      for (int y = 0; y < _rooms.Count; y++)
      {
        List<Room> floor = _rooms[y];
        int left = (int)obj.Transform.Translation.X + GameConstants.BuildingWallWidth;
        for (int x = 0; x < floor.Count; x++)
        {
          Room room = floor[x];
          string id = "room" + x + "." + y;
          _roomMap.Add(id, room);

          Rectangle2f area = new Rectangle2f(left, bottom, GameConstants.RoomWidth * room.Definition.NumberOfSpaces, GameConstants.RoomHeight);
          _mouse.AddRegion(id, area);

          left += GameConstants.RoomWidth * room.Definition.NumberOfSpaces;
        }
        bottom += GameConstants.RoomHeight;
      }
    }

    public override void Initialize(GameObject obj)
    {
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

      UpdateRoomRegions(obj);
    }

    private GameObject _obj = null;

    private void OnMouseEvent(string region, MouseEvent mevent, MouseButton button)
    {
      if (!_roomMap.ContainsKey(region))
        throw new ArgumentException("Unknown region: '" + region + "'!");

      Room room = _roomMap[region];

      switch (mevent)
      {
        case MouseEvent.Enter:
          _hoveredRoom = room;
          break;
        case MouseEvent.Leave:
          _hoveredRoom = null;
          break;
        case MouseEvent.ButtonDown:
          if (_selectedRoom != room)
          {
            _selectedRoom = room;
            _obj.QueueEvent(Events.EventIds.SelectionChanged);            
          }
          break;
        default:
          break;
      }
    }

    public override void Update(GameObject obj, float dt)
    {
      _obj = obj;
      _mouse.Update();
    }

    public override void Render(GameObject obj)
    {
      float floorWidth = GameConstants.RoomsPerFloor * GameConstants.RoomWidth;
      float y = 0;
      float leftmostRoom = GameConstants.BuildingWallWidth;

      //Floors
      foreach (var floor in _rooms)
      {
        //Left wall
        Oku.Graphics.DrawRectangle(
          0,
          leftmostRoom,
          y,
          y + GameConstants.RoomHeight,
          GameConstants.ColorBuildingWall);

        //Right wall
        Oku.Graphics.DrawRectangle(
          leftmostRoom + floorWidth,
          leftmostRoom + floorWidth + GameConstants.BuildingWallWidth,
          y,
          y + GameConstants.RoomHeight,
          GameConstants.ColorBuildingWall);

        //Rooms
        float x = leftmostRoom;
        foreach (var room in floor)
        {
          float roomWidth = room.Definition.NumberOfSpaces * GameConstants.RoomWidth;
          float left = x;
          float right = x + roomWidth;
          float top = y + GameConstants.RoomHeight;
          float bottom = y;

          Oku.Graphics.DrawRectangle(left, right, bottom, top, room.Definition.BaseColor);

          //Debug grid lines
          Oku.Graphics.DrawLine(left, bottom, left, top, 1.0f, Color.Black);
          Oku.Graphics.DrawLine(left, bottom, right, bottom, 1.0f, Color.Black);

          Color frameColor = Color.Black;
          if (room == _selectedRoom)
            frameColor = Color.Magenta;
          else if (room == _hoveredRoom)
            frameColor = Color.White;

          if (room == _hoveredRoom || room == _selectedRoom)
          {
            const float lineWidth = 4.0f;
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
        y += GameConstants.RoomHeight;
      }

      //Roof
      Oku.Graphics.DrawRectangle(
        0,
        (2 * GameConstants.BuildingWallWidth) + floorWidth,
        y,
        y + GameConstants.BuildingRoofHeight, GameConstants.ColorBuildingWall);
    }

  }
}
