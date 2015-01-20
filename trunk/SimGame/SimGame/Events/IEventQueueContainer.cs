using System;
using System.Collections.Generic;

namespace SimGame.Events
{
  public interface IEventQueueContainer
  {
    EventManager EventQueue { get; }
  }
}
