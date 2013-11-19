using System;

namespace RougeLike
{
  /// <summary>
  /// Defines the interface for components.
  /// </summary>
  public interface IComponent : IUpdatable, IIdObject
  {
    /// <summary>
    /// Gets or set the entity the component belongs to.
    /// </summary>
    Entity Owner { get; set; } // Components need to know their owner
    
    /// <summary>
    /// Is called when the state the component belongs to is entered.
    /// If the component does not belong to a state but directly to an
    /// entity, this is only called once when the component is added 
    /// to the entity.
    /// </summary>
    void EnterState();
    
    /// <summary>
    /// Is called when the state the component belongs to is left.
    /// If the component does not belong to a state but directly to an
    /// entity, this is called once when the component is removed from
    /// the entity.
    /// </summary>
    void LeaveState();
  }
}
