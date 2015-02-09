using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace SimGame
{
  public static class GameConstants
  {
    public const int ViewPortWidth = 960;
    public const int ViewPortHeight = 540;

    public const int RoomsPerFloor = 13;
    public const int RoomWidth = 64;
    public const int RoomHeight = 64;

    public const int BuildingClearance = 32;
    public const int BuildingWallWidth = 32;
    public const int BuildingRoofHeight = 16;

    public const int TerrainHeight = 32;

    public static Color ColorBackground = new Color(0, 101, 189);
    public static Color ColorBuildingWall = Color.Silver;
  }
}
