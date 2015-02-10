using System;
using System.Collections.Generic;
using SimGame.Content;
using SimGame.Events;
using SimGame.Objects;

namespace SimGame
{
  /// <summary>
  /// Provides global access to some objects that are used in different places.
  /// </summary>
  public static class Global
  {
    public static ContentCache Content { get; set; }
    public static EventManager EventQueue { get; set; }
    public static GameObjectManager Objects { get; set; }
  }
}
