using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public class EventHandler
  {
    public string ActionId { get; set; }
    public object[] Parameters { get; set; }

    public EventHandler(string actionId)
    {
      ActionId = actionId;
    }

    public EventHandler(string actionId, params object[] parameters)
    {
      ActionId = actionId;
      Parameters = parameters;
    }

  }
}
