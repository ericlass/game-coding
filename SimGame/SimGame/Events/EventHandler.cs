using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame.Events
{
  public class EventHandler
  {
    private string _objectId = null;
    private string _actionId = null;
    private object[] _parameters = null;

    public EventHandler(string objectId, string actionId)
    {
      _objectId = objectId;
      _actionId = actionId;
    }

    public EventHandler(string objectId, string actionId, params object[] parameters)
    {
      _objectId = objectId;
      _actionId = actionId;
      _parameters = parameters;
    }
    
    public string ObjectId
    {
      get { return _objectId; }
      set { _objectId = value; }
    }
    
    public string ActionId
    {
      get { return _actionId; }
      set { _actionId = value; }
    }
    
    public object[] Parameters
    {
      get { return _parameters; }
      set { _parameters = value; }
    }

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      builder.Append(_objectId);
      builder.Append(".");
      builder.Append(_actionId);
      builder.Append(" ");

      builder.Append("[");

      if (_parameters != null && _parameters.Length > 0)
      {
        builder.Append("\"");
        builder.Append(_parameters[0]);
        builder.Append("\"");
        for (int i = 1; i < _parameters.Length; i++)
        {
          builder.Append(",");
          builder.Append("\"");
          builder.Append(_parameters[i]);
          builder.Append("\"");
        }
      }

      builder.Append("]");

      return builder.ToString();
    }

  }
}
