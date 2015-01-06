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

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      builder.Append("[");

      if (Parameters != null && Parameters.Length > 0)
      {
        builder.Append("\"");
        builder.Append(Parameters[0]);
        builder.Append("\"");
        for (int i = 1; i < Parameters.Length; i++)
        {
          builder.Append(",");
          builder.Append("\"");
          builder.Append(Parameters[i]);
          builder.Append("\"");
        }
      }

      builder.Append("]");

      return ActionId + " " + builder;
    }

  }
}
