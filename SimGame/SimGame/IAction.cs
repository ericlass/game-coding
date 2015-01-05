using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public interface IAction
  {
    /// <summary>
    /// Gives the action the opportunity to process.
    /// </summary>
    /// <param name="dt">The time past since the last update.</param>
    /// <param name="manager">The event manager that triggered the action.</param>
    /// <returns>True if the action is finished and can be cleaned up, else False.</returns>
    bool Update(float dt);

    /// <summary>
    /// Is called when the action is supposed to stop its work.
    /// </summary>
    /// <param name="manager">The manager that started the action.</param>
    void Cancel();
  }
}
