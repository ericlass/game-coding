using System;
using System.Collections.Generic;

namespace SimGame
{
  public interface IEventQueueContainer
  {
    EventManager EventQueue { get; }
  }
}
