using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using OkuBase.Graphics;


namespace SimGame
{
  /// <summary>
  /// Contains several constants for the game which are used in different places.
  /// </summary>
  public static class GameConstants
  {
    public static string ContentPath
    {
      get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Content"); }
    }

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
