using System;
using OkuEngine.Levels;
using OkuEngine.Components;

namespace OkuEngine.Systems
{
  /// <summary>
  /// Generic system that updates several different stuff.
  /// </summary>
  public class UpdateSystem : GameSystem
  {
    public override void Execute(Level currentLevel)
    {
      /*
      foreach (var entity in currentLevel.Entities)
      {
        var position = entity.GetComponent<PositionComponent>();
        if (position != null)
        {
          position.PreviousPosition = position.Position;
        }

        var velocity = entity.GetComponent<VelocityComponent>();
        if (velocity != null)
        {
          velocity.PreviousVelocity = velocity.Velocity;
        }
      }
      */
    }
  }
}
