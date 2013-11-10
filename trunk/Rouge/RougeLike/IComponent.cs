using System;

namespace RougeLike
{
  public interface IComponent : IUpdatable, IIdObject
  {
    Entity Owner { get; set; } // Components need to know their owner
  }
}
