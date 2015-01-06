using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  /// <summary>
  /// Base interface for entities. Will be put into a wrapper object which takes care of additional stuff.
  /// </summary>
  public interface IEntity
  {
    string Id { get; }
    
  }
}
