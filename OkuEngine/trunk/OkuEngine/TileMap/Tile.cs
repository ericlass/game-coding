using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OkuEngine
{
  /// <summary>
  /// Struct to store one tile's properties. This is the most memory efficient way
  /// as an object pointer (including null) needs 4 / 8 byte of memory. This struct 
  /// only needs 3.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct Tile
  {
    /// <summary>
    /// Determines which type of collision shape the tile has.
    /// </summary>
    public byte Collision;

    /// <summary>
    /// Determines the index of the image that should be used for this tile.
    /// </summary>
    public ushort Image;

    public Tile(byte collision, ushort image)
    {
      Collision = collision;
      Image = image;
    }
  }
}