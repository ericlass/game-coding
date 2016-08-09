using System;
using OkuEngine.Events;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  /// <summary>
  /// System that takes care of updating the spatial hash map.
  /// Registers for all necessary events and forwards updates to
  /// the spatial hash map.
  /// </summary>
  public class SpatialSystem : GameSystem
  {
    public override void LevelChanged(Level previous, Level next)
    {
      if (previous != null)
      {
        //TODO: Unregister from old level
      }

      if (next != null)
      {
        //TODO: Register to new level
      }
    }

    public override void Execute(Level currentLevel)
    {
      throw new NotImplementedException();
    }

  }
}
